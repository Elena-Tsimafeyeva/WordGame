using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    internal class Language
    {
        ///<summary>
        ///E.A.T. 28-August-2024
        ///Until the language is selected, "LanguageBool" will be equal to "true".
        ///After selecting the language, "LanguageBool" will be equal to "false" and the for-while loop will end.
        ///</summary>
        internal static void LanguageBool(string? language, string eng, string rus, out bool languageBool)
        {
            languageBool = true;
            if (language == eng || language == rus)
            {
                languageBool = false;
            }
        }
        ///<summary>
        ///E.A.T. 28-August-2024
        ///Selecting and installing a language.
        ///Variable "languageBool" for the for-while loop. As long as "languageBool=true",
        ///the loop will continue. After selecting 1 or 2, "languageBool" will be false.
        ///</summary>
        internal static void Languages(out string? language, string eng, string rus)
        {
            bool languageBool = true;
            do
            {
                Output.Print("Выберите Язык | Select Language\nАнглийский язык - 1, Русский язык - 2\nEnglish - 1, Russian - 2");
                Input.Read(out language);
                LanguageBool(language, eng, rus, out languageBool);
            } while (languageBool == true);
        }
        ///<summary>
        ///E.A.T. 28-August-2024
        ///Displays the selected language.
        ///</summary>
        internal static void YourChosenLanguage(string language, string eng, string rus)
        {
            Output.YellowPrintLanguage("Your selected language: English.", "Ваш выбранный язык: Русский.", language, eng, rus);
        }
        ///<summary>
        ///E.A.T. 31-August-2024
        ///Setting the main and second languages ​​depending on the value of the "language" variable.
        ///</summary>
        internal static void Alphabet(out string? mainAlphabet, out string? secondAlphabet, string language, string eng, string rus, string english, string russian)
        {
            mainAlphabet = null;
            secondAlphabet = null;
            if (language == eng)
            {
                mainAlphabet = english;
                secondAlphabet = russian;
            }
            else if (language == rus)
            {
                mainAlphabet = russian;
                secondAlphabet = english;
            }
        }
        ///<summary>
        ///E.A.T. 02-September-2024
        ///Selecting and installing a language.
        ///Displays the selected language.
        ///Definition of main and second language.
        ///</summary>
        internal static void SelectingALanguageAndSettingAlphabets(out string? mainAlphabet, out string? secondAlphabet, out string? language, string eng, string rus, string english, string russian)
        {
            Languages(out language, eng, rus);
            YourChosenLanguage(language, eng, rus);
            Alphabet(out mainAlphabet, out secondAlphabet, language, eng, rus, english, russian);
        }
    }
}
