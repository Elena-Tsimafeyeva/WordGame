string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz";
string? word, word1, word2;
int num = 0;
int turn;
int letterCounterForMainWord;
int letterCounterForUserWord;
Console.WriteLine("Добро пожаловать в игру СЛОВА! \nПравила: Суть игры заключается в том, чтобы 2 пользователя поочередно вводили слова, состоящие\nиз букв первоначально указанного слова. Проигрывает тот, кто в свою очередь не вводит слово\nВведите первое слово для начала игры (от 8 до 30 символов)");
word = Console.ReadLine();//Ввод первоначального слова
Check(word);//Проверка первоначального слова
do
{
    FirstPlayerTextColor();
    TimerCallback tm = new TimerCallback(FirstTime); //Таймер на 15 сек
    Timer timer = new Timer(tm, num, 15000, 0);
    turn = 2;
    word1 = Console.ReadLine(); //Ввод слова игроком 1
    timer.Dispose();//Отключение таймера
    Game(alphabet,word, word1, turn);//Проверка слова введёного игроком 1 по отношению к первоначальному слову
    SecondPlayerTextColor();
    TimerCallback tm1 = new TimerCallback(SecondTime); //Таймер на 15 сек
    Timer timer1 = new Timer(tm1, num, 15000, 0);
    turn = 1;
    word2 = Console.ReadLine();//Ввод слова игроком 2
    timer1.Dispose();//Отключение таймера
    Game(alphabet,word, word2, turn);//Проверка слова введёного игроком 2 по отношению к первоначальному слову
}
while (true);
void Check(string? word)
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
void Game(string alphabet, string? word, string? word1, int turn)//Проверка слова введёного игроком по отношению к первоначальному слову
{
    letterCounterForMainWord = 0;
    letterCounterForUserWord = 0;
    if (word1 == null)//Проверка ввёл ли игрок слово
    {
        Console.WriteLine("Вы ничего не ввели :(");
        Console.WriteLine($"Игра окончена! Победил игрок {turn}!");
        Environment.Exit(1);
    }
    else //Если игрок ввёл слово
    {
        for (int i = 0; i < alphabet.Length; i++)//Проверка введённого слова по отношению первоначальному слову
        {
            if (i != 0)
            {
                if (letterCounterForMainWord < letterCounterForUserWord)
                {
                    Console.WriteLine($"Игра окончена! Победил игрок {turn}!");
                    Environment.Exit(1);
                }
            }
            letterCounterForMainWord = 0;
            letterCounterForUserWord = 0;
            for (int j = 0; j < word.Length; j++)
            {
                if (alphabet[i] == word[j])
                {
                    letterCounterForMainWord++;
                }
            }
            for (int j = 0; j < word1.Length; j++)
            {
                if (alphabet[i] == word1[j])
                {
                    letterCounterForUserWord++;
                }
            }
        }

    }
}
static void FirstTime(object? obj)//Если игрок 1 не успел ввести слово за 15 сек
{
    Console.WriteLine("Вы не успели! Победил игрок 2!");
    Environment.Exit(0);
}
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