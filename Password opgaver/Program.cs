using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_opgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable
            string Brugernavn = "Admin", Password = "J3gCykl3rDagen&Natt3Lang";

            string BrugerNavnAndPasswordGemIEnFil = $"{Brugernavn},{Password}";

            //Gem password and brugernavn i en fil IO

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"‪C:\Users\diksh\OneDrive\Desktop\Text Document.tx", true))‬‬‬
            //{
            //    file.WriteLine("BrugerNavnAndPasswordGemIEnFil");
            //}

            string Gembrugernavn = "";
            string Pa55word = "";

            // Skrive i en fil
            var BrugernavnPasswordFromfile = "Admin,J3gCykl3rDagen&Natt3Lang";

            //Split password og brugernavn vil adskilt med komma.
            var splittedValues = BrugernavnPasswordFromfile.Split(',');

            // det betyder, at gembrugernavn og password values er et, fordi det er 2 value men split value start fra 0.
            if (splittedValues.Length > 1)
            {
                Gembrugernavn = splittedValues[0];
                Pa55word = splittedValues[1];
            }

            var inputBrugerNavn = GetBrugerNavn();
            var inputPassword = GetPassword();

            // kontroller, at brugernavnet er korrekt eller ej og givet en besked. Så bruger kan ikke gætte fejl mellem password og brugernavn
            var isBrugerCorrect = IsCorrectBrugerNavn(Gembrugernavn, inputBrugerNavn);
            if (!isBrugerCorrect)
            {
                Console.WriteLine("Brugernavn eller password er forkert !");
                inputBrugerNavn = GetBrugerNavn();
                isBrugerCorrect = IsCorrectBrugerNavn(Gembrugernavn, inputBrugerNavn);
                if (!isBrugerCorrect)
                {
                    Console.WriteLine("Brugernavn eller password er forkert angivet!");
                    return;
                }

            }
            // kontroller, at password er korrekt eller ej. 

            var isPasswordCorrect = IsCorrectPassword(Password, inputPassword);
            if (!isPasswordCorrect)
            {
                Console.WriteLine("Brugernavn eller password er forkert !");
                inputPassword = GetPassword();

                isPasswordCorrect = IsCorrectPassword(Password, inputPassword);
                if (isPasswordCorrect)
                {
                    Console.WriteLine("Godkendt Password");
                }
                else
                {
                    Console.WriteLine("Brugernavn eller password er forkert angivet !");
                    return;
                }
            }
            else
            {
                Console.WriteLine("GodKendt Password.");
            }

            //Mulighed til skifte password
            Console.WriteLine("Vil du skifte din password: ja/nej");
            var changePassword = Console.ReadLine();
            if (changePassword == "nej")

            {
                return;
            }

            // Skifte password
            Console.WriteLine("Skrive din ny password");
            var newPassword = Console.ReadLine();

            //  kontroller minimumskriterier for adgangskode 
            bool IsPasswordCorrect = IsValidPassword(newPassword, Pa55word, Gembrugernavn);

            if (IsPasswordCorrect)
            {
                Console.WriteLine("Godkendt password !");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("IKKE GODKENDT password");
                Console.ReadLine();
            }


            Console.ReadLine();
        }
        // Data ind
        public static string GetBrugerNavn()
        {
            Console.WriteLine("Enter brugernavn");
            var inputBrugerNavn = Console.ReadLine();
            return inputBrugerNavn;
        }
        public static string GetPassword()
        {
            Console.WriteLine("Enter password");
            var Password = Console.ReadLine();
            return Password;
        }
        //jeg har lavet forskellig metode for forskellig kriterium, så det kan indstille minimum kriterier for Password and Brugernavn.
        private static bool IsCorrectBrugerNavn(string OprettetBrugerNavn, string angivetBrugerNavn)
        {
            if (String.IsNullOrWhiteSpace(angivetBrugerNavn))
                return false;

            if (OprettetBrugerNavn.ToLower() == angivetBrugerNavn.ToLower())
                return true;
            else
                return false;
        }
        private static bool IsCorrectPassword(string OprettetPassword, string angivetPassword)
        {
            if (string.IsNullOrWhiteSpace(angivetPassword))
                return false;

            if (OprettetPassword.ToLower() == angivetPassword.ToLower())
                return true;
            else
                return false;
        }
        //den metode vil kontroller, vores ny password er møde mimimum kriterier eller gyldig.
        private static bool IsValidPassword(string nyPasskode, string gammelPasskode, string brugerNavn)
        {


            if (String.IsNullOrWhiteSpace(nyPasskode))
                return false;

            if (IsSameAsBrugerNavn(nyPasskode, brugerNavn))
                return false;

            if (IsSameAsOldPassword(nyPasskode, gammelPasskode))
                return false;

            if (!CheckForNumber(nyPasskode))
                return false;

            if (!CheckForUpCaseLetter(nyPasskode))
                return false;

            if (!CheckForSpecialTegn(nyPasskode))
                return false;

            if (IsContainsSpace(nyPasskode))
                return false;

            if (ContainsNumberAtStartAndEnd(nyPasskode))
                return false;

            return true;
        }
        public static bool IsSameAsBrugerNavn(string Password1, string Brugernavn)
        {
            if (Password1.ToLower() == Brugernavn.ToLower())
                return true;
            else
                return false;
        }
        private bool CheckMinimunLength(string Password)
        {
            if (Password.Length >= 12) return true;

            return false;
        }
        private static bool CheckForLowerCaseLetter(string Password)
        {
            foreach (char c in Password)
            {
                if (char.IsLower(c) == true)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool CheckForUpCaseLetter(string Password)
        {
            foreach (char c in Password)
            {
                if (char.IsUpper(c) == true)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool CheckForNumber(string Password)
        {
            return Password.Any(N => char.IsNumber(N));

        }
        private static bool CheckForSpecialTegn(string password)
        {
            if (password.Any(chr => !char.IsLetterOrDigit(chr)))
                return true;
            else
                return false; ;
        }
        public static bool ContainsNumberAtStartAndEnd(string Password)
        {
            var firstChar = Password.FirstOrDefault();
            var endChar = Password.LastOrDefault();

            if (char.IsNumber(firstChar) || char.IsNumber(endChar))
                return true;
            else
                return false;
        }
        public static bool IsContainsSpace(string Password)
        {
            if (Password.Any(chr => char.IsWhiteSpace(chr)))
                return true;
            else
                return false;
        }
        public static bool IsSameAsOldPassword(string newpassword, string oldpassword)
        {
            if (newpassword.ToLower() == oldpassword.ToLower())
                return true;
            else
                return false;
        }
    }
}

