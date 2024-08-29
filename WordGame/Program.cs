//E.A.T. 15-August-2024
//The variable "symbols" is declared, which contains symbols for word checking.
//Declared "initialWord", "firstPlayerInput", "secondPlayerInput" variables for inputting the main word and players' words.
//E.A.T. 22-August-2024
//"minNumberOfSymbolsInTheMainWord", "maxNumberOfSymbolsInTheMainWord"
//E.A.T. 28-August-2024
//"language"
//"languageBool"
//"eng", "rus"
string symbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz1234567890!?@#$%^&*()_-=+№;:<>.,/|`~{}[] ";
//Переменные для смены языка и проверки на ввод лишних символов
//english = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
//string russian = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
//string symbolss = "1234567890@#£_&-+()/*':;!?~`|•√π÷×§∆€¥$¢^°={}%©®™✓[]<>,.";
string? language;
const string eng = "1";
const string rus = "2";
bool languageBool = true;
string? initialWord, firstPlayerInput, secondPlayerInput;
const int minNumberOfSymbolsInTheMainWord = 8;
const int maxNumberOfSymbolsInTheMainWord = 30;
Language();
YourChosenLanguage();
//E.A.T. 15-August-2024
//A method is called to enter the initial word.
//The method to check the initial word is called.
EnterTheMainWord(out initialWord);//Ввод первоначального слова
CheckTheMainWord(initialWord);//Проверка первоначального слова
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
    Game(symbols,initialWord, firstPlayerInput, 2);//Проверка слова введёного игроком 1 по отношению к первоначальному слову
    SecondPlayerTextColor();
    SecondPlayerEnterTheWord(out secondPlayerInput);
    Game(symbols,initialWord, secondPlayerInput, 1);//Проверка слова введёного игроком 2 по отношению к первоначальному слову
}
while (true);
///<summary>
///E.A.T. 15-August-2024
///Display the rules on the screen.
///Input the main word.
///</summary>
void EnterTheMainWord(out string? initialWord)
{
    if (language == eng) {
        Print("Welcome to the game of WORDS! \nRules: The essence of the game is for 2 users to alternately enter words consisting\nof the letters of the initially specified word. The one who does not enter the word in turn loses.");
        YellowPrint("Enter the first word to start the game (from 8 to 30 characters)");
    } else if (language == rus)
    {
        Print("Добро пожаловать в игру СЛОВА! \nПравила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово.");
        YellowPrint("Введите первое слово для начала игры (от 8 до 30 символов)");
    }
    Read(out initialWord);//Ввод первоначального слова
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
        Print("Хорошей игры!");
    }
    else
    {
        Print("Введено слово с неверным кол-вом символов или введено неверное значение");
        Environment.Exit(1);
    }
}
///<summary>
///E.A.T. 15-August-2024
///If the player entered nothing, the game ends.
///If the player has entered a word, the word check starts.
/// The "ChekTheEnteredWordAgainstTheMainWord" method is used to check the entered words.
///</summary>
void Game(string symbols, string? initialWord, string? playerInput, int turn)//Проверка слова введёного игроком по отношению к первоначальному слову
{
    if (playerInput.Length == 0)//Проверка ввёл ли игрок слово
    {
        Print("Вы ничего не ввели :(");
        Print($"Игра окончена! Победил игрок {turn}!");
        Environment.Exit(1);
    }
    else //Если игрок ввёл слово
    {
        ChekTheEnteredWordAgainstTheMainWord(symbols, initialWord, playerInput, turn);
    }
}
///<summary>
///E.A.T. 15-August-2024
///Comparing the symbols in the player's word to the main word.
///The "ChekingSymbolsInAWord" method is used to determine the number of symbols in the player's word and in the main word.
///</summary>
void ChekTheEnteredWordAgainstTheMainWord(string symbols, string? initialWord, string? playerInput, int turn)
{
    int letterCounterForMainWord = 0;
    int letterCounterForUserWord = 0;
    for (int i = 0; i < symbols.Length; i++)//Проверка введённого слова по отношению первоначальному слову
    {
        if (i != 0)
        {
            if (letterCounterForMainWord < letterCounterForUserWord)//Если слово введённое игроком не соответствует по символам главному слову, то игра заканчивается. 
            {
                Print($"Игра окончена! Победил игрок {turn}!");
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
    Print("Вы не успели! Победил игрок 2!");
    Environment.Exit(0);
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the second player fails to enter within 15 seconds.
///</summary>
void SecondTime(object? obj)//Если игрок 2 не успел ввести слово за 15 сек
{
    Print("Вы не успели! Победил игрок 1!");
    Environment.Exit(0);
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the first player to green. 
/// </summary>
void FirstPlayerTextColor()
{
    Print($"Ваше изначальное слово: {initialWord}");
    GreenPrint("Игрок 1| Введите ваше слово! У вас 15 сек");
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the second player to blue. 
/// </summary>
void SecondPlayerTextColor()
{
    Print($"Ваше изначальное слово: {initialWord}");
    BluePrint("Игрок 2| Введите ваше слово! У вас 15 сек");
}
/// <summary>
/// E.A.T. 25-August-2024
/// Output white text.
/// </summary>
void Print(string text)
{
    Console.WriteLine(text);
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
    if (language == eng)
    {
        Print("Your selected language: English.");
    }
    else if (language == rus)
    {
        Print("Ваш выбранный язык: Русский.");
    }
}