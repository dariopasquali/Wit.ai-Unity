using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitaiUnity
{
    class Controller
    {
        

        // Use this for initialization
        public static void Main()
        {

            string wit_code = "EIZVGRFJR4THCTATYLNAAMOXIUWBPV7N";
            string filepath = @"C:\Users\Gabri\Desktop\GITHUB\Wit.ai-Unity\WitaiConsoleWavRecognition\";

            string filename = "ligthsoff.wav";

            Witai witai;

            Console.WriteLine("Attivo Witai");
            witai = new Witai(wit_code);
            string file = filepath+filename;

            witai.FileProcessing(file);

            Console.Read();
        }

    }
}
