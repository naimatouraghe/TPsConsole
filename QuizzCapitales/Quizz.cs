using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzCapitales
{
    /// <summary>
    /// Fournit des fonctions pour un jeux de type quizz 
    /// </summary>
    internal class Quizz
    {
        static string[] pays = { "Italie", "France", "Belgique", "Allemagne" };
        static string[] capitales = { "Rome", "Paris", "Bruxelles", "Berlin" };

        /// <summary>
        /// 
        /// </summary>
        public static void Jouer()
        {
            bool continuer = true;

            while (continuer)
            {

                int? bonnesRep = 0;

                for (int i = 0; i < pays.Length; i++)
                {
                    if (PoserQuestion(i))
                    {
                        bonnesRep++;
                    } 
                }

                Console.WriteLine($"\n{bonnesRep} bonnes réponses!");
                continuer = DemanderSiRejouer();
               
            }
        }


        /// <summary>
        /// Embarque un tablea de nombre de type params
        /// </summary>
        /// <param name="numQuestions">les nombres à analyser</param>
        public static void Jouer(params int[] numQuestions )
        {
            bool continuer = true;
            while (continuer)
            {
                int bonnesRep = 0;
                foreach (int num in numQuestions)
                {
                    if (num>0 && num<=pays.Length && PoserQuestion(num))
                    {
                        bonnesRep++;
                    } 
                }
                Console.WriteLine($"\n{bonnesRep} bonnes réponses!");
                continuer = DemanderSiRejouer();
            }
        }

        public static (int, int, int) Generer3Numeros()
        {
            (int n1, int n2, int n3) numeros;
            Random rand = new Random();
            numeros.n1 = rand.Next(1, 11);
            numeros.n2 = rand.Next(2, 11);
            numeros.n3 = rand.Next(3, 11);
            return numeros;
        }

        static int SaisirNombre(int min, int max)
        {
            Console.WriteLine($"Saisir un nombre compris entre {min} et {max}:");
            bool repOk;
            int num;
            do {
                string? rep = Console.ReadLine();
                repOk = int.TryParse(rep, out num) && num >= min && num <= max; 
            } while (!repOk);
            return num;
        }
        static bool PoserQuestion(int nbQuestion)
        {
            Console.WriteLine($"\nQuelle est la capitale du pays suivant: {pays[nbQuestion]} ?");
            string? rep = Console.ReadLine();

            if (rep == capitales[nbQuestion])
            {
                Console.WriteLine("Bravo!");
                return true;
            }
            else
            {
                Console.WriteLine($"Mauvaise réponse! La réponse était : {capitales[nbQuestion]}");
                return false;
            }
      
        }

        static bool DemanderSiRejouer()
        {
            Console.WriteLine("\nSouhaitez vous rejouer (O/N) ?");
            string? rep2 = Console.ReadLine();

            if (rep2 == "O" || rep2 == "o")
            {
                Console.Clear();
                return true;
            }
            else
            {
          
                Console.WriteLine("\nMerci d'avoir joué!");
                return false;   
            }
        }
    }
}
    

