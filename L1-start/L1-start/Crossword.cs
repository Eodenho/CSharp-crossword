using System;
using System.Collections.Generic;
using System.Text;

namespace L1_start
{
    class Crossword
    {
        public int WordCount { get; set; }
        public string[] Words { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public char[,] Board { get; set; }
        public Crossword(int wordCount , string[] words, int rows , int columns, char[,] board)
        {
            this.WordCount = wordCount;
            this.Words = words;
            this.Rows = rows;
            this.Columns = columns;
            this.Board = board;
        }
        public void draw()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    Console.Write(Board[i,j]);
                }
                Console.WriteLine();
            }
        }
        private bool ExistCharacter(int i, int j, int searchIndex, string searchWord, int number)
        {
            // when reached outside the board  
            if (i < 0 || i >= this.Rows || j < 0 || j >= this.Columns)
                return false;

            // when index character does not match  
            if (Board[i,j] != searchWord[searchIndex])
                return false;

            // when completely matched  
            if (searchIndex == searchWord.Length - 1)
            {
                Board[i,j] = Convert.ToChar(Convert.ToString(number));
                return true;
            }

            // mark the current character  
            Board[i,j] = Convert.ToChar(Convert.ToString(number));

            // check every direction  
            bool found = ExistCharacter(i, j - 1, searchIndex + 1, searchWord,number) ||
                ExistCharacter(i, j + 1, searchIndex + 1, searchWord, number) ||
                ExistCharacter(i - 1, j, searchIndex + 1, searchWord, number) ||
                ExistCharacter(i + 1, j, searchIndex + 1, searchWord, number);

            // unmark the current character 
            if (!found)
                Board[i,j] = searchWord[searchIndex];

            return found;
        }
        /*
        public bool Exist(string searchWord)
        {
            if (searchWord == "")
                return false;

            // iterate over the board  
            for (int i = 0; i < Board.Count; i++)
            {
                for (int j = 0; j < Board[i].Count; j++)
                {
                    // check first character  
                    if (ExistCharacter(i, j, 0, searchWord))
                        return true;
                }
            }
            return false;
        }
        */
        public bool CheckAllWords()
        {
            for (int i = 0; i < this.Words.Length; i++)
            {
                for (int j = 0; j < this.Rows; j++)
                {
                    for (int k = 0; k < this.Columns; k++)
                    {
                        ExistCharacter(j, k, 0, Words[i], i + 1);
                    }
                }
            }
            return false;
        }
        public int[] SolutionCount()
        {
            int[] answers = new int[Columns];
            for (int i = 0; i < this.Columns; i++)
            {
                answers[i] = 0;
                for (int j = 0; j < this.Rows; j++)
                {
                    if (Char.IsDigit(Board[j,i]))
                    {
                        answers[i] += Convert.ToInt32(Convert.ToString(Board[j,i]));
                    }
                }
            }    
            return answers;
        }
    }
}
