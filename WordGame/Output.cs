using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    internal class Output
    {
        /// <summary>
        /// E.A.T. 25-August-2024
        /// Output white text.
        /// </summary>
        internal static void Print(string text)
        {
            Console.WriteLine(text);
        }
        ///<summary>
        ///E.A.T. 30-August-2024
        ///Output English or Russian text.
        ///</summary>
        internal static void PrintLanguage(string engText, string rusText, string language, string eng, string rus)
        {
            if (language == eng)
            {
                Print(engText);
            }
            else if (language == rus)
            {
                Print(rusText);
            }
        }
        ///<summary>
        ///E.A.T. 25-August-2024
        ///Output yellow text.
        ///</summary>
        internal static void YellowPrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        ///<summary>
        ///E.A.T. 30-August-2024
        ///Display English or Russian text in yellow.
        ///</summary>
        internal static void YellowPrintLanguage(string engText, string rusText, string language, string eng, string rus)
        {
            if (language == eng)
            {
                YellowPrint(engText);
            }
            else if (language == rus)
            {
                YellowPrint(rusText);
            }
        }
        ///<summary>
        ///E.A.T. 25-August-2024
        ///Output green text.
        ///</summary>
        internal static void GreenPrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        ///<summary>
        ///E.A.T. 30-August-2024
        ///Display English or Russian text in green.
        ///</summary>
        internal static void GreenPrintLanguage(string engText, string rusText, string language, string eng, string rus)
        {
            if (language == eng)
            {
                GreenPrint(engText);
            }
            else if (language == rus)
            {
                GreenPrint(rusText);
            }
        }
        ///<summary>
        ///E.A.T. 25-August-2024
        ///Output blue text.
        ///</summary>
        internal static void BluePrint(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        ///<summary>
        ///E.A.T. 30-August-2024
        ///Display English or Russian text in blue.
        ///</summary>
        internal static void BluePrintLanguage(string engText, string rusText, string language, string eng, string rus)
        {
            if (language == eng)
            {
                BluePrint(engText);
            }
            else if (language == rus)
            {
                BluePrint(rusText);
            }
        }
    }
}
