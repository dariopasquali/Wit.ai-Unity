using System;



namespace UnityHttpReq
{
	public class move
	{
		public O_NLP.RootObject o_NLP = new O_NLP.RootObject();

		private double conf = 0D;

		private string direction = "";
		private float value = 0F;
		private string unit = "";

		public string doSomething(O_NLP.RootObject _o_NLP)
		{
			// Bind to the wit.ai NLP response class
			o_NLP = _o_NLP;
			conf = (o_NLP.outcomes[0].confidence * 100);
			
			direction = o_NLP.outcomes [0].entities.direction [0].value;
			value = o_NLP.outcomes [0].entities.distance[0].value;
			unit = o_NLP.outcomes [0].entities.distance[0].unit;

			if (!direction.Equals ("stop")) {

				PlayerMover.startMovement (direction, value, unit);

			} else {

				PlayerMover.stopMovement();
			}
			
			string sentence = "";
			
			sentence += "Hello! I'm " + conf.ToString() + "% sure you set up lights.";
			
			return sentence;
		}

	}
}

