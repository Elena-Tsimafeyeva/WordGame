﻿using System;
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
        public void ErrorMessageToCheckTheMainWord_ErrorCheck_Eng()
        {
            int check = 0;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "messageEng";
            GameLogic.ErrorMessageToCheckTheMainWord(check, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
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
        [Fact]
        public void ErrorMessagesInTheGameMethod_GameOver_Eng()
        {
            int check = 1;
            int turn = 1;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = $"Game over! Player {turn} wins!";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void ErrorMessagesInTheGameMethod_GameOver_Rus()
        {
            int check = 1;
            int turn = 2;
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = $"Игра окончена! Победил игрок {turn}!";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void ErrorMessagesInTheGameMethod_WrongAlphabet_Eng()
        {
            int check = 2;
            int turn = 1;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = $"You entered letters from the Russian alphabet, not English.\nGame over! Player {turn} wins!";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void ErrorMessagesInTheGameMethod_WrongAlphabet_Rus()
        {
            int check = 2;
            int turn = 2;
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = $"Вы ввели буквы из английского алфавита, а не русского.\nИгра окончена! Победил игрок {turn}!";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void ErrorMessagesInTheGameMethod_CharactersOrNumbers_Eng()
        {
            int check = 3;
            int turn = 1;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = $"You have entered characters or numbers.\nGame over! Player {turn} wins!";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void ErrorMessagesInTheGameMethod_CharactersOrNumbers_Rus()
        {
            int check = 3;
            int turn = 2;
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = $"Вы ввели символы или цифры.\nИгра окончена! Победил игрок {turn}!";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void ErrorMessagesInTheGameMethod_ErrorCheck_Eng()
        {

            int check = 0;
            int turn = 1;
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "messageEng";
            GameLogic.ErrorMessagesInTheGameMethod(check, turn, language, eng, rus, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void FirstPlayerTextColor_Eng()
        {
            string initialWord = "abcdefghi";
            string firstName = "Player 1";
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageInitialWordEng = $"Your initial word: {initialWord}";
            string resultMessageEnterWordEng = $"Player 1 | {firstName} | Enter your word! You have 15 seconds";
            GameLogic.FirstPlayerTextColor(initialWord, firstName, language, eng, rus, out string messageInitialWordEng, out string messageInitialWordRus, out string messageEnterWordEng, out string messageEnterWordRus);
            Assert.Equal(resultMessageInitialWordEng, messageInitialWordEng);
            Assert.Equal(resultMessageEnterWordEng, messageEnterWordEng);
        }
        [Fact]
        public void FirstPlayerTextColor_Rus()
        {
            string initialWord = "абвгдеёжз";
            string firstName = "Player 1";
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageInitialWordRus = $"Ваше изначальное слово: {initialWord}";
            string resultMessageEnterWordRus = $"Игрок 1 | {firstName} | Введите ваше слово! У вас 15 сек";
            GameLogic.FirstPlayerTextColor(initialWord, firstName, language, eng, rus, out string messageInitialWordEng, out string messageInitialWordRus, out string messageEnterWordEng, out string messageEnterWordRus);
            Assert.Equal(resultMessageInitialWordRus, messageInitialWordRus);
            Assert.Equal(resultMessageEnterWordRus, messageEnterWordRus);
        }
        [Fact]
        public void SecondPlayerTextColor_Eng()
        {
            string initialWord = "abcdefghi";
            string secondName = "Player 2";
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageInitialWordEng = $"Your initial word: {initialWord}";
            string resultMessageEnterWordEng = $"Player 2 | {secondName} | Enter your word! You have 15 seconds";
            GameLogic.SecondPlayerTextColor(initialWord, secondName, language, eng, rus, out string messageInitialWordEng, out string messageInitialWordRus, out string messageEnterWordEng, out string messageEnterWordRus);
            Assert.Equal(resultMessageInitialWordEng, messageInitialWordEng);
            Assert.Equal(resultMessageEnterWordEng, messageEnterWordEng);
        }
        [Fact]
        public void SecondPlayerTextColor_Rus()
        {
            string initialWord = "абвгдеёжз";
            string secondName = "Player 2";
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageInitialWordRus = $"Ваше изначальное слово: {initialWord}";
            string resultMessageEnterWordRus = $"Игрок 2 | {secondName} | Введите ваше слово! У вас 15 сек";
            GameLogic.SecondPlayerTextColor(initialWord, secondName, language, eng, rus, out string messageInitialWordEng, out string messageInitialWordRus, out string messageEnterWordEng, out string messageEnterWordRus);
            Assert.Equal(resultMessageInitialWordRus, messageInitialWordRus);
            Assert.Equal(resultMessageEnterWordRus, messageEnterWordRus);
        }
        [Fact]
        public void ChekingSymbolsInAWord_Test()
        {
            string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string? initialWord = "abcdefghi";
            string? playerInput = "cde";
            int i = 2;
            GameLogic.ChekingSymbolsInAWord(symbols, initialWord, playerInput, i, out int letterCounterForMainWord, out int letterCounterForUserWord);
            Assert.Equal(1, letterCounterForMainWord);
            Assert.Equal(1, letterCounterForUserWord);
        }
    }
}
