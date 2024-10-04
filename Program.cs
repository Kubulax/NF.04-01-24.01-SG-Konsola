using System.Text.RegularExpressions;

namespace Konsolowa2
{
    internal class Program
    {
        static string CheckGender(string pesel)
        {
            if (pesel[9] % 2 == 0)
            {
                return "K";
            }
            else
            {
                return "M";
            }
        }

        static bool ValidatePesel(string pesel) 
        {
            int[] peselDigits = new int[11];
            for (int i = 0; i < 11; i++)
            {
                peselDigits[i] = int.Parse(pesel[i].ToString());
            }

            peselDigits[0] *= 1;
            peselDigits[1] *= 3;
            peselDigits[2] *= 7;
            peselDigits[3] *= 9;
            peselDigits[4] *= 1;
            peselDigits[5] *= 3;
            peselDigits[6] *= 7;
            peselDigits[7] *= 9;
            peselDigits[8] *= 1;
            peselDigits[9] *= 3;

            int S = 0;
            foreach (int digit in peselDigits)
            {
                S += digit;
            }

            int M = S % 10;

            int R = 0;
            if (M != 0)
            {
                R = 10 - M;
            }

            if (peselDigits[10] == R)
            {
                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj numer pesel: ");

            string pesel = "55030101193";

            //string userInputPesel = Console.ReadLine();
            //if (userInputPesel != String.Empty && !string.IsNullOrWhiteSpace(userInputPesel) && userInputPesel.Length != 11)
            //{
            //    pesel = userInputPesel;
            //}

            Console.WriteLine(CheckGender(pesel));

            bool peselIsValid = ValidatePesel(pesel);
            if (peselIsValid)
            {
                Console.WriteLine("Zmienna kontrolna jest poprawna. Wprowadzono poprawny numer pesel.");
            }
            else
            {
                Console.WriteLine("Zmienna kontrolna jest niepoprawna. Wprowadzono niepoprawny numer pesel.");
            }
        }
    }
}
