using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace L1_start
{
    static class InOut
    {
        public static Crossword ReadTxt(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int wordCount = Convert.ToInt32(lines[0]);
            string[] Words = new string[wordCount];
            for (int i = 1; i <= wordCount; i++)
            {
                Words[i-1]=(lines[i]);
            }
            string[] values = lines[wordCount + 1].Split(' ');
            int rows = Convert.ToInt32(values[0]);
            int columns = Convert.ToInt32(values[1]);
            char[,] Board = new char[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                int cols = 0;
                foreach (char Character in lines[wordCount + 2 + i])
                {
                    Board[i, cols] = Character;
                    cols++;
                }
            }
            return new Crossword(wordCount, Words, rows, columns, Board);
        }
    }
}
