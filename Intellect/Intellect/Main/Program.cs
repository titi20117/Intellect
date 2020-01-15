﻿using ExpressionReg;
using System;

namespace Intellect.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            RegularExpresion regularExpresion = new RegularExpresion();
            Console.WriteLine("Введите Предложение");
            string input = Console.ReadLine();
            input = regularExpresion.ReplaceSentence(input, "\\s+", " ").Trim();
            Scanner scanner = new Scanner(input);
            Console.WriteLine(scanner.ToString());

            MorphologicalAnalysis morphologicalAnalysis = new MorphologicalAnalysis();
            morphologicalAnalysis.SearchEnds(input);
            morphologicalAnalysis.SearchMorphologicalInformation();
        }
    }
}
