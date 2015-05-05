using UnityEngine;
using System.Collections;


public class LightsActuator : MonoBehaviour {

	public GameObject DirLight;
    private Light lamp;
    private static bool state = true;

    public static void setActive(bool s)
    {
        state = s;
    }

	// Use this for initialization
	void Start () {
        lamp = DirLight.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        lamp.enabled = state;    
    }
}