using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.GameInterface
{
    public interface IHangman
    {
        public void DisplayState(int lives, char[] displayedWords, string guessedWords);
    }
}
