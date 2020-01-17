using ExpressionReg;
using Intellect.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intellect.Main
{
    public class MorphologicalAnalysis
    {
        //take data from TableData
        private TablesData data = new TablesData();
        private string morphoSentence = "";
        private string morphoSentenceSpeech = "";
        private string[] subsMophoSentence;
        private string[] unknownWord;
        //private int temp = 0;
        private RegularExpresion regularExpresion = new RegularExpresion();
        private string[] ConvertStringToArray(String sentence)
        {
            string newSentence = sentence.ToLower();
            string[] words = newSentence.Split(" ");
            return words;
        }

        /// <summary>
        /// нахождение возможные оканчания
        /// </summary>
        /// <param name="sentence"></param>
        public void SearchMorphologicalCodeSentence(string sentence)
        {
            string[] words = ConvertStringToArray(sentence);
            unknownWord = new String[words.Length];

            //ищем по одному слово
            foreach (string word in words)
            {
                List<string> potentialWordEnds = new List<string>();
                string wordEnding;
                int temp = 0;
                potentialWordEnds.Add("");
                Console.WriteLine("Рассматриваю слово: " + "\"" + word + "\"");
                int flag = 0;
                //max размер окончания
                for (int i = 1; i < 5; i++)
                {
                    if (word.Length - i >= 0)
                    {
                        int index = word.Length - i;
                        wordEnding = word.Substring(index, i);
                        foreach (string end in data.Ends)
                        {
                            if (end.Equals(wordEnding))
                            {
                                potentialWordEnds.Add(wordEnding);
                            }
                        }
                        foreach (string potentialWordEnd in potentialWordEnds)
                        {
                            Console.WriteLine("Возможное окончание слова\"" + word + "\"=" + "\"" + potentialWordEnd + "\"");
                            int count = word.LastIndexOf(potentialWordEnd);
                            string newpotentialWordEnd = potentialWordEnd;
                            string wordClone;
                            if (potentialWordEnd == "")
                            {
                                string newWord = word;
                                newpotentialWordEnd = potentialWordEnd + "+"; 
                                newWord = newWord + "+";
                                wordClone = newWord.Substring(0, newWord.LastIndexOf(newpotentialWordEnd));
                            }
                            else
                            {
                                wordClone = word.Substring(0, word.LastIndexOf(newpotentialWordEnd));
                            }
                            
                            foreach (string el in data.WordBasis)
                            {
                                string basis = regularExpresion.GetBasisFromWord(el, "-.{1,}");
                                if (wordClone.Equals(basis))
                                {
                                    flag++;
                                    Console.WriteLine("Основа слова:" + "\"" + basis + "\"");
                                    Console.WriteLine("Окончание слова:" + "\"" + newpotentialWordEnd + "\"");
                                    morphoSentence += data.WordBasis.IndexOf(el) + "." + data.Ends.IndexOf(newpotentialWordEnd) + "-";
                                }
                            }
                        }
                    }
                    potentialWordEnds.Clear();
                }
                if (flag == 0)
                {
                    Console.WriteLine("Слово \"" + word + "\" Не найдено");
                    morphoSentence = morphoSentence + "0.0" + "-";
                    unknownWord[temp] = word;
                    temp++;
                }
            }
            Console.WriteLine("Код предложения: " + morphoSentence);
        }

        /// <summary>
        /// нахождение морфологическую информацию
        /// </summary>
        public void SearchMorphologicalInformation()
        {
            regularExpresion = new RegularExpresion();
            string newMorphoSentence = regularExpresion.ReplaceSentence(morphoSentence, "-", " ").Trim();
            string[] collectionMorphoSentence = newMorphoSentence.Split(" ");

            foreach (string item in collectionMorphoSentence)
            {
                if (!(item.Equals("0.0")))
                {
                    int i = Int32.Parse(regularExpresion.GetBasisFromWord(item, @"\d{1,}\."));
                    int j = Int32.Parse(regularExpresion.GetBasisFromWord(item, @"\.\d{1,}"));
                    Console.WriteLine("item non i = {0}", i);
                    Console.WriteLine("item non j = {0}", j);
                }
            }
        }
    }
}
