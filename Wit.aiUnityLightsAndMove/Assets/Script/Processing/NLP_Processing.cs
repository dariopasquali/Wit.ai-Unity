using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Reflection;
using UnityEngine;
using HTTP;

namespace UnityHttpReq
{
    class NLP_Processing
    {
        private  string wit_ai_access = "F2F6AZ3G3X2737DH4ZDB33H4U64QNAPB";
        private string speech_url = "https://api.wit.ai/speech";

       

        // O_NLP.RootObject is a class that contains the data interpreted from wit.ai
        private O_NLP.RootObject oNLP = new O_NLP.RootObject();

       
        public NLP_Processing(string wit_ai_access_token)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (s, ce, ca, p) => true;
            wit_ai_access = wit_ai_access_token;
        }

        private  bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors policyErrors)
        {
            return true;
        }

        public void ProcessSpokenFile(string file)
        {
			UnityEngine.Debug.Log ("File reading");
            FileStream filestream = new FileStream(file, FileMode.Open, FileAccess.Read);
            BinaryReader filereader = new BinaryReader(filestream);
            byte[] BA_AudioFile = filereader.ReadBytes((Int32)filestream.Length);
            filestream.Close();
            filereader.Close();

			UnityEngine.Debug.Log("Send wit request");
            Request req = new Request("POST", speech_url, BA_AudioFile);
            req.AddHeader("Authorization", "Bearer " + wit_ai_access);
            req.AddHeader("Content-Type", "audio/wav");

            req.Send((request) =>
            {
                UnityEngine.Debug.Log(ElaborateResponse(request.response.Text));
            });
          
        }


        private string ElaborateResponse(string nlp_text)
        {
            UnityEngine.Debug.Log(nlp_text);

            // If the audio file doesn't contain anything, or wit.ai doesn't understand it, a code 400 will be returned
            if (nlp_text.Contains("The remote server returned an error: (400) Bad Request"))
            {
                throw new Exception("The remote server returned an error: (400) Bad Request");
                //return "Sorry, didn't get that. Could you please repeat yourself?";                   
            }

            oNLP = Post_NLP_Processing.ParseData(nlp_text);

            // This codeblock dynamically casts the intent to the corresponding class
            // Check README.txt in Vitals.Brain
            Assembly objAssembly;
            objAssembly = Assembly.GetExecutingAssembly();

			Type classType = objAssembly.GetType("UnityHttpReq." + oNLP.outcomes[0].intent);

            object obj = Activator.CreateInstance(classType);

            MethodInfo mi = classType.GetMethod("doSomething");

            object[] parameters = new object[1];
            parameters[0] = oNLP;

            mi = classType.GetMethod("doSomething");
            string sentence = "";
            sentence = (string)mi.Invoke(obj, parameters);

            // Show what was deducted from the sentence
            //nlp_text += "\n\n"+sentence;

            return sentence;

        }


        
    }
}
