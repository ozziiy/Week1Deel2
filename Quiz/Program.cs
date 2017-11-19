using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //initialiseren 
            IList<Question> questions = new List<Question>() {
            new Question() {MoeilijkHeidsGraad = 2, Categorie = "Algemeen", Vraag = "Wie is die president van Rusland ?", Antwoord = "Putin"},
            new Question() {MoeilijkHeidsGraad = 3, Categorie = "Tech", Vraag = "Wat is de besturingsysteem van een HTC telefoon ?", Antwoord = "Android"},
            new Question() {MoeilijkHeidsGraad = 1, Categorie = "Sport", Vraag = "Waar staat de afkorting MMA voor ?", Antwoord = "Mixed Martial Arts"},
            new Question() {MoeilijkHeidsGraad = 1, Categorie = "Entertainment", Vraag = "Wie zingt 'Mans Not Hot' ? ", Antwoord = "Big Shaq"},
            new Question() {MoeilijkHeidsGraad = 1, Categorie = "Tech", Vraag = "Wat is de besturingsysteem van Apple ? ", Antwoord = "IOS"},

            new Question() {MoeilijkHeidsGraad = 2, Categorie = "Sport", Vraag = "Waar staat de afkorting UFC voor ?",Antwoorden = { "Ultimate Frighters Competition", "Ultimate Fighting Championship", "Ultra face Chickens", "Ultra Fighters Cage" },
                choicequestion = new ChoiceQuestion(){ correctAntwoord = "Ultimate Fighting Championship"}},
            new Question() { MoeilijkHeidsGraad = 2, Categorie = "Tech", Vraag = "Wie is de owner van Microsoft ?",Antwoorden = { "Tarzan","Jane", "Bill Gates", "Bill Murphy" },
                choicequestion = new ChoiceQuestion(){ correctAntwoord = "Bill Gates"}},
            new Question() { MoeilijkHeidsGraad = 3, Categorie = "Entertainment", Vraag = "Wie is de goeie vriend van Big Shaq?",Antwoorden = { "Virgil","Aszknee", "Frisbee", "Homie" },
                choicequestion = new ChoiceQuestion(){ correctAntwoord = "Aszknee"}}

            


        };
            //Gebruik LINQ om de vragen te sorteren van gemakkelijk naar moeilijk of op category. Maak hiervoor gebruik van het keyword var
            Console.WriteLine("Orderen bij MoeilijkheidsGraad(1) of Categorie(2) ?");
            String Choice = Console.ReadLine();
            Program program = new Program();

            if (Choice == "1")
            {
                //met var
                var result = questions.OrderBy(d => d.MoeilijkHeidsGraad);
                

                program.Quiz(result);
            }
            else if (Choice == "2")
            {
                //met var
                var result = questions.OrderBy(d => d.Categorie);
                program.Quiz(result);
            }

            else
            {
                Console.WriteLine("Geef een corecte invoer");
            }


           
            //Gebruik LINQ om alleen de vragen te stellen van een bepaalde moeilijkheidsgraad of op category. Maak hiervoor GEEN gebruik van het keyword var
            Console.WriteLine("##### Dit is een nieuwe quiz! #####");
            
            Console.WriteLine("Selecteren bij moelijkheidsGraad(1) of Categorie(2) ?");
            String Choice2= Console.ReadLine();
            

            if (Choice2 == "1")
            {
                Console.WriteLine("kies een MoeilijkheidsGraad categorie van 1 t/m 3");
                String MoeilijkheidChoice = Console.ReadLine();
                int MoeilijkheidChoiceInt = Int32.Parse(MoeilijkheidChoice);

                Console.WriteLine(MoeilijkheidChoice);
                //zonder var
                IEnumerable<Question> result = questions.Where(d => d.MoeilijkHeidsGraad == MoeilijkheidChoiceInt);

                program.Quiz2(result);
            }

            else if (Choice2 == "2")
            {
                Console.WriteLine("Welke categorie wilt u (Algemeen, Tech, Sport, Entertainment)");
                String CategorieChoice = Console.ReadLine();
                //zonder var
                IEnumerable<Question> result = questions.Where(d => d.Categorie == CategorieChoice);
                program.Quiz2(result);
            }

            else
            {
                Console.WriteLine("Geef een corecte invoer");
            }

           

            Console.ReadKey();
        }
        public void Quiz(IEnumerable<Question> result)
        {
            int VragenGoed = 0;
            int vragenFout = 0;

            foreach (var a in result)
            {

                if (a.choicequestion != null)
                {

                    Console.WriteLine(a.Vraag);
                    a.GetChoiceQuestions();
                    var answer = Console.ReadLine();
                    int getal = Int32.Parse(answer);
                    
                    Console.WriteLine(a.checkChoiceAnswer(getal));
                    if (a.checkChoiceAnswer(getal) == true)
                    {
                        
                        VragenGoed++;
                    }
                    else
                    {
                        
                        vragenFout++;
                    }
                       
                 
                }
                else{

                     Console.WriteLine(a.Vraag);
                    String input = Console.ReadLine();
                    Console.WriteLine(a.checkAnswer(input));
                    if (a.checkAnswer(input) == true)
                    {
                        VragenGoed++;
                    }
                    else vragenFout++;
                }
            }

            Console.WriteLine("Aantal vragen goed: " + VragenGoed + " Aantal vragen fout: " + vragenFout);
            Console.ReadKey();
        }

        // deze methode is duplicate dit heb ik alleen gedaan voor de opdracht. Namelijk LINQ toepassen zonder var te gebruiken.
        public void Quiz2(IEnumerable<Question> result)
        {
            int VragenGoed = 0;
            int vragenFout = 0;

            foreach (Question a in result)
            {
                if (a.choicequestion != null)
                {

                    Console.WriteLine(a.Vraag);
                    a.GetChoiceQuestions();
                    String answer = Console.ReadLine();
                    int getal = Int32.Parse(answer);

                    Console.WriteLine(a.checkChoiceAnswer(getal));
                    if (a.checkChoiceAnswer(getal) == true)
                    {

                        VragenGoed++;
                    }
                    else
                    {

                        vragenFout++;
                    }


                }
                else
                {
                    Console.WriteLine(a.Vraag);
                    String input = Console.ReadLine();
                    Console.WriteLine(a.checkAnswer(input));
                    if (a.checkAnswer(input) == true)
                    {
                        VragenGoed++;
                    }
                    else vragenFout++;
                }
            }

            Console.WriteLine("Aantal vragen goed: " + VragenGoed + " Aantal vragen fout: " + vragenFout);
            Console.ReadKey();
        }
        
        

    }
}
