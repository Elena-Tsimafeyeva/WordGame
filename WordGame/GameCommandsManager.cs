﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    internal class GameCommandsManager
    {
        ///<summary>
        ///E.A.T. 19-September-2024
        ///The method accepts commands during the game.
        ///</summary>

        internal static void ListOfCommands(out string? commandOrWord, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, int exitTurn, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord)
        {
            bool boolCommands = true;
            do
            {
                Input.Read(out commandOrWord);
                List<string> listOfCommands = new List<string>() { "/help", "/show-words", "/score", "/total-score", "/exit" };
                if (commandOrWord == null)
                {
                    boolCommands = false;
                }
                else if (listOfCommands.Contains(commandOrWord))
                {
                    Commands(commandOrWord, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
                }
                else
                {
                    boolCommands = false;
                }
            } while (boolCommands == true);
        }
        ///<summary>
        ///E.A.T. 19-September-2024
        ///This method calls the written commands.
        ///E.A.T. 23-September-2024
        ///show-words displays a list of words.
        ///</summary>
        internal static void Commands(string command, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, int exitTurn, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord)
        {
            switch (command)
            {
                case "/help":
                    Output.YellowPrintLanguage("List of commands:\n/help - show the entire list of commands.\n/show-words – show all words entered by both users in the current game.\n/score – show the total game score for current players (extract from file).\n/total-score – show the total score for all players.\n/exit - end of the round (defeat is counted to the player who had to enter\na word at the moment of exiting the round).", "Список команд:\n/help - показать весь список команд.\n/show-words - показать все введенные обоими пользователями слова в текущей игре.\n/score - показать общий счет по играм для текущих игроков (извлечь из файла).\n/total-score - показать общий счет для всех игроков.\n/exit - завершение раунда (поражение засчитывается игроку, который на\nмомент выхода из раунда должен был вводить слово).", language, eng, rus);
                    break;
                case "/show-words":
                    Output.PrintLanguage("List of words for this game.", "Список слов за эту игру.", language, eng, rus);
                    PlayerFileRepository.ReadingWords(language, eng, rus, firstName, secondName);
                    break;
                case "/score":
                    Output.PrintLanguage("/score", "/score", language, eng, rus);
                    PlayerFileRepository.ReadingScore(firstName, secondName, language, eng, rus);
                    break;
                case "/total-score":
                    Output.PrintLanguage("/total-score", "/total-score", language, eng, rus);
                    PlayerFileRepository.ReadingTotalScore(language, eng, rus);
                    break;
                case "/exit":
                    ExitCommand(language, eng, rus, game, gameProcess, firstName, secondName, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
                    break;
            }
        }
        internal static void ExitCommand(string language, string eng, string rus, bool game, bool gameProcess, string firstName, string secondName, int exitTurn, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord)
        {
            PlayerFileRepository playerFileRepository = new ();
            GameLogic gameLogic = new ();
            if (gameProcess == true)
            {
                Output.YellowPrintLanguage("You have completed this round!", "Вы завершили этот рауд!", language, eng, rus);
                PlayerFileRepository.EditingWinsAndLosses(exitTurn, firstName, secondName);
                gameLogic.End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
            }
            else if (gameProcess == false)
            {
                Output.YellowPrintLanguage("You cannot complete the round because it has not started.", "Вы не можете завершить раунд, т.к. он не начат.", language, eng, rus);
            }
        }
    }
}