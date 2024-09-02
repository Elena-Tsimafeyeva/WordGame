//E.A.T. 15-August-2024
//The variable "symbols" is declared, which contains symbols for word checking.
//Declared "initialWord", "firstPlayerInput", "secondPlayerInput" variables for inputting the main word and players' words.
//E.A.T. 22-August-2024
//"minNumberOfSymbolsInTheMainWord", "maxNumberOfSymbolsInTheMainWord"
//E.A.T. 28-August-2024
//"language"
//"languageBool"
//"eng", "rus"
string? mainAlphabet;
string? secondAlphabet;
string english = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
string russian = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
string symbolsAndNumbers = "1234567890@#£_&-+()/*':;!?~`|•√π÷×§∆€¥$¢^°={}%©®™✓[]<>,.";
string? language;
const string eng = "1";
const string rus = "2";
bool languageBool = true;
string? initialWord, firstPlayerInput, secondPlayerInput;
const int minNumberOfSymbolsInTheMainWord = 8;
const int maxNumberOfSymbolsInTheMainWord = 30;
Language();
YourChosenLanguage();
Alphabet(out mainAlphabet, out secondAlphabet);
//E.A.T. 15-August-2024
//A method is called to enter the initial word.
//The method to check the initial word is called.
EnterTheMainWord(out initialWord);//Ввод первоначального слова
//E.A.T. 15-August-2024
//The do-While loop is where the game itself takes place.
//The "FirstPlayerTextColor" method is called to change the text color for the first player.
//The "FirstPlayerEnterTheWord" method is called for the first player to enter a word.
//Called the "Game" method to check the entered word of the first player for compliance with the rules of the game.
//Called the "SecondPlayerTextColor" method to change the color of the text for the second player.
//Called the "SecondPlayerEnterTheWord" method for inputting a word by the second player.
//The "Game" method is called to check the word entered by the second player for compliance with the game rules.
do
{
    FirstPlayerTextColor();
    FirstPlayerEnterTheWord(out firstPlayerInput);
    Game(mainAlphabet, initialWord, firstPlayerInput, 2, 1);//Проверка слова введёного игроком 1 по отношению к первоначальному слову
    ChecksForUserInpuOfIncorrectAlphabetOrSymbolsOrNumbers(secondAlphabet, symbolsAndNumbers, initialWord, firstPlayerInput, 2);
    SecondPlayerTextColor();
    SecondPlayerEnterTheWord(out secondPlayerInput);
    Game(mainAlphabet, initialWord, secondPlayerInput, 1, 1);//Проверка слова введёного игроком 2 по отношению к первоначальному слову
    ChecksForUserInpuOfIncorrectAlphabetOrSymbolsOrNumbers(secondAlphabet, symbolsAndNumbers, initialWord, secondPlayerInput, 1);
}
while (true);
///<summary>
///E.A.T. 15-August-2024
///Display the rules on the screen.
///Input the main word.
///</summary>
void EnterTheMainWord(out string? initialWord)
{
    PrintLanguage("Welcome to the game of WORDS! \nRules: The essence of the game is for 2 users to alternately enter words consisting\nof the letters of the initially specified word. The one who does not enter the word in turn loses.", "Добро пожаловать в игру СЛОВА! \nПравила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово.");
    YellowPrintLanguage("Enter the first word to start the game (from 8 to 30 characters)", "Введите первое слово для начала игры (от 8 до 30 символов)");
    Read(out initialWord);//Ввод первоначального слова
    CompareThMainWordWithTheSelectedSlphabet(initialWord);//Проверка первоначального слова на верные символы
    CheckTheMainWord(initialWord);//Проверка первоначального слова на кол-во символов
}
void CompareThMainWordWithTheSelectedSlphabet(string initialWord)
{
    CheckingTheMainWordForAlphabetsAndSymbolsAndNumbers(secondAlphabet, initialWord, 1);
    CheckingTheMainWordForAlphabetsAndSymbolsAndNumbers(symbolsAndNumbers, initialWord, 2);
}
void CheckingTheMainWordForAlphabetsAndSymbolsAndNumbers(string symbols, string initialWord, int check)
{
    for(int i = 0; i < symbols.Length; i++)
    {
        for (int j = 0; j < initialWord.Length; j++)
        {
            if (symbols[i] == initialWord[j])
            {
                MessageAboutEnteringIncorrectLettersOfTheAlphabetAndSymbols(check);
                Environment.Exit(1);
            }
        }
    }
}
void MessageAboutEnteringIncorrectLettersOfTheAlphabetAndSymbols(int check)
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
        Environment.Exit(1);
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
        Environment.Exit(1);
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
                LossMessagesInTheGameMethod(check, turn);
                Environment.Exit(1);
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
void ChecksForUserInpuOfIncorrectAlphabetOrSymbolsOrNumbers(string secondAlphabet, string symbols, string? initialWord, string? playerInput, int turn)
{
    Game(secondAlphabet, initialWord, playerInput, turn, 2);
    Game(symbols, initialWord, playerInput, turn, 3);
}
void LossMessagesInTheGameMethod(int check, int turn){
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
///</summary>
void FirstPlayerEnterTheWord(out string? firstPlayerInput)
{
    TimerCallback tm = new TimerCallback(FirstTime); //Таймер на 15 сек
    Timer timer = new Timer(tm, null, 15000, 0);
    Read(out firstPlayerInput); //Ввод слова игроком 1
    timer.Dispose();//Отключение таймера
}
///<summary>
///E.A.T. 15-August-2024
///A timer for 15 seconds is started for the second player.
///If the second player does not have time to enter the word, the timer will call the "SecondTime" method to end the game.
///If the second player manages to enter the word in 15 seconds, the timer will turn off.
///</summary>
void SecondPlayerEnterTheWord(out string? secondPlayerInput)
{
    TimerCallback tm1 = new TimerCallback(SecondTime); //Таймер на 15 сек
    Timer timer1 = new Timer(tm1, null, 15000, 0);
    Read(out secondPlayerInput); //Ввод слова игроком 2
    timer1.Dispose();//Отключение таймера
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the first player fails to enter within 15 seconds.
///</summary>
void FirstTime(object? obj)//Если игрок 1 не успел ввести слово за 15 сек
{
    YellowPrintLanguage("You didn't have time! Player 2 wins!", "Вы не успели! Победил игрок 2!");
    Environment.Exit(0);
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the second player fails to enter within 15 seconds.
///</summary>
void SecondTime(object? obj)//Если игрок 2 не успел ввести слово за 15 сек
{
    YellowPrintLanguage("You didn't have time! Player 1 wins!", "Вы не успели! Победил игрок 1!");
    Environment.Exit(0);
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the first player to green. 
/// </summary>
void FirstPlayerTextColor()
{
    PrintLanguage($"Your initial word: {initialWord}", $"Ваше изначальное слово: {initialWord}");
    GreenPrintLanguage("Player 1| Enter your word! You have 15 seconds", "Игрок 1| Введите ваше слово! У вас 15 сек");
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the second player to blue. 
/// </summary>
void SecondPlayerTextColor()
{
    PrintLanguage($"Your initial word: {initialWord}", $"Ваше изначальное слово: {initialWord}");
    BluePrintLanguage("Player 2| Enter your word! You have 15 seconds", "Игрок 2| Введите ваше слово! У вас 15 сек");
}
/// <summary>
/// E.A.T. 25-August-2024
/// Output white text.
/// </summary>
void Print(string text)
{
    Console.WriteLine(text);
}
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
/// <summary>
/// E.A.T. 25-August-2024
/// Output yellow text.
/// </summary>
void YellowPrint(string text)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(text);
    Console.ResetColor();
}
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
/// <summary>
/// E.A.T. 25-August-2024
/// Output green text.
/// </summary>
void GreenPrint(string text)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(text);
    Console.ResetColor();
}
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
/// <summary>
/// E.A.T. 25-August-2024
/// Output blue text.
/// </summary>
void BluePrint(string text)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(text);
    Console.ResetColor();
}
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
/// <summary>
/// E.A.T. 26-August-2024
/// Entering a word.
/// </summary>
void Read(out string? word)
{
    word = Console.ReadLine();
}
void LanguageBool()
{
    if (language == eng || language == rus)
    {
        languageBool = false;
    }
}
void Language()
{
    do
    {
        Print("Выберите Язык | Select Language\nАнглийский язык - 1, Русский язык - 2\nEnglish - 1, Russian - 2");
        Read(out language);
        LanguageBool();
    } while (languageBool == true);
}
void YourChosenLanguage()
{
    YellowPrintLanguage("Your selected language: English.", "Ваш выбранный язык: Русский.");
}
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