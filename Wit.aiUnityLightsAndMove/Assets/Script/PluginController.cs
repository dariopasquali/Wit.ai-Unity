using UnityEngine;
using System.Collections;
using UnityHttpReq;

public class PluginController : MonoBehaviour {


	//this app works with my Wit.ai code
	// change it if you wanto to use this app as a template
	string wit_code = "EIZVGRFJR4THCTATYLNAAMOXIUWBPV7N";

    string lightoff = @"lightsoff.wav";
	string lighton = @"lightson.wav";
	string move10 = @"move10.wav";


	public GameObject cube;

   
    // NLP_Processing is the code that processes the response from wit.ai
    NLP_Processing processor;

	
	// Use this for initialization
	void Start () {		
		
		processor = new NLP_Processing(wit_code);

	}

	void FixedUpdate () {

		if (Input.GetKeyDown (KeyCode.P)) {
			processor.ProcessSpokenFile(lightoff);
		}
		
		if (Input.GetKeyDown (KeyCode.O)) {
			processor.ProcessSpokenFile(lighton);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			processor.ProcessSpokenFile(move10);
		}
	}

	
	// Update is called once per frame
	void Update () {


	}
}
