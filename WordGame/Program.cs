//E.A.T. 15-August-2024
//The variable "symbols" is declared, which contains symbols for word checking.
//Declared "word, word1, word2" variables for inputting the main word and players' words.
//The variable "number" for the timer is declared.
string symbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz1234567890!?@#$%^&*()_-=+№;:<>.,/|`~{}[] ";
string? initialWord, firstPlayerInput, secondPlayerInput;
int num = 0;
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
    Console.WriteLine("Добро пожаловать в игру СЛОВА! \nПравила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Введите первое слово для начала игры (от 8 до 30 символов)");
    Console.ResetColor();
    initialWord = Console.ReadLine();//Ввод первоначального слова
}
///<summary>
///E.A.T. 15-August-2024
///Checking the main word.
///If the length of the main word matches the rules, the game starts.
///Otherwise, the game ends with the appropriate message.
///</summary>
void CheckTheMainWord(string? initialWord)
{
    int lg = initialWord.Length;
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
///E.A.T. 15-August-2024
///If the player entered nothing, the game ends.
///If the player has entered a word, the word check starts.
/// The "ChekTheEnteredWordAgainstTheMainWord" method is used to check the entered words.
///</summary>
void Game(string symbols, string? initialWord, string? playerInput, int turn)//Проверка слова введёного игроком по отношению к первоначальному слову
{
    if (playerInput.Length == 0)//Проверка ввёл ли игрок слово
    {
        Console.WriteLine("Вы ничего не ввели :(");
        Console.WriteLine($"Игра окончена! Победил игрок {turn}!");
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
                Console.WriteLine($"Игра окончена! Победил игрок {turn}!");
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
    Timer timer = new Timer(tm, num, 15000, 0);
    firstPlayerInput = Console.ReadLine(); //Ввод слова игроком 1
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
    Timer timer1 = new Timer(tm1, num, 15000, 0);
    secondPlayerInput = Console.ReadLine();//Ввод слова игроком 2
    timer1.Dispose();//Отключение таймера
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the first player fails to enter within 15 seconds.
///</summary>
static void FirstTime(object? obj)//Если игрок 1 не успел ввести слово за 15 сек
{
    Console.WriteLine("Вы не успели! Победил игрок 2!");
    Environment.Exit(0);
}
///<summary>
///E.A.T. 15-August-2024
///The game ends if the second player fails to enter within 15 seconds.
///</summary>
static void SecondTime(object? obj)//Если игрок 2 не успел ввести слово за 15 сек
{
    Console.WriteLine("Вы не успели! Победил игрок 1!");
    Environment.Exit(0);
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the first player to green. 
/// </summary>
void FirstPlayerTextColor()
{
    Console.WriteLine($"Ваше изначальное слово: {initialWord}");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Игрок 1| Введите ваше слово! У вас 15 сек");
    Console.ResetColor();
}
/// <summary>
/// E.A.T. 12-August-2024
/// Change the text color for the second player to blue. 
/// </summary>
void SecondPlayerTextColor()
{
    Console.WriteLine($"Ваше изначальное слово: {initialWord}");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Игрок 2| Введите ваше слово! У вас 15 сек");
    Console.ResetColor();
}