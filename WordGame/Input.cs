using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame
{
    internal class Input
    {
        ///<summary>
        ///E.A.T. 26-August-2024
        ///Entering a word.
        ///</summary>
        internal static void Read(out string? word)
        {
            word = Console.ReadLine();
        }
    }
}
