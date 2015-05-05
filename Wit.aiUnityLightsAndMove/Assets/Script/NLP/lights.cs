using UnityEngine;
using System.Collections;
using UnityHttpReq;

namespace UnityHttpReq
{
	public class lights
	{		
		public O_NLP.RootObject o_NLP = new O_NLP.RootObject();
		private double conf = 0D;
        private string state = "";
                
		
		public string doSomething(O_NLP.RootObject _o_NLP)
		{
			// Bind to the wit.ai NLP response class
			o_NLP = _o_NLP;



			conf = (o_NLP.outcomes[0].confidence * 100);

			state = o_NLP.outcomes[0].entities.on_off[0].value;

            if (state.Equals("on"))
                LightsActuator.setActive(true);
            else
                LightsActuator.setActive(false);


			string sentence = "";
			sentence += "sentence: " + o_NLP.outcomes [0]._text + "\n";
			sentence += "intent: lights\n";
			sentence += "state: " + state+"\n";
			sentence += "confidence: " + conf+"\n"; 
			
			return sentence;
		}
		
		// Use this for initialization
		void Start()
		{
			
		}
		
		// Update is called once per frame
		void Update()
		{
			
		}
	}
}