using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame;

namespace WordGameTests
{
    public class GameLogicTests
    {
        [Fact]
        public void CheckingForIncorrectSymbolsInTheMainWord_TheCorrectWord_Eng()
        {
            string initialWord = "abcdefgh";
            string secondAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string symbolsAndNumbers = "1234567890@#£_&-+()/*':;!?~`|•√π÷×§∆€¥$¢^°={}%©®™✓[]<>,.";
            string eng = "1";
            string rus = "2";
            string language = eng;
            GameLogic gameLogic = new GameLogic();
            gameLogic.CheckingForIncorrectSymbolsInTheMainWord(out bool checkCorrect, initialWord, secondAlphabet, symbolsAndNumbers, true, false, language, eng, rus, 8, 30, "Player 1", "Player 2", 0);
            Assert.True(checkCorrect);
        }
        [Fact]
        public void ErrorMessageToCheckTheMainWord_InvalidAlphabet_Eng()
        {
            int check = 1;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "When entering the main word, you used letters of the Russian alphabet, not English.";
            GameLogic.ErrorMessageToCheckTheMainWord(check, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void ErrorMessageToCheckTheMainWord_InvalidAlphabet_Rus()
        {
            int check = 1;
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "При вводе главного слова вы использовали буквы английского алфавита, а не русского.";
            GameLogic.ErrorMessageToCheckTheMainWord(check, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void ErrorMessageToCheckTheMainWord_UseOfSymbolsOrNumbers_Eng()
        {
            int check = 2;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "You used symbols or numbers when entering the main word.";
            GameLogic.ErrorMessageToCheckTheMainWord(check, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void ErrorMessageToCheckTheMainWord_UseOfSymbolsOrNumbers_Rus()
        {
            int check = 2;
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "При вводе главного слова вы использовали символы или цифры.";
            GameLogic.ErrorMessageToCheckTheMainWord(check, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void CheckTheMainWord_TheNumberOfCharactersIsCorrect_Eng()
        {
            string initialWord = "abcdefghi";
            string eng = "1";
            string rus = "2";
            string language = eng;
            int minNumberOfSymbolsInTheMainWord = 8;
            int maxNumberOfSymbolsInTheMainWord = 30;
            string resultMessageEng = "Have a nice game!";
            GameLogic gameLogic = new GameLogic();
            gameLogic.CheckTheMainWord(initialWord, language, eng, rus, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, true, false, "secondAlphabet", "symbolsAndNumbers", "Player 1", "Player 2", 0, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void CheckTheMainWord_TheNumberOfCharactersIsCorrect_Rus()
        {
            string initialWord = "абвгдеёжз";
            string eng = "1";
            string rus = "2";
            string language = rus;
            int minNumberOfSymbolsInTheMainWord = 8;
            int maxNumberOfSymbolsInTheMainWord = 30;
            string resultMessageRus = "Хорошей игры!";
            GameLogic gameLogic = new GameLogic();
            gameLogic.CheckTheMainWord(initialWord, language, eng, rus, minNumberOfSymbolsInTheMainWord, maxNumberOfSymbolsInTheMainWord, true, false, "secondAlphabet", "symbolsAndNumbers", "Player 1", "Player 2", 0, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
    }
}
