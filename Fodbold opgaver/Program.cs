using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fodbold_opgaver
{
    class Program
    {
        static void Main(string[] args)
            {
                // erklaring af varibale
                int afleveringer;
                string mål;
                string result = string.Empty;

                // Data ind
                Console.WriteLine("Antal afleveringer i kæmpe:   ");
                afleveringer = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Hvis der er mål så skriver mål:");
                mål = Console.ReadLine().ToLower();
                //if (mål == "Ja")
                //    Console.WriteLine("Ja");

                // Data ud
                var output = WeCheerGoalOrPasses(mål, afleveringer);
                Console.WriteLine(output);

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();

            }
            // Metoder og kondition for afleveringer og mål
            public static string WeCheerGoalOrPasses(string mål, int afleveringer)
            {
                var result = WeCheerIfGoal(mål);
                if (result == string.Empty)
                    result = HowHappyWeAreAboutThePass(afleveringer);
                return result;
            }
            public static string HowHappyWeAreAboutThePass(int afleveringer)
            {
                var res = string.Empty;
                if (afleveringer < 1)
                    res = "shh";
                else if (afleveringer > 0 && afleveringer < 10)
                {

                    int i = 0;
                    while (i < afleveringer)
                    {
                        res += "Huh! ";
                        i++;
                    }
                }
                else
                    res = "High Five- Jubel!!";
                return res.TrimEnd();
            }
            public static string WeCheerIfGoal(string mål)
            {
                return (mål.ToLower() == "mål") ? "Ole Ole Ole" : String.Empty;

            }
        }
    }


