using ExpressionReg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intellect.Main
{
    public class Scanner
    {
        private string sentence;
        private RegularExpresion regularExpresion = new RegularExpresion();

        public Scanner (string sentence)
        {
            string newSentence = sentence.Trim();
            this.sentence = regularExpresion.ReplaceSentence(newSentence, "\\s+", " ");
        }

        public override string ToString()
        {
            
            return "Вопрос : " + this.sentence;
        }
    }
}
