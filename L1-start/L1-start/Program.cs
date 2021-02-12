using System;

namespace L1_start
{
    class Program
    {
        static void Main(string[] args)
        {
            Crossword game = InOut.ReadTxt(@"failas.txt");
            game.CheckAllWords();
            game.draw();
            for (int i = 0; i < game.Columns; i++)
            {
                Console.Write("{0} ",game.SolutionCount()[i]);
            }

        }
    }
}
