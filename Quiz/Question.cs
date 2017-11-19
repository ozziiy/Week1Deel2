using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public class Question
    {
        public int MoeilijkHeidsGraad { get; set; }
        public String Categorie { get; set; }
        public String Vraag { get; set; }
        public String Antwoord { get; set; }
        public int VragenGoed { get; set; }
        public int VragenFout { get; set; }

        public Boolean checkAnswer(String input)
        {


            if (input == Antwoord)
            {
                VragenGoed++;

                return true;
            }

            
            else
                VragenFout++;
            return false;
        }


    }
}
