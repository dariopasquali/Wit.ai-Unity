using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LightsActuator : MonoBehaviour {

	public GameObject DirLight;
    private Light lamp;
    private static bool state = true;
	public GameObject text;
	private Text log;

    public static void setActive(bool s)
    {
        state = s;
    }

	// Use this for initialization
	void Start () {
        lamp = DirLight.GetComponent<Light>();
		log = text.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        lamp.enabled = state;
		log.text = UnityHttpReq.NLP_Processing.log;
    }
}