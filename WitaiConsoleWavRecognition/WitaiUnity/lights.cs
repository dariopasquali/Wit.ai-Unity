using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitaiUnity
{
    class lights
    {
        public O_NLP.RootObject o_NLP = new O_NLP.RootObject();
        public double conf = 0D;
        public string state = "";

        

        public string doSomething(O_NLP.RootObject _o_NLP)
        {
            // Bind to the wit.ai NLP response class
            o_NLP = _o_NLP;
            conf = (o_NLP.outcomes[0].confidence * 100);
            state = o_NLP.outcomes[0].entities.on_off[0].value;

            if (state.Equals("on"))
                Console.WriteLine("lampada accesa");
            else
                Console.WriteLine("lampada spenta!");

            string sentence = "";

            sentence += "Hello! I'm " + conf.ToString() + "% sure you set up lights.";

            return sentence;
        }

    }
}
