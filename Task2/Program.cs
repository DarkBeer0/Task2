using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            var text = File.ReadLines("text.txt", Encoding.Default).SelectMany(n => n.ToCharArray());
            Console.WriteLine("Napisz '+' aby posortować Alfabetycznie / Napisz '-' aby posortować według wartości.");
            string? quest = Console.ReadLine();

            if (quest.Equals("+"))
            {
                text = text.OrderBy(s => s);
                Console.WriteLine();
                int length = 0;
                foreach (char ch in text.Where(Char.IsLetter))
                    length++;

                Console.WriteLine();

                Console.WriteLine("Wyświetlamy wszystkie różne znaki zawarte w pliku tekstowym. I ich liczba.");
                Console.WriteLine("Plik zawiera znaki :");
                foreach (var ch in text.Where(Char.IsLetter).GroupBy(n => n, (k, n) => new { result = k + " - " + n.Count() + " ~" + (Math.Round(((double)n.Count() / length * 100), 1)) + "%" }))
                {
                    Console.WriteLine(ch.result);
                }
            }
            else if (quest.Equals("-"))
            {
                Console.WriteLine();
                int textlength = 0;
                foreach (char ch in text.Where(Char.IsLetter))
                    textlength++;

                Console.WriteLine();

                Console.WriteLine("Wyświetlamy wszystkie różne znaki zawarte w pliku tekstowym. I ich liczba.");
                Console.WriteLine("Plik zawiera znaki :");
                var x = text.Where(Char.IsLetter).GroupBy(n => n, (k, n) => n).OrderByDescending(n => n.Count());

                foreach (var ch in x)
                {
                    var z = ch.ToArray();
                    Console.WriteLine(z[0] + " - " + z.Length + " ~" + (Math.Round(((double)z.Length / textlength * 100), 1) + "%"));
                }
            }
            else
            {
                Console.WriteLine("Nie wybrałeś żadnej z opcji, lista nie zostanie posortowana.");

                Console.WriteLine();
                int length = 0;
                foreach (char ch in text.Where(Char.IsLetter))
                    length++;

                Console.WriteLine();

                Console.WriteLine("Wyświetlamy wszystkie różne znaki zawarte w pliku tekstowym. I ich liczba.");
                Console.WriteLine("Plik zawiera znaki :");
                foreach (var ch in text.Where(Char.IsLetter).GroupBy(n => n, (k, n) => new { result = k + " - " + n.Count() + " ~" + (Math.Round(((double)n.Count() / length * 100), 1)) + "%" }))
                {
                    Console.WriteLine(ch.result);
                }
            }
        }

    }
}
