﻿///<summary>
///The variable "symbols" is declared, which contains symbols for word checking.
///Declared "word, word1, word2" variables for inputting the main word and players' words.
///The variable "number" for the timer is declared.
///</summary>
string symbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz1234567890!?@#$%^&*()_-=+№;:<>.,/|`~{}[] ";
string? word, word1, word2;
int num = 0;
///<summary>
///A method is called to enter the initial word.
///The method to check the initial word is called.
///</summary>
EnterTheMainWord(out word);//Ввод первоначального слова
CheckTheMainWord(word);//Проверка первоначального слова
///<summary>
///The do-While loop is where the game itself takes place.
///The "FirstPlayerTextColor" method is called to change the text color for the first player.
///The "FirstPlayerEnterTheWord" method is called for the first player to enter a word.
///Called the "Game" method to check the entered word of the first player for compliance with the rules of the game.
///Called the "SecondPlayerTextColor" method to change the color of the text for the second player.
///Called the "SecondPlayerEnterTheWord" method for inputting a word by the second player.
///The "Game" method is called to check the word entered by the second player for compliance with the game rules.
///</summary>
do
{
    FirstPlayerTextColor();
    FirstPlayerEnterTheWord(out word1);
    Game(symbols,word, word1, 2);//Проверка слова введёного игроком 1 по отношению к первоначальному слову
    SecondPlayerTextColor();
    SecondPlayerEnterTheWord(out word2);
    Game(symbols,word, word2, 1);//Проверка слова введёного игроком 2 по отношению к первоначальному слову
}
while (true);
///<summary>
///Display the rules on the screen.
///Input the main word.
///</summary>
void EnterTheMainWord(out string? word)
{
    Console.WriteLine("Добро пожаловать в игру СЛОВА! \nПравила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Введите первое слово для начала игры (от 8 до 30 символов)");
    Console.ResetColor();
    word = Console.ReadLine();//Ввод первоначального слова
}
///<summary>
///Checking the main word.
///If the length of the main word matches the rules, the game starts.
///Otherwise, the game ends with the appropriate message.
///</summary>
void CheckTheMainWord(string? word)
{
    int lg = word.Length;
    bool lgword = ((8 <= lg) & (lg <= 30)); //Длина первоначально вводимого слова – от 8 до 30 символов
    if (lgword == true)
    {
        Console.WriteLine("Хорошей игры!");
    }
    else
    {
        Console.WriteLine("Введено слово с неверным кол-вом символов или введено неверное значение");
        Environment.Exit(1);
    }
}
///<summary>
///If the player entered nothing, the game ends.
///If the player has entered a word, the word check starts.
/// The "ChekTheEnteredWordAgainstTheMainWord" method is used to check the entered words.
///</summary>
void Game(string symbols, string? word, string? word1, int turn)//Проверка слова введёного игроком по отношению к первоначальному слову
{
    if (word1.Length == 0)//Проверка ввёл ли игрок слово
    {
        Console.WriteLine("Вы ничего не ввели :(");
        Console.WriteLine($"Игра окончена! Победил игрок {turn}!");
        Environment.Exit(1);
    }
    else //Если игрок ввёл слово
    {
        ChekTheEnteredWordAgainstTheMainWord(symbols, word, word1, turn);
    }
}
///<summary>
///Comparing the symbols in the player's word to the main word.
///The "ChekingSymbolsInAWord" method is used to determine the number of symbols in the player's word and in the main word.
///</summary>
void ChekTheEnteredWordAgainstTheMainWord(string symbols, string? word, string? word1, int turn)
{
    int letterCounterForMainWord = 0;
    int letterCounterForUserWord = 0;
    for (int i = 0; i < symbols.Length; i++)//Проверка введённого слова по отношению первоначальному слову
    {
        if (i != 0)
        {
            if (letterCounterForMainWord < letterCounterForUserWord)//Если слово введённое игроком не соответствует по символам главному слову, то игра заканчивается. 
            {
                Console.WriteLine($"Игра окончена! Победил игрок {turn}!");
                Environment.Exit(1);
            }
        }
        ChekingSymbolsInAWord(symbols, word, word1, i, out letterCounterForMainWord, out letterCounterForUserWord);
    }
}
///<summary>
///Determining the number of symbols in the player's word and in the main word.
///</summary>
void ChekingSymbolsInAWord(string symbols, string? word, string? word1, int i, out int letterCounterForMainWord, out int letterCounterForUserWord)
{
    letterCounterForMainWord = 0;
    letterCounterForUserWord = 0;
    for (int j = 0; j < word.Length; j++)
    {
        if (symbols[i] == word[j])
        {
            letterCounterForMainWord++;
        }
    }
    for (int j = 0; j < word1.Length; j++)
    {
        if (symbols[i] == word1[j])
        {
            letterCounterForUserWord++;
        }
    }
}
///<summary>
///A 15-second timer is started for the first player.
///If the first player does not have time to enter the word, the timer will call the "FirstTime" method to end the game.
///If the first player manages to enter the word in 15 seconds, the timer will turn off.
///</summary>
void FirstPlayerEnterTheWord(out string? word1)
{
    TimerCallback tm = new TimerCallback(FirstTime); //Таймер на 15 сек
    Timer timer = new Timer(tm, num, 15000, 0);
    word1 = Console.ReadLine(); //Ввод слова игроком 1
    timer.Dispose();//Отключение таймера
}
///<summary>
///A timer for 15 seconds is started for the second player.
///If the second player does not have time to enter the word, the timer will call the "SecondTime" method to end the game.
///If the second player manages to enter the word in 15 seconds, the timer will turn off.
///</summary>
void SecondPlayerEnterTheWord(out string? word2)
{
    TimerCallback tm1 = new TimerCallback(SecondTime); //Таймер на 15 сек
    Timer timer1 = new Timer(tm1, num, 15000, 0);
    word2 = Console.ReadLine();//Ввод слова игроком 2
    timer1.Dispose();//Отключение таймера
}
///<summary>
///The game ends if the first player fails to enter within 15 seconds.
///</summary>
static void FirstTime(object? obj)//Если игрок 1 не успел ввести слово за 15 сек
{
    Console.WriteLine("Вы не успели! Победил игрок 2!");
    Environment.Exit(0);
}
///<summary>
///The game ends if the second player fails to enter within 15 seconds.
///</summary>
static void SecondTime(object? obj)//Если игрок 2 не успел ввести слово за 15 сек
{
    Console.WriteLine("Вы не успели! Победил игрок 1!");
    Environment.Exit(0);
}
/// <summary>
/// Change the text color for the first player to green. 
/// </summary>
void FirstPlayerTextColor()
{
    Console.WriteLine($"Ваше изначальное слово: {word}");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Игрок 1| Введите ваше слово! У вас 15 сек");
    Console.ResetColor();
}
/// <summary>
/// Change the text color for the second player to blue. 
/// </summary>
void SecondPlayerTextColor()
{
    Console.WriteLine($"Ваше изначальное слово: {word}");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Игрок 2| Введите ваше слово! У вас 15 сек");
    Console.ResetColor();
}