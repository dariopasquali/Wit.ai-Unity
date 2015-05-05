using UnityEngine;
using System.Collections;
using UnityHttpReq;

public class PluginController : MonoBehaviour {

    /*
     * Change the Wit_code with your Client Scces Token from the setting page of your Wit.ai Console
     * Change the filepath with the location of your audio file
     */
    string wit_code = "EIZVGRFJR4THCTATYLNAAMOXIUWBPV7N";
	string filepath = @"C:\Users\Public\Documents\Unity Projects\Wit.aiUnityLightsAndMove\";

    string lightoff = @"lightsoff.wav";
	string lighton = @"lightson.wav";
	string move10 = @"move10.wav";
	string stop = @"stop.wav";
	string go = @"go.wav";

	public GameObject cube;

   
    // NLP_Processing is the code that processes the response from wit.ai
    NLP_Processing processor;

	
	// Use this for initialization
	void Start () {		
		
		print ("Wit.ai Controller started");
        processor = new NLP_Processing(wit_code);

	}

	void FixedUpdate () {

        
		if (Input.GetKeyDown (KeyCode.P)) {			
			string file = filepath+lightoff;			
		}
        else if (Input.GetKeyDown (KeyCode.O)) {			
			string file = filepath+lighton;
		}
        else if (Input.GetKeyDown (KeyCode.W)) {
			string file = filepath+move10;
		}
        else if (Input.GetKeyDown (KeyCode.G)) {
			string file = filepath+go;
		}
        else if (Input.GetKeyDown (KeyCode.S)) {
			string file = filepath+stop;
		}

        processor.ProcessSpokenFile(file);
	}

	
	// Update is called once per frame
	void Update () {


	}
}
