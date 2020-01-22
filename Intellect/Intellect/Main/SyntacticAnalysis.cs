using Intellect.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intellect.Main
{
    class SyntacticAnalysis
    {
        //string syntacticMorphoSentenceSpeech;
        //string[] syntacticSubSentence;
        //string[,] syntacticMatrix;
        //int nounCount;
        //int otherCount;
        //int l = 1;

        //string syntMainSentence = "";
        //bool noNoun = false;
        private string morphoSentenceSpeech;
        private string[] wordsSentence;
        public string[] ArrayOfSpeechSentence { get { return GetArrayOfSpeechSentence(); }  }


        public SyntacticAnalysis(string sentenceSpeech, string[] subsSentence)
        {
            this.morphoSentenceSpeech = sentenceSpeech;
            this.wordsSentence = subsSentence;
            
            //nounCount = syntacticMorphoSentenceSpeech.Length - syntacticMorphoSentenceSpeech.Replace("l", "").Length;
            //otherCount = syntacticMorphoSentenceSpeech.Length - nounCount + 1;
            //SearchSyntactic();
            //SearchNoun();
            //OutputSyntacticMatric(syntacticMatrix);
            //SyntacticAnalysisToString(syntacticMatrix);
            //SearchVerb();
            //OutputSyntacticMatric(syntacticMatrix);
            //SyntacticAnalysisToString(syntacticMatrix);
            //SearchAdjective();
            //OutputSyntacticMatric(syntacticMatrix);
            //SyntacticAnalysisToString(syntacticMatrix);
            //SearchOther();
            //OutputSyntacticMatric(syntacticMatrix);
            //SyntacticAnalysisToString(syntacticMatrix);
            //SearchSupple();
            //OutputSyntacticMatric(syntacticMatrix);
            //Console.WriteLine("Синтаксический анализ: ");
            //SyntacticAnalysisToString(syntacticMatrix);
        }

        private string[] GetArrayOfSpeechSentence()
        {
            return this.morphoSentenceSpeech.Trim().Split(' ');
        }
        public void SearchSyntactic()
        {
            List<string> groupSentence = new List<string>();//будем хранить групп слов
            List<string> copyWordSpeech = new List<string>();//copy of word sentence
            string newSentence = "";
            for (int i = 0; i <  wordsSentence.Length; i++)
            {
                Console.WriteLine("Слово \"{0}\" : {1}", wordsSentence[i], ArrayOfSpeechSentence[i]);
                copyWordSpeech.Add(ArrayOfSpeechSentence[i]);
            }

            foreach (string item in copyWordSpeech)
            {
                for (int i = 0; i < 4; i++)//кол связыва. групп.
                {
                    //if (item == ) ;
                }
            }

            
        }
        private void SearchVerb(string[] speechSentence)
        {

        }
        //private void SearchSupple()
        //{
        //    int suppleCount = syntacticMorphoSentenceSpeech.Length - syntacticMorphoSentenceSpeech.Replace("5", "").Length;
        //    Console.WriteLine("Количество дополнений: " + suppleCount);
        //    for (int i = 0; i < syntacticMorphoSentenceSpeech.Length; i++)
        //    {
        //        if (syntacticMorphoSentenceSpeech[i] == '5')
        //        {
        //            int index = FindInSyntacticMatrix(i, syntacticMatrix);
        //            if (syntacticMatrix[index, l].Equals("x"))
        //            {
        //                syntacticMatrix[index, l] = i.ToString();
        //            }
        //            else
        //            {
        //                l++;
        //                syntacticMatrix[index, l] = i.ToString();
        //            }
        //        }
        //    }
        //}

        //private void SearchOther()
        //{
        //    int otherCount = syntacticMorphoSentenceSpeech.Length - syntacticMorphoSentenceSpeech.Replace("4", "").Length;
        //    Console.WriteLine("Количество остального: " + otherCount);
        //    for (int i = 0; i < syntacticMorphoSentenceSpeech.Length; i++)
        //    {
        //        if (syntacticMorphoSentenceSpeech[i] == '4')
        //        {
        //            int index = FindInSyntacticMatrix(i, syntacticMatrix);
        //            if (syntacticMatrix[index, l].Equals("x"))
        //            {
        //                syntacticMatrix[index, l] = i.ToString();
        //            }
        //            else
        //            {
        //                l++;
        //                syntacticMatrix[index, l] = i.ToString();
        //            }
        //        }
        //    }
        //}

        //public void SearchAdjective()
        //{
        //    int index;
        //    int adjectiveCount = syntacticMorphoSentenceSpeech.Length - syntacticMorphoSentenceSpeech.Replace("2", "").Length;
        //    Console.WriteLine("Количество прилагательных: " + adjectiveCount);
        //    for (int i = 0; i < syntacticMorphoSentenceSpeech.Length; i++)
        //    {
        //        if(syntacticMorphoSentenceSpeech[i] == '2')
        //        {
        //            if((i + 1) != syntacticMorphoSentenceSpeech.Length)
        //            {
        //                if(syntacticMorphoSentenceSpeech[i+1] == '1')
        //                {
        //                    index = FindIndexSyntacticMatrix(syntacticMatrix, i + 1);
        //                    if(syntacticMatrix[index,l].Equals("x"))
        //                    {
        //                        syntacticMatrix[index, l] = i.ToString();
        //                    }
        //                    else
        //                    {
        //                        l++;
        //                        syntacticMatrix[index, l] = i.ToString();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                index = FindInSyntacticMatrix(i, syntacticMatrix);
        //                if(syntacticMatrix[index, l].Equals("x"))
        //                {
        //                    syntacticMatrix[index, l] = i.ToString();
        //                }
        //                else
        //                {
        //                    l++;
        //                    syntacticMatrix[index, l] = i.ToString();
        //                }
        //            }
        //        }
        //    }
        //}

        //private int FindInSyntacticMatrix(int i, string[,] syntacticMatrix)
        //{
        //    int index = 0;
        //    if ((nounCount != 0)&&(noNoun == false))
        //    {
        //        string[,] clone = cloneMatrix(syntacticMatrix);
        //        for (int j = 0; j < nounCount; j++)
        //        {
        //            clone[j, 0] = (Math.Abs(Int32.Parse(clone[j, 0]) - i)).ToString();
        //        }
        //        int result = Int32.Parse(clone[0, 0]);
        //        for (int j = 0; j < nounCount; j++)
        //        {
        //            if(Int32.Parse(clone[j,0]) < result)
        //            {
        //                result = Int32.Parse(clone[j, 0]);
        //                index = j;
        //            }
        //        }
        //    }
        //    return index;
        //}

        //private string[,] cloneMatrix(string[,] originMatrix)
        //{
        //    string[,] clone = new string[(originMatrix.GetUpperBound(0) + 1), originMatrix.GetLength(0)];
        //    Array.Copy(originMatrix, 0, clone, 0, originMatrix.GetLength(0));
        //    return clone;
        //}

        //private int FindIndexSyntacticMatrix(string[,] matrix, int x)
        //{
        //    int index = 0;
        //    string xNext = x.ToString();
        //    for (int i = 0; i < nounCount; i++)
        //    {
        //        for (int j = 0; j < otherCount; j++)
        //        {
        //            if (matrix[i,j].Equals(xNext))
        //            {
        //                index = i;
        //            }
        //        }
        //    }
        //    return index;
        //}

        //private void SearchVerb()
        //{
        //    int verbCount = syntacticMorphoSentenceSpeech.Length - syntacticMorphoSentenceSpeech.Replace("3", "").Length;
        //    Console.WriteLine("Количество глаголов: " + verbCount);
        //    for (int i = 0; i < syntacticMorphoSentenceSpeech.Length; i++)
        //    {
        //        if (syntacticMorphoSentenceSpeech[i] == '3')
        //        {
        //            int index = FindInSyntacticMatrix(i, syntacticMatrix);
        //            if (syntacticMatrix[index, l].Equals("x"))
        //            {
        //                syntacticMatrix[index, l] = i.ToString();
        //            }
        //            else
        //            {
        //                l++;
        //                syntacticMatrix[index, l] = i.ToString();
        //            }
        //        }
        //    }
        //}

        //private string SyntacticAnalysisToString(string[,] matrix)
        //{
        //    syntMainSentence = "";
        //    for (int i = 0; i < nounCount; i++)
        //    {
        //        syntMainSentence = syntMainSentence + "(";
        //    }
        //    for (int i = 0; i < nounCount; i++)
        //    {
        //        for (int j = 0; j < otherCount; j++)
        //        {
        //            if (!(matrix[i, j].Equals("x")))
        //            {
        //                syntMainSentence = syntMainSentence + SyntacticSubSentence(matrix[i, j]) + " ";
        //            }
        //        }
        //        syntMainSentence = syntMainSentence.Trim() + ")";
        //    }
        //    Console.WriteLine(syntMainSentence);
        //    return syntMainSentence;
        //}
        //private void OutputSyntacticMatric(string[,] matrix)
        //{
        //    for (int i = 0; i < nounCount; i++)
        //    {
        //        for (int j = 0; j < otherCount; j++)
        //        {
        //            Console.WriteLine(matrix[i, j]);
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //private void SearchNoun()
        //{
        //    Console.WriteLine("Количество существительных в им.п. " + nounCount);
        //    if(nounCount != 0)
        //    {
        //        syntacticMatrix = new string[nounCount, otherCount];
        //        for(int i = 0; i < nounCount; i++)
        //        {
        //            for(int j = 0; j < otherCount; j++)
        //            {
        //                syntacticMatrix[i, j] = "x";
        //            }
        //        }
        //        int count = 0;
        //        for(int i = 0; i < syntacticMorphoSentenceSpeech.Length; i++)
        //        {
        //            if(syntacticMorphoSentenceSpeech[i] == '1')
        //            {
        //                syntacticMatrix[count, 0] = i.ToString();
        //                count++;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        nounCount = 1;
        //        noNoun = true;
        //        syntacticMatrix = new string[nounCount, otherCount];
        //        for (int i = 0; i < nounCount; i++)
        //        {
        //            for (int j = 0; j < otherCount; j++)
        //            {
        //                syntacticMatrix[i, j] = "x";
        //            }
        //        }
        //        int count = 0;
        //        for (int i = 0; i < syntacticMorphoSentenceSpeech.Length; i++)
        //        {
        //            if (syntacticMorphoSentenceSpeech[i] == '1')
        //            {
        //                syntacticMatrix[count, 0] = i.ToString();
        //                count++;
        //            }
        //        }
        //    }
        //}

        //private void SearchSyntactic()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine();
        //    Console.WriteLine(syntacticMorphoSentenceSpeech);
        //}
        //string SyntacticSubSentence(string number)
        //{
        //    return syntacticSubSentence[Int32.Parse(number)];
        //}
    }
}

