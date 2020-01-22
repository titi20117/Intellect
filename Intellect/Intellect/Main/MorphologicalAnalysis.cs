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

        public string MorphoSentenceSpeech { get { return morphoSentenceSpeech; } }
        private TablesData data = new TablesData();
        private string morphoSentence = "";
        private string morphoSentenceSpeech = "";
        private string[] subsMophoSentence;
        private string[] unknownWord;
        //private int temp = 0;
        private RegularExpresion regularExpresion = new RegularExpresion();
        public string[] ConvertStringToArray(String sentence)
        {
            string newSentence = sentence.ToLower();
            string[] words = newSentence.Split(" ");
            return words;
        }

        /// <summary>
        /// нахождение возможные окончания
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

            foreach (string code in collectionMorphoSentence)
            {
                if (!(code.Equals("0.0")))
                {
                    int i = Int32.Parse(regularExpresion.GetBasisFromWord(code, @"\.\d{1,}"));
                    int j = Int32.Parse(regularExpresion.GetBasisFromWord(code, @"\d{1,}\."));
                    string basisMorphoInfo = regularExpresion.ReplaceSentence(data.WordBasis[i], "\\-.{1,}", "");
                    string endMorphoInfo = regularExpresion.ReplaceSentence(data.Ends[j], "\\-.{1,}", "");
                    Console.WriteLine("Код слова = {0}({1}\"+\"{2})", code, basisMorphoInfo, endMorphoInfo);
                    Console.WriteLine("Морфологическая информация: " + data.TabMophoInfo[i,j]);

                    if(!(data.TabMophoInfo[i,j].Equals("")))
                    {
                        FindGrammarInformation(Int32.Parse(data.TabMophoInfo[i, j]), i, j);
                    }
                    else
                    {
                        Console.WriteLine("Грамматическая информация: не добавлена");
                    }
                }
                else
                {
                    Console.WriteLine("Код слово = " + code);
                    Console.WriteLine("Слово не определено");
                    morphoSentenceSpeech = morphoSentenceSpeech + "С ";
                }
            }
        }
        /// <summary>
        /// искать грамматическую информацию
        /// </summary>
        /// <param name="num = number grammar info"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void FindGrammarInformation(int num, int i, int j)
        {
            string info = data.GrammarInfo[num - 1];
            string gramInfo = regularExpresion.ReplaceSentence(info, ".{1,}\\-", "");
            if(i >= 0 && i <= 6)
            {
                Console.WriteLine("Существительное мужкого рода: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "С ";
            }
            if (i >= 7 && i <= 9)
            {
                Console.WriteLine("Существительное женского рода: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "С ";
            }
            if (i >= 10 && i <= 17)
            {
                Console.WriteLine("Прилагательные: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "ПР ";
            }
            if (i == 18)
            {
                Console.WriteLine("Глаголы в личной форме: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "Г ";
            }

            if (i >= 19 && i <= 23)
            {
                Console.WriteLine("Глаголы в прошедшем времени: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "Г ";
            }
            if (i == 24)
            {
                Console.WriteLine("Количественные числительные: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "Г ";
            }
            if (i >= 25 && i <= 29)
            {
                Console.WriteLine("Местоимения: " + gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "М ";
            }
            if (i >= 30 && i <= 35)
            {
                Console.WriteLine(gramInfo);
                morphoSentenceSpeech = morphoSentenceSpeech + "ПД ";
            }
        }
    }
}
