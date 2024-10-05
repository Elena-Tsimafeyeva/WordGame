using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WordGame
{
    internal class PlayerFileRepository
    {
        ///<summary>
        ///E.A.T. 05-September-2024
        ///Entering user names.
        ///E.A.T. 19-September-2024
        ///Greeting added.
        ///</summary>
        internal static void PlayerNames(out string? firstName, out string? secondName, string language, string eng, string rus, bool game, bool gameProcess, int exitTurn, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord)
        {
            gameProcess = false;
            firstName = null;
            secondName = null;
            Output.YellowPrintLanguage("Players, enter your names!", "Игроки, введите ваши имена!", language, eng, rus);
            Output.GreenPrintLanguage("Player 1, enter your name!", "Игрок 1, введите ваше имя!", language, eng, rus);
            RecordingPlayer(out firstName, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
            Output.BluePrintLanguage("Player 2, enter your name!", "Игрок 2, введите ваше имя!", language, eng, rus);
            RecordingPlayer(out secondName, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
            Output.YellowPrintLanguage($"{firstName} and {secondName}, welcome to the game WORDS!", $"{firstName} и {secondName}, добро пожаловать в игру СЛОВА!", language, eng, rus);
        }
        ///<summary>
        ///E.A.T. 05-September-2024
        ///Name input and checking.
        ///E.A.T. 20-September-2024
        ///You can enter commands while entering names. 
        ///E.A.T. 04-October-2024
        ///You can't enter anything.
        ///The second player can't write the first player's name.
        ///</summary>
        internal static void NameInput(out string? name, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, int exitTurn, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord)
        {
            bool nameBool = true;
            do
            {
                GameCommandsManager.ListOfCommands(out name, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
                CheckCharactersInName(name, out int numberOfSymbols);
                if (numberOfSymbols == 0)
                {
                    Output.PrintLanguage("Enter your name!", "Введите ваше имя!", language, eng, rus);
                }
                else if (firstName == name)
                {
                    Output.PrintLanguage("The name is taken by the first player!\nEnter your name!", "Имя занято первым игроком!\nВведите ваше имя!", language, eng, rus);
                }
                else
                {
                    nameBool = false;
                }
            }while (nameBool == true);
        }
        ///<summary>
        ///E.A.T. 04-October-2024
        ///Checking if a name contains characters.
        ///</summary>
        internal static void CheckCharactersInName(string? name, out int numberOfSymbols)
        {
            numberOfSymbols = 0;
            string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ1234567890@#£_&-+()/*':;!?~`|•√π÷×§∆€¥$¢^°={}%©®™✓[]<>,.";
            for (int i = 0; i < symbols.Length; i++)
                {
                for (int j = 0; j < name.Length; j++)
                    {
                    if (symbols[i] == name[j])
                    {
                        numberOfSymbols += 1;
                    }
                }
            }
        }
        ///<summary> 
        ///E.A.T. 23-September-2024
        ///This is a method to check for word repetition. 
        ///</summary>
        internal static void CheckForWordRepetition(string? playerWord, int turn, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord, int exitTurn)
        {
            GameLogic gameLogic = new();
            string fileName = "words.json";
            List<string> words;
            if (File.Exists(fileName))
            {
                string jsonStringFromFile = File.ReadAllText(fileName);
                words = JsonSerializer.Deserialize<List<string>>(jsonStringFromFile) ?? new List<string>();
                foreach (var word in words)
                {
                    if (playerWord == word)
                    {
                        Output.YellowPrintLanguage($"Such a word alredy exists! \nGame over! Player {turn} wins!", $"Такое слово уже есть! \nИгра окончена! Игрок {turn} победил!", language, eng, rus);
                        RecordingWords(playerWord);
                        EditingWinsAndLosses(turn, firstName, secondName);
                        gameLogic.End(out game, initialWord, language, eng, rus, gameProcess, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, firstName, secondName, exitTurn);
                    }
                }
            }
        }
        ///<summary>
        ///E.A.T. 23-September-2024
        ///Writing words to the file "words.json".
        ///E.A.T. 24-September-2024
        ///Update.
        ///Added "DeserializeFileListString" and "SerializeFileListString" methods.
        ///</summary>
        internal static void RecordingWords(string? playerWord)
        {
            string fileName = "words.json";
            List<string> words;
            if (File.Exists(fileName))
            {
                DeserializeFileListString(fileName, out words);
            }
            else
            {
                words = new List<string>();
            }
            words.Add(new string(playerWord));
            SerializeFileListString(fileName, words);
        }
        ///<summary>
        ///E.A.T. 23-September-2024
        ///Reading words from the file "words.json".
        ///E.A.T. 24-September-2024
        ///Update.
        ///Added "DeserializeFileListString" method.
        ///</summary>
        internal static void ReadingWords(string language, string eng, string rus, string firstName, string secondName)
        {
            string fileName = "words.json";
            List<string> words;
            if (File.Exists(fileName))
            {
                int turn = 1;
                string name = firstName;
                DeserializeFileListString(fileName, out words);
                foreach (var word in words)
                {
                    Output.PrintLanguage($"Player {turn} | {name} |: {word}", $"Игрок {turn} | {name} |: {word}", language, eng, rus);
                    if (turn == 1)
                    {
                        turn += 1;
                        name = secondName;
                    }
                    else if (turn == 2)
                    {
                        turn -= 1;
                        name = firstName;
                    }
                }
            }
            else
            {
                Output.YellowPrintLanguage($"File {fileName} not found!", $"Файл {fileName} не найден!", language, eng, rus);
            }
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///To add wins and losses.
        ///</summary>
        internal static void EditingWinsAndLosses(int numWiner, string firstName, string secondName)
        {
            string fileName = "players.json";
            List<Player> players;
            string nameWiner = "";
            string nameLosser = "";
            if (numWiner == 1)
            {
                nameWiner = firstName;
                nameLosser = secondName;
            }
            else if (numWiner == 2)
            {
                nameWiner = secondName;
                nameLosser = firstName;
            }
            DeserializeFileListPlayer(fileName, out players);
            foreach (var player in players)
            {
                if (player.Name == nameWiner)
                {
                    int numberWins = player.Wins;
                    player.UpdateWins(numberWins + 1);
                }
                else if (player.Name == nameLosser)
                {
                    int numberLosses = player.Losses;
                    player.UpdateLosses(player.Losses + 1);
                }
            }
            SerializeFileListPlayer(fileName, players);
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///To record a player.
        ///</summary>
        internal static void RecordingPlayer(out string name, string language, string eng, string rus, string firstName, string secondName, bool game, bool gameProcess, int exitTurn, string initialWord, string secondAlphabet, string symbolsAndNumbers, int minNumberOfSymbolsInTheMainWord, int maxNumberOfSymbolsInTheMainWord)
        {
            NameInput(out name, language, eng, rus, firstName, secondName, game, gameProcess, exitTurn, initialWord, secondAlphabet, symbolsAndNumbers, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord);
            bool recordingName = true;
            string fileName = "players.json";
            List<Player> players;
            if (File.Exists(fileName))
            {
                DeserializeFileListPlayer(fileName, out players);
            }
            else
            {
                players = new List<Player>();
            }
            ChekForPlayerNameRepetition(name, out recordingName, language, eng, rus);
            if (recordingName == false)
            {
                Output.PrintLanguage($"Welcome, {name}!", $"Добро пожаловать, {name}!", language, eng, rus);
                players.Add(new Player(name, 0, 0));
                SerializeFileListPlayer(fileName, players);
            }
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///To check for a duplicate name.
        ///</summary>
        internal static void ChekForPlayerNameRepetition(string name, out bool recordingName, string language, string eng, string rus)
        {
            recordingName = false;
            List<Player> players;
            string fileName = "players.json";
            if (File.Exists(fileName))
            {
                DeserializeFileListPlayer(fileName, out players);
                foreach (var player in players)
                {
                    if (player.Name == name)
                    {
                        Output.PrintLanguage($"Welcome back, {name}!", $"С возвращением, {name}!", language, eng, rus); ;
                        recordingName = true;
                    }
                }
            }
            else
            {
                Output.YellowPrintLanguage($"File {fileName} not found!", $"Файл {fileName} не найден!", language, eng, rus);
            }
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///To list players who are currently playing. 
        ///</summary>
        internal static void ReadingScore(string firstName, string secondName, string language, string eng, string rus)
        {
            List<Player> players;
            string fileName = "players.json";
            if (File.Exists(fileName))
            {
                DeserializeFileListPlayer(fileName, out players);
                foreach (var player in players)
                {
                    if (player.Name == firstName || player.Name == secondName)
                    {
                        Output.PrintLanguage($"Player: {player.Name}, Wins: {player.Wins}, Losses: {player.Losses}", $"Игрок: {player.Name}, Побед: {player.Wins}, Проигрышей: {player.Losses}", language, eng, rus);
                    }
                }
            }
            else
            {
                Output.YellowPrintLanguage($"File {fileName} not found!", $"Файл {fileName} не найден!", language, eng, rus);
            }
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///To list all players (name, wins, and losses).
        ///</summary>
        internal static void ReadingTotalScore(string language, string eng, string rus)
        {
            List<Player> players;
            string fileName = "players.json";
            if (File.Exists(fileName))
            {
                DeserializeFileListPlayer(fileName, out players);
                foreach (var player in players)
                {
                    Output.PrintLanguage($"Player: {player.Name}, Wins: {player.Wins}, Losses: {player.Losses}", $"Игрок: {player.Name}, Побед: {player.Wins}, Проигрышей: {player.Losses}", language, eng, rus);
                }
            }
            else
            {
                Output.YellowPrintLanguage($"File {fileName} not found!", $"Файл {fileName} не найден!", language, eng, rus);
            }
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///Serialize data to JSON and write to file.
        ///For the word list.
        ///</summary>
        internal static void SerializeFileListString(string fileName, List<string> words)
        {
            string jsonString = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);

        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///Read existing data from file. 
        ///The variable "word" will store the deserialized data from the file.
        ///For the word list.
        ///</summary>
        internal static void DeserializeFileListString(string fileName, out List<string> words)
        {
            string jsonStringFromFile = File.ReadAllText(fileName);
            words = JsonSerializer.Deserialize<List<string>>(jsonStringFromFile) ?? new List<string>();
        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///Serialize data to JSON and write to file.
        ///For the player list.
        ///</summary>
        internal static void SerializeFileListPlayer(string fileName, List<Player> words)
        {
            string jsonString = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);

        }
        ///<summary>
        ///E.A.T. 24-September-2024
        ///Read existing data from file. 
        ///The variable "players" will store the deserialized data from the file.
        ///For the player list.
        ///</summary>
        internal static void DeserializeFileListPlayer(string fileName, out List<Player> players)
        {
            string jsonStringFromFile = File.ReadAllText(fileName);
            players = JsonSerializer.Deserialize<List<Player>>(jsonStringFromFile) ?? new List<Player>();
        }
        ///<summary>
        ///E.A.T. 23-September-2024
        ///Delete file.
        ///</summary>
        internal static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
