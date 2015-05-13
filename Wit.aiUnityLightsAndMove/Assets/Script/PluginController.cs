using UnityEngine;
using System.Collections;
using UnityHttpReq;
using System;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class PluginController : MonoBehaviour {


	//this app works with my Wit.ai code
	// change it if you wanto to use this app as a template
	string wit_code = "EIZVGRFJR4THCTATYLNAAMOXIUWBPV7N";

    string lightoff = @"lightsoff";
	string lighton = @"lightson";
	string move10 = @"move10";


	// NLP_Processing is the code that processes the response from wit.ai
    NLP_Processing processor;
	public GameObject Gtxt;
	Text txt;


	[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
	private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);


    // Variables used for speech recording
    private bool recording = false;
	private bool enRec = true;
    private string speechfilename = "";
    // Set a timer to make sure recording doesn't exceed 10 seconds
    private System.Timers.Timer speechTimer = new System.Timers.Timer();

	
	// Use this for initialization
	void Start () {		
		
		processor = new NLP_Processing(wit_code);
		txt = Gtxt.GetComponent<Text> ();
		txt.text = "Press R to START Record";

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

		if (Input.GetKeyDown (KeyCode.R)) {
			if(enRec) SwitchRecord();
		}
	}

	private void SwitchRecord(){

		if (!recording)
		{
			recording = true;
			string tempfile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), RandomString(8));
			
			speechfilename = @tempfile;
			
			mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
			mciSendString("record recsound", "", 0, 0);
			txt.text = "Press R to STOP Record";;
			speechTimer.Enabled = true;
		}
		else
		{
			recording = false;
			speechTimer.Enabled = false;
			mciSendString("save recsound " + speechfilename, "", 0, 0);
			mciSendString("close recsound ", "", 0, 0);
			txt.text = "record";
			enRec = false;
						
			processor.ProcessSpokenFile(speechfilename);

			enRec = true;
			txt.text = "Press R to START Record";
		}

	}

	// Generate temp random string name
	// Thanks RCIX @ stackoverflow.com :)
	//private static Random random = new Random((int)DateTime.Now.Ticks);
	private string RandomString(int size)
	{

		string  temp = "tempSpeechFile";
		/*StringBuilder builder = new StringBuilder();
		char ch;
		for (int i = 0; i < size; i++)
		{
			ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
			builder.Append(ch);
		}
		
		return builder.ToString();*/
		return temp;
	}


	
	// Update is called once per frame
	void Update () {


	}
}
