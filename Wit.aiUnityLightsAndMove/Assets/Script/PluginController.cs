using UnityEngine;
using System.Collections;
using UnityHttpReq;

public class PluginController : MonoBehaviour {

	string wit_code = "EIZVGRFJR4THCTATYLNAAMOXIUWBPV7N";
	string filepath = @"C:\Users\Public\Documents\Unity Projects\Wit.aiUnityLightsAndMove\";

    string filename = @"lightsoff.wav";

   
    // NLP_Processing is the code that processes the response from wit.ai
    NLP_Processing processor;

	
	
	// Use this for initialization
	void Start () {
		
		
		print ("Attivo Witai");
        processor = new NLP_Processing(wit_code);
		
		string file = filepath+filename;
        processor.ProcessSpokenFile(file);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
