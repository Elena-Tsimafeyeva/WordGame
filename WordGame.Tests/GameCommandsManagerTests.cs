using Microsoft.VisualStudio.TestPlatform.Utilities;
using WordGame;
namespace WordGameTests
{
    public class GameCommandsManagerTests
    {

        [Fact]
        public void CommandHelpEng()
        {
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "List of commands:\n/help - show the entire list of commands.\n/show-words – show all words entered by both users in the current game.\n/score – show the total game score for current players (extract from file).\n/total-score – show the total score for all players.\n/exit - end of the round (defeat is counted to the player who had to enter\na word at the moment of exiting the round).";
            GameCommandsManager.Commands("/help", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void CommandHelpRus() {
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "Список команд:\n/help - показать весь список команд.\n/show-words - показать все введенные обоими пользователями слова в текущей игре.\n/score - показать общий счет по играм для текущих игроков (извлечь из файла).\n/total-score - показать общий счет для всех игроков.\n/exit - завершение раунда (поражение засчитывается игроку, который на\nмомент выхода из раунда должен был вводить слово).";
            GameCommandsManager.Commands("/help", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void CommandShowWordsEng() {
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "List of words for this game.";
            GameCommandsManager.Commands("/show-words", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void CommandShowWordsRus() {
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "Список слов за эту игру.";
            GameCommandsManager.Commands("/show-words", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void CommandScoreEng() {
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "Show the total game score for current players (extract from file).";
            GameCommandsManager.Commands("/score", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void CommandScoreRus() {
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "Показать общий счет по играм для текущих игроков (извлечь из файла).";
            GameCommandsManager.Commands("/score", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void CommandTotalScoreEng() {
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "Show the total score for all players.";
            GameCommandsManager.Commands("/total-score", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void CommandTotalScoreRus() {
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "Показать общий счет для всех игроков.";
            GameCommandsManager.Commands("/total-score", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void CommandExitEng() {
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageEng = "End of the round.";
            GameCommandsManager.Commands("/exit", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageEng, messageEng);
        }
        [Fact]
        public void CommandExiRus() {
            string eng = "1";
            string rus = "2";
            string language = rus;
            string resultMessageRus = "Завершение раунда.";
            GameCommandsManager.Commands("/exit", language, eng, rus, "Player 1", "Player 2", true, false, 0, "initalWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageEng, out string messageRus);
            Assert.Equal(resultMessageRus, messageRus);
        }
        [Fact]
        public void ExitCommandUntilTheRoundIsStarted() {
            string eng = "1";
            string rus = "2";
            string language = eng;
            string resultMessageExitEng = "You cannot complete the round because it has not started.";
            GameCommandsManager.ExitCommand(language, eng, rus, true, false, "Player 1", "Player 2", 0, "initialWord", "secondAlphabet", "symbolsAndNumbers", 8, 30, out string messageExitEng, out string MessageRus);
            Assert.Equal(resultMessageExitEng, messageExitEng);
        }
    }
}
