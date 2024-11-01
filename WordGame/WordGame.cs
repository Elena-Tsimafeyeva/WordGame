using System.Text.Json;
using System.Xml.Linq;
namespace WordGame {
    internal class WordGame
    {
        public static void Main(string[] args)
        {
            //E.A.T. 30-September-2024
            //
            GameLogic gameLogic = new ();
            PlayerFileRepository playerFileRepository = new PlayerFileRepository();
            //E.A.T. 15-August-2024
            //Declared "initialWord", "firstPlayerInput", "secondPlayerInput" variables for inputting the main word and players' words.
            //E.A.T. 22-August-2024
            //Constants "minNumberOfSymbolsInTheMainWord" and "maxNumberOfSymbolsInTheMainWord"to check the length of the main word.
            //E.A.T. 28-August-2024
            //Variable "language" to select the language.
            //Constants "eng" and "rus" for choosing a language.
            //E.A.T. 31-August-2024
            //Variables "mainAlphabet" and "secondAlphabet" for selecting the main and second languages.
            //The variables "english", "russian" contain two alphabets, and the variable "symbolsAndNumbers" contains symbols and numbers.
            //E.A.T. 05-September-2024
            //Variables "firstName" and "secondName" are needed to enter user names.
            string? mainAlphabet = "";
            string? secondAlphabet = "";
            string? firstName = "";
            string? secondName = "";
            string english = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string russian = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string symbolsAndNumbers = "1234567890@#£_&-+()/*':;!?~`|•√π÷×§∆€¥$¢^°={}%©®™✓[]<>,.";
            //E.A.T. 20-September-2024
            //Updating variables language.
            string? language = "";
            const string eng = "1";
            const string rus = "2";
            //E.A.T. 19-September-2024
            //Updating variables initialWord, firstPlayerInput, secondPlayerInput.
            string? initialWord = "";
            string firstPlayerInput = "";
            string secondPlayerInput = "";
            const int minNumberOfSymbolsInTheMainWord = 8;
            const int maxNumberOfSymbolsInTheMainWord = 30;
            int exitTurn = 0;
            bool gameProcess = false;
            //E.A.T. 19-September-2024
            //Variable to continue or end the game.
            bool game = true;
            //E.A.T. 02-September-2024
            //Selecting and installing a language.
            //Displays the selected language.
            //Definition of main and second language.
            Language.SelectingALanguageAndSettingAlphabets(out mainAlphabet,out secondAlphabet, out language, eng, rus, english, russian);
            //E.A.T. 10-October-2024
            //Delete the list of all players.
            PlayerFileRepository.DeleteTheListOfAllPlayers(language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
            //E.A.T. 05-September-2024
            //Entering user names.
            PlayerFileRepository.PlayerNames(out firstName, out secondName, language, eng, rus, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
            //E.A.T. 15-August-2024
            //A method is called to enter the initial word.
            //Checking the main word.
            gameLogic.EnterTheMainWord(out initialWord, language, eng, rus, secondAlphabet, symbolsAndNumbers, game, gameProcess, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);//Ввод первоначального слова
            //E.A.T. 15-August-2024
            //The do-While loop is where the game itself takes place.
            //The "FirstPlayerTextColor" method is called to change the text color for the first player.
            //The "FirstPlayerEnterTheWord" method is called for the first player to enter a word.
            //Called the "Game" method to check the entered word of the first player for compliance with the rules of the game.
            //Checks for user input of incorrect alphabet letters, symbols, or numbers.
            //Called the "SecondPlayerTextColor" method to change the color of the text for the second player.
            //Called the "SecondPlayerEnterTheWord" method for inputting a word by the second player.
            //The "Game" method is called to check the word entered by the second player for compliance with the game rules.
            //Checks for user input of incorrect alphabet letters, symbols, or numbers.
            //E.A.T. 19-September-2024
            //The do-while loop will exit if the game varible is false.
            do{
                gameProcess = true;
                exitTurn = 2;
                GameLogic.FirstPlayerTextColor(initialWord, firstName, language, eng, rus, out string messageInitialWordEng, out string messageInitialWordRus, out string messageEnterWordEng, out string messageEnterWordRus);
                gameLogic.FirstPlayerEnterTheWord(out firstPlayerInput, initialWord, language, eng, rus, firstName, secondName, game, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
                gameLogic.Game(mainAlphabet, initialWord, firstPlayerInput, 2, 1, language, eng, rus, gameProcess, game, secondAlphabet, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);//Проверка слова введёного игроком 1 по отношению к первоначальному слову
                gameLogic.CheckingForIncorrectSymbolsInTheUsersWord(secondAlphabet, symbolsAndNumbers, initialWord, firstPlayerInput, 2, language, eng, rus, gameProcess, game, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
                exitTurn = 1;
                GameLogic.SecondPlayerTextColor(initialWord, secondName, language, eng, rus, out messageInitialWordEng, out messageInitialWordRus, out messageEnterWordEng, out messageEnterWordRus);
                gameLogic.SecondPlayerEnterTheWord(out secondPlayerInput, initialWord, language, eng, rus, firstName, secondName, game, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
                gameLogic.Game(mainAlphabet, initialWord, secondPlayerInput, 1, 1, language, eng, rus, gameProcess, game, secondAlphabet, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);//Проверка слова введёного игроком 2 по отношению к первоначальному слову
                gameLogic.CheckingForIncorrectSymbolsInTheUsersWord(secondAlphabet, symbolsAndNumbers, initialWord, secondPlayerInput, 1, language, eng, rus, gameProcess, game, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
            }while (game == true);
        }
    }
}


