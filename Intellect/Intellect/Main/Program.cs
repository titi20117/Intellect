using ExpressionReg;
using Intellect.Data;
using System;

namespace Intellect.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            RegularExpresion regularExpresion = new RegularExpresion();
            Console.WriteLine("Что хотите знать на тему : Лучший игрок финалов НБА <<Баскетбол>>");
            
            string input = Console.ReadLine();
            input = regularExpresion.ReplaceSentence(input, "\\s+", " ").Trim();
            Scanner scanner = new Scanner(input);
            Console.WriteLine(scanner.ToString());

            MorphologicalAnalysis morphologicalAnalysis = new MorphologicalAnalysis();
            morphologicalAnalysis.SearchMorphologicalCodeSentence(input);
            morphologicalAnalysis.SearchMorphologicalInformation();
            Console.WriteLine("**********************************************************************************************");
            Console.WriteLine("**********************************************************************************************");
            Console.WriteLine("**********************************************************************************************");
            Console.WriteLine("Синтактический анализ предложения: {0}", input);
            SyntacticAnalysis syntacticAnalysis = new SyntacticAnalysis(morphologicalAnalysis.MorphoSentenceSpeech, morphologicalAnalysis.ConvertStringToArray(input));
            syntacticAnalysis.SearchSyntactic();
        }
    }
}

