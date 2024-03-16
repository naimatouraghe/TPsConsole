namespace QuizzCapitales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int n1, int n2, int n3) = Quizz.Generer3Numeros();
            Quizz.Jouer(n1, n2, n3);
        }
    }
}
