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
        private int temp = 0;
        private RegularExpresion regularExpresion;
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
        public void SearchEnds(string sentence)
        {
            string[] words = ConvertStringToArray(sentence);
            int temp;
            int flag;

            foreach (string word in words)
            {
                unknownWord = new String[words.Length];
                List<string> morpho = new List<string>();
                List<string> morphologicalEnds = new List<string>();
                temp = 0;
                morpho.Add("");
                Console.WriteLine("Рассматриваю слово: " + "\"" + word + "\"");
                flag = 0;
                morphologicalEnds = FindEndForOneWord(word, morpho, ref temp, ref flag);
                OutPutEnds(word, morphologicalEnds, ref temp, ref flag);
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
            string[] collectionMorphoInfo = morphoSentence.Split("-");

            foreach (string item in collectionMorphoInfo)
            {
                if (!(item.Equals("0.0")))
                {
                    int i = Int32.Parse(regularExpresion.GetBasisFromWord(item, @"\d{1,}\."));
                    int j = Int32.Parse(regularExpresion.GetBasisFromWord(item, @"\.\d{1,}"));
                    Console.WriteLine("item non 0.0 {0}", i);
                    Console.WriteLine("item non 0.0 {0}", j);
                }
            }
        }

        //Find all ends for only one word in sentence
        private List<string> FindEndForOneWord(string word, List<string> morpho, ref int flag, ref int temp)
        {
            List<string> collection = new List<string>();
            collection = data.Ends;
            string wordEnding;
            List<string> resultMorpho = morpho;
            for (int i = 1; i < 5; i++)
            {
                if (word.Length - i >= 0)
                {
                    int index = word.Length - i;
                    wordEnding = word.Substring(index, i);
                    foreach (string item in collection)
                    {
                        if (item.Equals(wordEnding))
                        {
                            resultMorpho.Add(wordEnding);
                        }
                    }
                }
            }
            return resultMorpho;
        }

        //show on the screen the ends of words
        private void OutPutEnds (string word, List<string> myListEnds, ref int temp, ref int flag)
        {
            regularExpresion = new RegularExpresion();
            foreach (string item in myListEnds)
            {
                Console.WriteLine("Возможное окончание слова\"" + word + "\"=" + "\"" + item + "\"");
                int count = word.LastIndexOf(item);
                string wordClone = (item == "") ? word : word.Substring(0, word.LastIndexOf(item));
                foreach (string el in data.WordBasis)
                {
                    string basis = regularExpresion.GetBasisFromWord(el, "-.{1,}");
                    if (wordClone.Equals(basis))
                    {
                        flag++;
                        Console.WriteLine("Основа слова:" + "\"" + basis + "\"");
                        Console.WriteLine("Окончание слова:" + "\"" + item + "\"");
                        morphoSentence += data.WordBasis.IndexOf(el) + "." + data.Ends.IndexOf(item) + "-";
                    }
                }
            }
        }
    }
}
