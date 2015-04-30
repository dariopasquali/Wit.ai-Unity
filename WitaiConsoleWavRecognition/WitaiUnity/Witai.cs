using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WitaiUnity;

namespace WitaiUnity
{
    class Witai
    {
         // O_NLP.RootObject is a class that contains the data interpreted from wit.ai
        O_NLP.RootObject oNLP = new O_NLP.RootObject();

        // NLP_Processing is the code that processes the response from wit.ai
        NLP_Processing vitNLP;

        public Witai(string wit_ai_access_token)
        {
            vitNLP = new NLP_Processing(wit_ai_access_token);
        }

        public void SentenceProcessing(string sentence)
        {
            this.StartProcessing(sentence, 0);
        }

        public void FileProcessing(string filename)
        {
            this.StartProcessing(filename, 1);
        }

        public  void DataProcessing(byte[] data)
        {
            string nlp_text = vitNLP.ProcessSpokenData(data);
            this.ElaborateResponse(nlp_text);
        }


        private void StartProcessing(string text, int type)
        {
            try
            {
                string modtext = Pre_NLP_Processing.preprocessText(text);

                string nlp_text = "";

                if (type == 0)
                {
                    nlp_text = vitNLP.ProcessWrittenText(modtext);
                }
                else
                {
                    nlp_text = vitNLP.ProcessSpokenText(text);
                }
                this.ElaborateResponse(nlp_text);
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry, no idea what's what. Try again later please!" + Environment.NewLine + Environment.NewLine + "I bumped onto this error: " + ex.Message);
            }               
        }

        private string ElaborateResponse(string nlp_text)
        {
            Console.WriteLine("\n" + nlp_text);
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

            Type classType = objAssembly.GetType("WitaiUnity." + oNLP.outcomes[0].intent);

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
