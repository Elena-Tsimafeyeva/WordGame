using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordGame
{
    internal class GameLogic
    {
        ///<summary>
        ///E.A.T. 15-August-2024
        ///Display the rules on the screen.
        ///Input the main word.
        ///E.A.T. 20-September-2024
        ///While you are typing your main word, you can enter a command.
        ///</summary>
        internal void EnterTheMainWord(out string? initialWord, string language, string eng, string rus, string secondAlphabet, string symbolsAndNumbers, bool game, bool gameProcess, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, string firstName, string secondName, int exitTurn)
        {
            initialWord = null;
            Output.PrintLanguage("Rules: The essence of the game is for 2 users to alternately enter words consisting\nof the letters of the initially specified word. The one who does not enter the word in turn loses.", "Правила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово.", language, eng, rus);
            Output.YellowPrintLanguage("Enter the first word to start the game (from 8 to 30 characters)", "Введите первое слово для начала игры (от 8 до 30 символов)", language, eng, rus);
            GameCommandsManager.ListOfCommands(out initialWord, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);//Ввод первоначального слова
            CheckingForIncorrectSymbolsInTheMainWord(initialWord, secondAlphabet, symbolsAndNumbers, game, gameProcess, language, eng, rus, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);//Проверка первоначального слова на верные символы
            CheckTheMainWord(initialWord, language, eng, rus, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, game, gameProcess, secondAlphabet, symbolsAndNumbers, firstName, secondName, exitTurn);//Проверка первоначального слова на кол-во символов
        }
        ///<summary>
        ///E.A.T. 02-September-2024
        ///Compare the main word with the selected alphabet or symbols and numbers.
        ///</summary>
        internal void CheckingForIncorrectSymbolsInTheMainWord(string initialWord, string secondAlphabet, string symbolsAndNumbers, bool game, bool gameProcess, string language, string eng, string rus, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, string firstName, string secondName, int exitTurn)
        {
            CheckingTheSymbolsOfTheMainWord(secondAlphabet, initialWord, 1, game, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
            CheckingTheSymbolsOfTheMainWord(symbolsAndNumbers, initialWord, 2, game, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
        }
        ///<summary>
        ///E.A.T. 02-September-2024
        ///Checking the base word for alphabets, symbols and numbers
        ///</summary>
        internal void CheckingTheSymbolsOfTheMainWord(string symbols, string initialWord, int check, bool game, string language, string eng, string rus, bool gameProcess, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, string firstName, string secondName, int exitTurn)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                for (int j = 0; j < initialWord.Length; j++)
                {
                    if (symbols[i] == initialWord[j])
                    {
                        ErrorMessageToCheckTheMainWord(check, language, eng, rus);
                        End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
                    }
                }
            }
        }
        ///<summary>
        ///E.A.T. 02-September-2024
        ///Messages about entering incorrect letters or symbols and numbers.
        ///</summary>
        internal static void ErrorMessageToCheckTheMainWord(int check, string language, string eng, string rus)
        {
            switch (check)
            {
                case 1:
                    Output.YellowPrintLanguage("When entering the main word, you used letters of the Russian alphabet, not English.", "При вводе главного слова вы использовали буквы английского алфавита, а не русского.", language, eng, rus);
                    break;
                case 2:
                    Output.YellowPrintLanguage("You used symbols or numbers when entering the main word.", "При вводе главного слова вы использовали символы или цифры.", language, eng, rus);
                    break;
            }
        }
        ///<summary>
        ///E.A.T. 15-August-2024
        ///Checking the main word.
        ///If the length of the main word matches the rules, the game starts.
        ///Otherwise, the game ends with the appropriate message.
        ///</summary>
        internal void CheckTheMainWord(string? initialWord, string language, string eng, string rus, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, bool game, bool gameProcess, string secondAlphabet, string symbolsAndNumbers, string firstName, string secondName, int exitTurn)
        {
            int numberOfSymbolsInTheMainWord = initialWord.Length;
            bool requiredNumberOfSymbolsInTheMainWord = ((minNumberOfSymbolsInTheMainWord <= numberOfSymbolsInTheMainWord) & (numberOfSymbolsInTheMainWord <= maxNumberOfSymbolsInTheMainWord)); //Длина первоначально вводимого слова – от 8 до 30 символов
            if (requiredNumberOfSymbolsInTheMainWord == true)
            {
                Output.PrintLanguage("Have a nice game!", "Хорошей игры!", language, eng, rus);
            }
            else
            {
                Output.PrintLanguage("A word has been entered with an incorrect number of characters or an incorrect value has been entered", "Введено слово с неверным кол-вом символов или введено неверное значение", language, eng, rus);
                End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
            }
        }
        ///<summary>
        ///E.A.T. 15-August-2024
        ///If the player entered nothing, the game ends.
        ///If the player has entered a word, the word check starts.
        /// The "ChekTheEnteredWordAgainstTheMainWord" method is used to check the entered words.
        ///</summary>
        internal void Game(string symbols, string? initialWord, string? playerInput, int turn, int check, string language, string eng, string rus, bool gameProcess, bool game, string secondAlphabet, string symbolsAndNumbers, string firstName, string secondName, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, int exitTurn)//Проверка слова введёного игроком по отношению к первоначальному слову
        {
            if (playerInput.Length == 0)//Проверка ввёл ли игрок слово
            {
                Output.YellowPrintLanguage($"You have not entered anything :(\nGame over! Player {turn} wins!", $"Вы ничего не ввели :(\nИгра окончена! Победил игрок {turn}!", language, eng, rus);
                PlayerFileRepository.EditingWinsAndLosses(turn, firstName, secondName);
                End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
            }
            else //Если игрок ввёл слово
            {
                ChekTheEnteredWordAgainstTheMainWord(symbols, initialWord, playerInput, turn, check, language, eng, rus, gameProcess, game, secondAlphabet, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
            }
        }
        ///<summary>
        ///E.A.T. 15-August-2024
        ///Comparing the symbols in the player's word to the main word.
        ///The "ChekingSymbolsInAWord" method is used to determine the number of symbols in the player's word and in the main word.
        ///</summary>
        internal void ChekTheEnteredWordAgainstTheMainWord(string symbols, string? initialWord, string? playerInput, int turn, int check, string language, string eng, string rus, bool gameProcess, bool game, string secondAlphabet, string symbolsAndNumbers, string firstName, string secondName, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, int exitTurn)
        {
            int letterCounterForMainWord = 0;
            int letterCounterForUserWord = 0;
            for (int i = 0; i < symbols.Length; i++)//Проверка введённого слова по отношению первоначальному слову
            {
                if (i != 0)
                {
                    if (letterCounterForMainWord < letterCounterForUserWord)//Если слово введённое игроком не соответствует по символам главному слову, то игра заканчивается. 
                    {
                        ErrorMessagesInTheGameMethod(check, turn, language, eng, rus);
                        PlayerFileRepository.EditingWinsAndLosses(turn, firstName, secondName);
                        End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
                    }
                }
                ChekingSymbolsInAWord(symbols, initialWord, playerInput, i, out letterCounterForMainWord, out letterCounterForUserWord);
            }
        }
        ///<summary>
        ///E.A.T. 15-August-2024
        ///Determining the number of symbols in the player's word and in the main word.
        ///</summary>
        internal void ChekingSymbolsInAWord(string symbols, string? initialWord, string? playerInput, int i, out int letterCounterForMainWord, out int letterCounterForUserWord)
        {
            letterCounterForMainWord = 0;
            letterCounterForUserWord = 0;
            for (int j = 0; j < initialWord.Length; j++)
            {
                if (symbols[i] == initialWord[j])
                {
                    letterCounterForMainWord++;
                }
            }
            for (int j = 0; j < playerInput.Length; j++)
            {
                if (symbols[i] == playerInput[j])
                {
                    letterCounterForUserWord++;
                }
            }
        }
        ///<summary>
        ///E.A.T. 31-August-2024
        ///Checks for user input of incorrect alphabet letters, symbols, or numbers.
        ///</summary>
        internal void CheckingForIncorrectSymbolsInTheUsersWord(string secondAlphabet, string symbols, string? initialWord, string? playerInput, int turn, string language, string eng, string rus, bool gameProcess, bool game, string symbolsAndNumbers, string firstName, string secondName, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, int exitTurn)
        {
            Game(secondAlphabet, initialWord, playerInput, turn, 2, language, eng, rus, gameProcess, game, secondAlphabet, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
            Game(symbols, initialWord, playerInput, turn, 3, language, eng, rus, gameProcess, game, secondAlphabet, symbolsAndNumbers, firstName, secondName, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
        }
        ///<summary>
        ///E.A.T. 31-August-2024
        ///Error messages in method "Game".
        ///</summary>
        internal static void ErrorMessagesInTheGameMethod(int check, int turn, string language, string eng, string rus)
        {
            switch (check)
            {
                case 1:
                    Output.YellowPrintLanguage($"Game over! Player {turn} wins!", $"Игра окончена! Победил игрок {turn}!", language, eng, rus);
                    break;
                case 2:
                    Output.YellowPrintLanguage($"You entered letters from the Russian alphabet, not English.\nGame over! Player {turn} wins!", $"Вы ввели буквы из английского алфавита, а не русского.\nИгра окончена! Победил игрок {turn}!", language, eng, rus);
                    break;
                case 3:
                    Output.YellowPrintLanguage($"You have entered characters or numbers.\nGame over! Player {turn} wins!", $"Вы ввели символы или цифры.\nИгра окончена! Победил игрок {turn}!", language, eng, rus);
                    break;
            }
        }
        ///<summary>
        ///E.A.T. 15-August-2024
        ///A 15-second timer is started for the first player.
        ///If the first player does not have time to enter the word, the timer will call the "FirstTime" method to end the game.
        ///If the first player manages to enter the word in 15 seconds, the timer will turn off.
        ///E.A.T. 20-September-2024
        ///
        ///</summary>
        internal void FirstPlayerEnterTheWord(out string? firstPlayerInput, string initialWord, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, int exitTurn)
        {
            TimerCallback tm = new TimerCallback(FirstTime); //Таймер на 15 сек
            Timer timer = new Timer(tm, null, 15000, 0);
            GameCommandsManager.ListOfCommands(out firstPlayerInput, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord); //Ввод слова игроком 1
            timer.Dispose();//Отключение таймера
            PlayerFileRepository.CheckForWordRepetition(firstPlayerInput, 2, language, eng, rus, firstName, secondName, game, gameProcess, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
            PlayerFileRepository.RecordingWords(firstPlayerInput);
            ///<summary>
            ///E.A.T. 15-August-2024
            ///The game ends if the first player fails to enter within 15 seconds.
            ///</summary>
            void FirstTime(object? obj)//Если игрок 1 не успел ввести слово за 15 сек
            {
                Output.YellowPrintLanguage("You didn't have time! Player 2 wins!", "Вы не успели! Победил игрок 2!", language, eng, rus);
                PlayerFileRepository.EditingWinsAndLosses(2, firstName, secondName);
                End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
            }
        }
        ///<summary>
        ///E.A.T. 15-August-2024
        ///A timer for 15 seconds is started for the second player.
        ///If the second player does not have time to enter the word, the timer will call the "SecondTime" method to end the game.
        ///If the second player manages to enter the word in 15 seconds, the timer will turn off.
        ///E.A.T. 20-September-2024
        ///
        ///</summary>
        internal void SecondPlayerEnterTheWord(out string? secondPlayerInput, string initialWord, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, int exitTurn)
        {
            TimerCallback tm1 = new TimerCallback(SecondTime); //Таймер на 15 сек
            Timer timer1 = new Timer(tm1, null, 15000, 0);
            GameCommandsManager.ListOfCommands(out secondPlayerInput, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord); //Ввод слова игроком 2
            timer1.Dispose();//Отключение таймера
            PlayerFileRepository.CheckForWordRepetition(secondPlayerInput, 1, language, eng, rus, firstName, secondName, game, gameProcess, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, exitTurn);
            PlayerFileRepository.RecordingWords(secondPlayerInput);
            ///<summary>
            ///E.A.T. 15-August-2024
            ///The game ends if the second player fails to enter within 15 seconds.
            ///</summary>
            void SecondTime(object? obj)//Если игрок 2 не успел ввести слово за 15 сек
            {
                Output.YellowPrintLanguage("You didn't have time! Player 1 wins!", "Вы не успели! Победил игрок 1!", language, eng, rus);
                PlayerFileRepository.EditingWinsAndLosses(1, firstName, secondName);
                End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
            }
        }
 
        
        /// <summary>
        /// E.A.T. 12-August-2024
        /// Change the text color for the first player to green. 
        /// </summary>
        internal static void FirstPlayerTextColor(string initialWord, string firstName, string language, string eng, string rus)
        {
            Output.PrintLanguage($"Your initial word: {initialWord}", $"Ваше изначальное слово: {initialWord}", language, eng, rus);
            Output.GreenPrintLanguage($"Player 1 | {firstName} | Enter your word! You have 15 seconds", $"Игрок 1 | {firstName} | Введите ваше слово! У вас 15 сек", language, eng, rus);
        }
        /// <summary>
        /// E.A.T. 12-August-2024
        /// Change the text color for the second player to blue. 
        /// </summary>
        internal static void SecondPlayerTextColor(string initialWord, string secondName, string language, string eng, string rus)
        {
            Output.PrintLanguage($"Your initial word: {initialWord}", $"Ваше изначальное слово: {initialWord}", language, eng, rus);
            Output.BluePrintLanguage($"Player 2 | {secondName} | Enter your word! You have 15 seconds", $"Игрок 2 | {secondName} | Введите ваше слово! У вас 15 сек", language, eng, rus);
        }
        ///<summary>
        ///E.A.T. 19-September-2024
        ///If the game ends, users can choose whether they want to play another round or end the game.
        ///E.A.T. 20-September-2024
        ///You can enter commands while you enter your selection.
        ///</summary>
        internal void End(out bool game, string initialWord, string language, string eng, string rus, bool gameProcess, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, string firstName, string secondName, int exitTurn)
        {
            gameProcess = false;
            Output.PrintLanguage("Do you want to play again?\n1 - Yes, 2 - No", "Вы хотите сыграть ещё раз?\n1 - Да, 2 - Нет", language, eng, rus);
            game = false;
            bool endBool = true;
            do
            {
                string? answer;
                GameCommandsManager.ListOfCommands(out answer, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
                if (answer == "1")
                {
                    Output.YellowPrintLanguage("Next round!", "Следующий раунд!", language, eng, rus);
                    game = true;
                    endBool = false;
                    PlayerFileRepository.DeleteFile("words.json", language, eng, rus);
                    EnterTheMainWord(out initialWord, language, eng, rus, secondAlphabet, symbolsAndNumbers, game, gameProcess, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
                }
                else if (answer == "2")
                {
                    Output.YellowPrintLanguage("Game over!", "Игра завершена!", language, eng, rus);
                    PlayerFileRepository.DeleteFile("words.json", language, eng, rus);
                    Environment.Exit(0);
                }
            } while (endBool == true);
        }
    }
}
