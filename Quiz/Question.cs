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
        
        public ChoiceQuestion choicequestion { get; set; }
        public List<String> Antwoorden = new List<String>();

        public Boolean checkAnswer(String input)
        {
            if (input == Antwoord)
            {

                return true;
            }

             else
                
            return false;
        }

        public Boolean checkChoiceAnswer(int getal)
        {

            int Antwoord = Antwoorden.IndexOf(CorrecteAntwoord());
            
            if (getal == Antwoord)
            {
                return true;
            }

            else return false;
            

        }

        public void GetChoiceQuestions()
        {
            
            foreach (var i in Antwoorden)
            {
                Console.WriteLine(Antwoorden.IndexOf(i) + " "+i);
                
            }
           
        }

        public String CorrecteAntwoord()
        {
            return choicequestion.correctAntwoord;
        }

       



    }
}
