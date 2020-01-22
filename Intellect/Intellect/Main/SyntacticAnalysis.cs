using Intellect.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intellect.Main
{
    class SyntacticAnalysis
    {
        private string morphoSentenceSpeech;
        private string[] wordsSentence;

        string syntacticSentence = "";
        List<string> copyWordSpeech = new List<string>();//copy of word sentence
        public string[] ArrayOfSpeechSentence { get { return GetArrayOfSpeechSentence(); }  }


        public SyntacticAnalysis(string sentenceSpeech, string[] subsSentence)
        {
            this.morphoSentenceSpeech = sentenceSpeech;
            this.wordsSentence = subsSentence;
        }

        private string[] GetArrayOfSpeechSentence()
        {
            return this.morphoSentenceSpeech.Trim().Split(' ');
        }
        public void SearchSyntactic()
        {
            List<string> groupSentence = new List<string>();//будем хранить групп слов
            List<string> speechSentence = new List<string>();
            
            for (int i = 0; i <  wordsSentence.Length; i++)
            {
                Console.WriteLine("Слово \"{0}\" : {1}", wordsSentence[i], ArrayOfSpeechSentence[i]);
                copyWordSpeech.Add(ArrayOfSpeechSentence[i]);
                speechSentence.Add(ArrayOfSpeechSentence[i]);
                groupSentence.Add(ArrayOfSpeechSentence[i]);

            }
            //Подбираем синтаксики
            int testNoun = 0;
            int testVerb = 0;
            foreach (string item in speechSentence)
            {
                if (item == "М")
                    Searchpronouns(groupSentence);
                if(testVerb == 0)
                {
                    if (item == "Г") {
                        testVerb++;                            
                        SearchVerbs(groupSentence);
                    }

                }
                if (testNoun == 0)
                {
                    if (item == "ПМ" || item == "ПР" || item == "С")
                    {
                        testNoun++;
                        SearchNouns(groupSentence);
                    }

                }
                groupSentence.Remove(item);
            }
        }
        private void Searchpronouns(List<string> speechSentence)
        {
            foreach (string item in speechSentence)
            {
                if (item == "М")
                {
                    syntacticSentence = syntacticSentence + "( " + wordsSentence[Array.IndexOf(ArrayOfSpeechSentence, item)];
                    copyWordSpeech.Remove(item);
                    Console.WriteLine(syntacticSentence);
                }
            }
            speechSentence = copyWordSpeech;
        }

        private void SearchVerbs(List<string> speechSentence)//argument copy of ArrayOfSpeechSentence
        {
            string possibleGroup = "";
            string possibleSentenceGroup = "";
            string result = "";
            int check = 0;
            foreach (string item in speechSentence)
            {
                if (item == "Г" && check < 2)
                {
                    check++;
                    if(check == 2)
                        result = result + wordsSentence[Array.IndexOf(ArrayOfSpeechSentence, item) + 1] + " ";
                    else
                        result = result + wordsSentence[Array.IndexOf(ArrayOfSpeechSentence, item)] + " ";
                    possibleSentenceGroup = possibleSentenceGroup + item;
                    copyWordSpeech.Remove(item);
                }
                if(item == "ПД" || item == "ВГ" && check < 2)
                {
                    check++;
                    result = result + wordsSentence[Array.IndexOf(ArrayOfSpeechSentence, item)] + " ";
                    possibleSentenceGroup = possibleSentenceGroup + item;
                    copyWordSpeech.Remove(item);
                }
            }
            if (possibleSentenceGroup == "ГГ" || possibleSentenceGroup == "ГПД" || possibleSentenceGroup == "ГВГ" || possibleSentenceGroup == "Г")
            {
                possibleGroup = possibleGroup + "ГГ";
                syntacticSentence = syntacticSentence + " ( " + result + ")";
                Console.WriteLine(syntacticSentence);
            }
            speechSentence = copyWordSpeech;
        }

        private void SearchNouns(List<string> speechSentence)
        {
            string possibleGroup = "";
            string possibleSentenceGroup = "";
            string result = "";
            int check = 0;
            foreach (string item in speechSentence)
            {
                if (item == "С" && check < 2)
                {
                    check++;
                    result = result + wordsSentence[Array.IndexOf(ArrayOfSpeechSentence, item)] + " ";
                    possibleSentenceGroup = possibleSentenceGroup + item;
                    copyWordSpeech.Remove(item);
                }
                if (item == "ПР" || item == "ПМ" && check < 2)
                {
                    check++;
                    result = result + wordsSentence[Array.IndexOf(ArrayOfSpeechSentence, item)] + " ";
                    possibleSentenceGroup = possibleSentenceGroup + item;
                    copyWordSpeech.Remove(item);
                }
            }
            if (possibleSentenceGroup == "С" || possibleSentenceGroup == "ПРС" || 
                possibleSentenceGroup == "ПМС" || possibleSentenceGroup == "СС")
            {
                possibleGroup = possibleGroup + "ГС";
                syntacticSentence = syntacticSentence + " ( " + result + ")";
                Console.WriteLine(syntacticSentence);
            }
            speechSentence = copyWordSpeech;
        }
       
    }
}

