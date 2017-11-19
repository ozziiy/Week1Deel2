using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            //meerdere vragen, geen grens voor aantal vragen, initializers gebruiken om vragen te vullen bij opstart programma 
            // vragen hebben moei
            IList<Question> questions = new List<Question>() {
            new Question() {MoeilijkHeidsGraad = 2, Categorie = "Algemeen", Vraag = "Wie is die president van Rusland ?", Antwoord = "Putin"},
            new Question() {MoeilijkHeidsGraad = 3, Categorie = "Tech", Vraag = "Wat is de besturingsysteem van een HTC telefoon ?", Antwoord = "Android"},
            new Question() {MoeilijkHeidsGraad = 1, Categorie = "Sport", Vraag = "Waar staat de afkorting MMA voor ?", Antwoord = "Mixed Martial Arts"},
            new Question() {MoeilijkHeidsGraad = 1, Categorie = "Entertainment", Vraag = "Wie zingt 'Mans Not Hot' ? ", Antwoord = "Big Shaq"},
            new Question() {MoeilijkHeidsGraad = 1, Categorie = "Tech", Vraag = "Wat is de besturingsysteem van Apple ? ", Antwoord = "IOS"}


        };

            Console.WriteLine("Orderen bij MoeilijkheidsGraad of Categorie ?");
            String Choice = Console.ReadLine();
            Program program = new Program();

            if (Choice == "MoeilijkheidsGraad")
            {
                var result = questions.OrderBy(d => d.MoeilijkHeidsGraad);

                program.Quiz(result);
            }
            else if (Choice == "Categorie")
            {
              
                var result = questions.OrderBy(d => d.Categorie);
                program.Quiz(result);
            }

            else
            {
                Console.WriteLine("Geef een corecte invoer");
            }




            Console.WriteLine("##### Dit is een nieuwe quiz! #####");

            Console.WriteLine("Selecteren bij moelijkheidsGraad of Categorie ?");
            String Choice2= Console.ReadLine();
            

            if (Choice2 == "MoeilijkheidsGraad")
            {
                Console.WriteLine("kies een Moeilijkheids categorie van 1 t/m 3");
                int MoeilijkheidChoice = Console.Read();

                IEnumerable<Question> result = questions.Where(d => d.MoeilijkHeidsGraad == MoeilijkheidChoice);

                program.Quiz2(result);
            }

            else if (Choice2 == "Categorie")
            {
                Console.WriteLine("Welke categorie wilt u (Algemeen, Tech, Sport, Entertainment)");
                String CategorieChoice = Console.ReadLine();

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
                Console.WriteLine(a.Vraag);
                String input = Console.ReadLine();
                Console.WriteLine(a.checkAnswer(input));
                if (a.checkAnswer(input) == true)
                {
                    VragenGoed++;
                }
                else vragenFout++;
            }

            Console.WriteLine("Aantal vragen goed: " + VragenGoed + " Aantal vragen fout: " + vragenFout);
            Console.ReadKey();
        }

        
        public void Quiz2(IEnumerable<Question> result)
        {
            int VragenGoed = 0;
            int vragenFout = 0;

            foreach (Question a in result)
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

            Console.WriteLine("Aantal vragen goed: " + VragenGoed + " Aantal vragen fout: " + vragenFout);
            Console.ReadKey();
        }


    }
}
