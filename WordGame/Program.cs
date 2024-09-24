//E.A.T. 15-August-2024
//Declared "initialWord", "firstPlayerInput", "secondPlayerInput" variables for inputting the main word and players' words.
//E.A.T. 22-August-2024
//Constants "minNumberOfSymbolsInTheMainWord" and "maxNumberOfSymbolsInTheMainWord"to check the length of the main word.
//E.A.T. 28-August-2024
//Variable "language" to select the language.
//Variable "languageBool" for the for-while loop. As long as "languageBool=true",
//the loop will continue. After selecting 1 or 2, "languageBool" will be false.
//Constants "eng" and "rus" for choosing a language.
//E.A.T. 31-August-2024
//Variables "mainAlphabet" and "secondAlphabet" for selecting the main and second languages.
//The variables "english", "russian" contain two alphabets, and the variable "symbolsAndNumbers" contains symbols and numbers.
//E.A.T. 05-September-2024
//Variables "firstName" and "secondName" are needed to enter user names.
using System.Text.Json;

string? mainAlphabet;
string? secondAlphabet;
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
bool languageBool = true;
//E.A.T. 19-September-2024
//Updating variables initialWord, firstPlayerInput, secondPlayerInput.
string? initialWord;
string firstPlayerInput = "";
string secondPlayerInput = "";
const int minNumberOfSymbolsInTheMainWord = 8;
const int maxNumberOfSymbolsInTheMainWord = 30;
//E.A.T. 19-September-2024
//Variable to continue or end the game.
bool game = true;
//E.A.T. 02-September-2024
//Selecting and installing a language.
//Displays the selected language.
//Definition of main and second language.
SelectingALanguageAndSettingAlphabets();
//E.A.T. 05-September-2024
//Entering user names.
PlayerNames(out firstName, out secondName);
//E.A.T. 15-August-2024
//A method is called to enter the initial word.
//Checking the main word.
EnterTheMainWord(out initialWord);//Ввод первоначального слова
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
do
{
    FirstPlayerTextColor();
    FirstPlayerEnterTheWord(out firstPlayerInput);
    Game(mainAlphabet, initialWord, firstPlayerInput, 2, 1);//Проверка слова введёного игроком 1 по отношению к первоначальному слову
    CheckingForIncorrectSymbolsInTheUsersWord(secondAlphabet, symbolsAndNumbers, initialWord, firstPlayerInput, 2);
    SecondPlayerTextColor();
    SecondPlayerEnterTheWord(out secondPlayerInput);
    Game(mainAlphabet, initialWord, secondPlayerInput, 1, 1);//Проверка слова введёного игроком 2 по отношению к первоначальному слову
    CheckingForIncorrectSymbolsInTheUsersWord(secondAlphabet, symbolsAndNumbers, initialWord, secondPlayerInput, 1);
}
while (game == true);
///<summary>
///E.A.T. 15-August-2024
///Display the rules on the screen.
///Input the main word.
///E.A.T. 20-September-2024
///While you are typing your main word, you can enter a command.
///</summary>
void EnterTheMainWord(out string? initialWord)
{
    PrintLanguage("Rules: The essence of the game is for 2 users to alternately enter words consisting\nof the letters of the initially specified word. The one who does not enter the word in turn loses.", "Правила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово.");
    YellowPrintLanguage("Enter the first word to start the game (from 8 to 30 characters)", "Введите первое слово для начала игры (от 8 до 30 символов)");
    ListOfCommands(out initialWord);//Ввод первоначального слова
    CheckingForIncorrectSymbolsInTheMainWord(initialWord);//Проверка первоначального слова на верные символы
    CheckTheMainWord(initialWord);//Проверка первоначального слова на кол-во символов
}
///<summary>
///E.A.T. 02-September-2024
///Compare the main word with the selected alphabet or symbols and numbers.
///</summary>
void CheckingForIncorrectSymbolsInTheMainWord(string initialWord)
{
    CheckingTheSymbolsOfTheMainWord(secondAlphabet, initialWord, 1);
    CheckingTheSymbolsOfTheMainWord(symbolsAndNumbers, initialWord, 2);
}
///<summary>
///E.A.T. 02-September-2024
///Checking the base word for alphabets, symbols and numbers
///</summary>
void CheckingTheSymbolsOfTheMainWord(string symbols, string initialWord, int check)
{
    for(int i = 0; i < symbols.Length; i++)
    {
        for (int j = 0; j < initialWord.Length; j++)
        {
            if (symbols[i] == initialWord[j])
            {
                ErrorMessageToCheckTheMainWord(check);
                End(out game);
            }
        }
    }
}
///<summary>
///E.A.T. 02-September-2024
///Messages about entering incorrect letters or symbols and numbers.
///</summary>
void ErrorMessageToCheckTheMainWord(int check)
{
    switch (check)
    {
        case 1:
            YellowPrintLanguage("When entering the main word, you used letters of the Russian alphabet, not English.", "При вводе главного слова вы использовали буквы английского алфавита, а не русского.");
            break;
        case 2:
            YellowPrintLanguage("You used symbols or numbers when entering the main word.", "При вводе главного слова вы использовали символы или цифры.");
            break;
    }
}
///<summary>
///E.A.T. 15-August-2024
///Checking the main word.
///If the length of the main word matches the rules, the game starts.
///Otherwise, the game ends with the appropriate message.
///</summary>
void CheckTheMainWord(string? initialWord)
{
    int numberOfSymbolsInTheMainWord = initialWord.Length;
    bool requiredNumberOfSymbolsInTheMainWord = ((minNumberOfSymbolsInTheMainWord <= numberOfSymbolsInTheMainWord) & (numberOfSymbolsInTheMainWord <= maxNumberOfSymbolsInTheMainWord)); //Длина первоначально вводимого слова – от 8 до 30 символов
    if (requiredNumberOfSymbolsInTheMainWord == true)
    {
        PrintLanguage("Have a nice game!", "Хорошей игры!");
    }
    else
    {
        PrintLanguage("A word has been entered with an incorrect number of characters or an incorrect value has been entered", "Введено слово с неверным кол-вом символов или введено неверное значение");
        End(out game);
    }
}
///<summary>
///E.A.T. 15-August-2024
///If the player entered nothing, the game ends.
///If the player has entered a word, the word check starts.
/// The "ChekTheEnteredWordAgainstTheMainWord" method is used to check the entered words.
///</summary>
void Game(string symbols, string? initialWord, string? playerInput, int turn, int check)//Проверка слова введёного игроком по отношению к первоначальному слову
{
    if (playerInput.Length == 0)//Проверка ввёл ли игрок слово
    {
        YellowPrintLanguage($"You have not entered anything :(\nGame over! Player {turn} wins!", $"Вы ничего не ввели :(\nИгра окончена! Победил игрок {turn}!");
        End(out game);
    }
    else //Если игрок ввёл слово
    {
        ChekTheEnteredWordAgainstTheMainWord(symbols, initialWord, playerInput, turn, check);
    }
}
///<summary>
///E.A.T. 15-August-2024
///Comparing the symbols in the player's word to the main word.
///The "ChekingSymbolsInAWord" method is used to determine the number of symbols in the player's word and in the main word.
///</summary>
void ChekTheEnteredWordAgainstTheMainWord(string symbols, string? initialWord, string? playerInput, int turn, int check)
{
    int letterCounterForMainWord = 0;
    int letterCounterForUserWord = 0;
    for (int i = 0; i < symbols.Length; i++)//Проверка введённого слова по отношению первоначальному слову
    {
        if (i != 0)
        {
            if (letterCounterForMainWord < letterCounterForUserWord)//Если слово введённое игроком не соответствует по символам главному слову, то игра заканчивается. 
            {
                ErrorMessagesInTheGameMethod(check, turn);
                End(out game);
            }
        }
        ChekingSymbolsInAWord(symbols, initialWord, playerInput, i, out letterCounterForMainWord, out letterCounterForUserWord);
    }
}
///<summary>
///E.A.T. 15-August-2024
///Determining the number of symbols in the player's word and in the main word.
///</summary>
void ChekingSymbolsInAWord(string symbols, string? initialWord, string? playerInput, int i, out int letterCounterForMainWord, out int letterCounterForUserWord)
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
void CheckingForIncorrectSymbolsInTheUsersWord(string secondAlphabet, string symbols, string? initialWord, string? playerInput, int turn)
{
    Game(secondAlphabet, initialWord, playerInput, turn, 2);
    Game(symbols, initialWord, playerInput, turn, 3);
}
///<summary>
///E.A.T. 31-August-2024
///Error messages in method "Game".
///</summary>
void ErrorMessagesInTheGameMethod(int check, int turn){
    switch (check)
    {
        case 1:
            YellowPrintLanguage($"Game over! Player {turn} wins!", $"Игра окончена! Победил игрок {turn}!");
            break;
        case 2:
            YellowPrintLanguage($"You entered letters from the Russian alphabet, not English.\nGame over! Player {turn} wins!", $"Вы ввели буквы из английского алфавита, а не русского.\nИгра окончена! Победил игрок {turn}!");
            break;
        case 3:
            YellowPrintLanguage($"You have entered characters or numbers.\nGame over! Player {turn} wins!", $"Вы ввели символы или цифры.\nИгра окончена! Победил игрок {turn}!");
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
void FirstPlayerEnterTheWord(out string? firstPlayerInput)
{
    TimerCallback tm = new TimerCallback(FirstTime); //Таймер на 15 сек
    Timer timer = new Timer(tm, null, 15000, 0);
    ListOfCommands(out firstPlayerInput); //Ввод слова игроком 1
    timer.Dispose();//Отключение таймера
    CheckForWordRepetition(firstPlayerInput, 2);
    RecordingWords(firstPlayerInput);
}
///<summary>
///E.A.T. 15-August-2024
///A timer for 15 seconds is started for the second player.
///If the second player does not have time to enter the word, the timer will call the "SecondTime" method to end the game.
///If the second player manages to enter the word in 15 seconds, the timer will turn off.
///E.A.T. 20-September-2024
///
///</summary>
void SecondPlayerEnterTheWord(out string? secondPlayerInput)
{
    TimerCallback tm1 = new TimerCallback(SecondTime); //Таймер на 15 сек
    Timer timer1 = new Timer(tm1, null, 15000, 0);
    ListOfCommands(out secondPlayerInput); //Ввод слова игроком 2
    timer1.Dispose();//Отключение таймера
    CheckForWordRepetition(secondPlayerInput, 1);
    RecordingWords(secondPlayerInput);
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the first player fails to enter within 15 seconds.
///</summary>
void FirstTime(object? obj)//Если игрок 1 не успел ввести слово за 15 сек
{
    YellowPrintLanguage("You didn't have time! Player 2 wins!", "Вы не успели! Победил игрок 2!");
    End(out game);
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the second player fails to enter within 15 seconds.
///</summary>
void SecondTime(object? obj)//Если игрок 2 не успел ввести слово за 15 сек
{
    YellowPrintLanguage("You didn't have time! Player 1 wins!", "Вы не успели! Победил игрок 1!");
    End(out game);
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the first player to green. 
/// </summary>
void FirstPlayerTextColor()
{
    PrintLanguage($"Your initial word: {initialWord}", $"Ваше изначальное слово: {initialWord}");
    GreenPrintLanguage($"Player 1 | {firstName} | Enter your word! You have 15 seconds", $"Игрок 1 | {firstName} | Введите ваше слово! У вас 15 сек");
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the second player to blue. 
/// </summary>
void SecondPlayerTextColor()
{
    PrintLanguage($"Your initial word: {initialWord}", $"Ваше изначальное слово: {initialWord}");
    BluePrintLanguage($"Player 2 | {secondName} | Enter your word! You have 15 seconds", $"Игрок 2 | {secondName} | Введите ваше слово! У вас 15 сек");
}
/// <summary>
/// E.A.T. 25-August-2024
/// Output white text.
/// </summary>
void Print(string text)
{
    Console.WriteLine(text);
}
///<summary>
///E.A.T. 30-August-2024
///Output English or Russian text.
///</summary>
void PrintLanguage(string engText, string rusText)
{
    if (language == eng)
    {
        Console.WriteLine(engText);
    }
    else if (language == rus)
    {
        Console.WriteLine(rusText);
    }
}
///<summary>
///E.A.T. 25-August-2024
///Output yellow text.
///</summary>
void YellowPrint(string text)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(text);
    Console.ResetColor();
}
///<summary>
///E.A.T. 30-August-2024
///Display English or Russian text in yellow.
///</summary>
void YellowPrintLanguage(string engText, string rusText)
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
void GreenPrint(string text)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(text);
    Console.ResetColor();
}
///<summary>
///E.A.T. 30-August-2024
///Display English or Russian text in green.
///</summary>
void GreenPrintLanguage(string engText, string rusText)
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
void BluePrint(string text)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(text);
    Console.ResetColor();
}
///<summary>
///E.A.T. 30-August-2024
///Display English or Russian text in blue.
///</summary>
void BluePrintLanguage(string engText, string rusText)
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
///<summary>
///E.A.T. 26-August-2024
///Entering a word.
///</summary>
void Read(out string? word)
{
    word = Console.ReadLine();
}
///<summary>
///E.A.T. 28-August-2024
///Until the language is selected, "LanguageBool" will be equal to "true".
///After selecting the language, "LanguageBool" will be equal to "false" and the for-while loop will end.
///</summary>
void LanguageBool()
{
    if (language == eng || language == rus)
    {
        languageBool = false;
    }
}
///<summary>
///E.A.T. 28-August-2024
///Selecting and installing a language.
///</summary>
void Language()
{
    do
    {
        Print("Выберите Язык | Select Language\nАнглийский язык - 1, Русский язык - 2\nEnglish - 1, Russian - 2");
        Read(out language);
        LanguageBool();
    } while (languageBool == true);
}
///<summary>
///E.A.T. 28-August-2024
///Displays the selected language.
///</summary>
void YourChosenLanguage()
{
    YellowPrintLanguage("Your selected language: English.", "Ваш выбранный язык: Русский.");
}
///<summary>
///E.A.T. 31-August-2024
///Setting the main and second languages ​​depending on the value of the "language" variable.
///</summary>
void Alphabet(out string? mainAlphabet, out string? secondAlphabet)
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
void SelectingALanguageAndSettingAlphabets()
{
    Language();
    YourChosenLanguage();
    Alphabet(out mainAlphabet, out secondAlphabet);
}
///<summary>
///E.A.T. 05-September-2024
///Entering user names.
///E.A.T. 19-September-2024
///Greeting added.
///</summary>
void PlayerNames(out string? firstName, out string? secondName) {
    YellowPrintLanguage("Players, enter your names!", "Игроки, введите ваши имена!");
    GreenPrintLanguage("Player 1, enter your name!", "Игрок 1, введите ваше имя!");
    NameInput(out firstName);
    BluePrintLanguage("Player 2, enter your name!", "Игрок 2, введите ваше имя!");
    NameInput(out secondName);
    YellowPrintLanguage($"{firstName} and {secondName}, welcome to the game WORDS!", $"{firstName} и {secondName}, добро пожаловать в игру СЛОВА!");
}
///<summary>
///E.A.T. 05-September-2024
///Name input and checking.
///E.A.T. 20-September-2024
///You can enter commands while entering names. 
///</summary>
void NameInput(out string? name)
{
    bool nameBool = true;
    do
    {
        ListOfCommands(out name);
        if (name != "")
        {
            nameBool = false;
        }
        else
        {
            PrintLanguage("Enter your name!", "Введите ваше имя!");
        }
    } while (nameBool == true);
}
///<summary>
///E.A.T. 19-September-2024
///If the game ends, users can choose whether they want to play another round or end the game.
///E.A.T. 20-September-2024
///You can enter commands while you enter your selection.
///</summary>
void End(out bool game)
{
    PrintLanguage("Do you want to play again?\n1 - Yes, 2 - No", "Вы хотите сыграть ещё раз?\n1 - Да, 2 - Нет");
    game = false;
    bool endBool = true;
    do
    {
        string? answer;
        ListOfCommands(out answer);
        if (answer == "1")
        {
            YellowPrintLanguage("Next round!", "Следующий раунд!");
            game = true;
            endBool = false;
            DeleteFile("words.json");
            EnterTheMainWord(out initialWord);
        }
        else if (answer == "2")
        {
            YellowPrintLanguage("Game over!", "Игра завершена!");
            DeleteFile("words.json");
            Environment.Exit(0);
        }
    } while (endBool == true);
}
///<summary>
///E.A.T. 19-September-2024
///The method accepts commands during the game.
///</summary>

void ListOfCommands(out string? commandOrWord){
    bool boolCommands = true;
    do
    {
        Read(out commandOrWord);
        List<string> listOfCommands = new List<string>() { "/help", "/show-words", "/score", "/total-score", "/exit" };
        if (commandOrWord == null) {
            boolCommands = false;
        }
        else if (listOfCommands.Contains(commandOrWord)){
            Commands(commandOrWord);
        }
        else{
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
void Commands(string command)
{
    switch (command)
    {
        case "/help":
            YellowPrintLanguage("List of commands:\n/help - show the entire list of commands.\n/show-words – show all words entered by both users in the current game.\n/score – show the total game score for current players (extract from file).\n/total-score – show the total score for all players.\n/exit - end of the game (defeat is counted to the player who had to enter\na word at the moment of exiting the application).", "Список команд:\n/help - показать весь список команд.\n/show-words - показать все введенные обоими пользователями слова в текущей игре.\n/score - показать общий счет по играм для текущих игроков (извлечь из файла).\n/total-score - показать общий счет для всех игроков.\n/exit - завершение игры (поражение засчитывается игроку, который на\nмомент выхода из приложения должен был вводить слово).");
            break;
        case "/show-words":
            PrintLanguage("List of words for this game.", "Список слов за эту игру.");
            ReadingWords();
            break;
        case "/score":
            PrintLanguage("/score", "/score");
            break;
        case "/total-score":
            PrintLanguage("/total-score", "/total-score");
            break;
        case "/exit":
            YellowPrintLanguage("You have completed this round!", "Вы завершили этот рауд!");
            break;
    }
}
///<summary> 
///E.A.T. 23-September-2024
///This is a method to check for word repetition. 
///</summary>
void CheckForWordRepetition(string? playerWord, int turn)
{
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
                YellowPrintLanguage($"Such a word alredy exists! \nGame over! Player {turn} wins!", $"Такое слово уже есть! \nИгра окончена! Игрок {turn} победил!");
                RecordingWords(playerWord);
                End(out game);
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
void RecordingWords(string? playerWord)
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
void ReadingWords()
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
            PrintLanguage($"Player {turn} | {name} |: {word}",$"Игрок {turn} | {name} |: {word}");
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
        YellowPrintLanguage($"File {fileName} not found!", $"Файл {fileName} не найден!");
    }
}
///<summary>
///E.A.T. 24-September-2024
///Serialize data to JSON and write to file.
///</summary>
void SerializeFileListString(string fileName, List<string> words)
{
    string jsonString = JsonSerializer.Serialize(words, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(fileName, jsonString);

}
///<summary>
///E.A.T. 24-September-2024
///Read existing data from file. 
///The variable "word" will store the deserialized data from the file.
///</summary>
void DeserializeFileListString(string fileName, out List<string> words)
{
    string jsonStringFromFile = File.ReadAllText(fileName);
    words = JsonSerializer.Deserialize<List<string>>(jsonStringFromFile) ?? new List<string>();
}
///<summary>
///E.A.T. 23-September-2024
///Delete file.
///</summary>
void DeleteFile(string fileName)
{
    if (File.Exists(fileName))
    {
        File.Delete(fileName);
    }
}
///<summary>
///E.A.T. 20-September-2024
///Player class for creating a player.
///The player has a name, number of wins and losses.
///</summary>
public class Player
{
    public string Name { get; }
    public int Wins { get; set; }
    public int Losses { get; set; }

    public Player(string name, int wins, int losses)
    {
        Name = name;
        Wins = wins;
        Losses = losses;
    }
    public void UpdateWins(int updateWins)
    {
        Wins = updateWins;
    }
    public void UpdateLosses(int updateLosses)
    {
        Losses = updateLosses;
    }
}