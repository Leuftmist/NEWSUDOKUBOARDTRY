using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] board = new int[9, 9];
            int[] shout = new int[] { 0, 0, 0 };
            int counter = 0;
            bool loop = true;
            List<int>[] row = new List<int>[9];
            List<int>[] col = new List<int>[9];
            List<int>[] cell = new List<int>[9];

            

            while (loop)
            {
                for (int z = 0; z < col.Length; z++)
                {
                    row[z] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    col[z] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    cell[z] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                }

                for (int x = 0; x < 9; x++)
                {
                    
                    for (int y = 0; y < 9; y++)
                    {
                        board[x, y] = 0;
                                
                        for (int l = 0; l < 10000; l++)
                        {
                            int cell1 = (3 * (x / 3)) + (y / 3);
                            shout[0] = row[x][rnd.Next(0, row[x].Count)];
                            shout[1] = col[y][rnd.Next(0, col[y].Count)];
                            shout[2] = cell[cell1][rnd.Next(0, cell[cell1].Count)];
                            if (shout[0] == shout[1] && shout[1] == shout[2])
                            {
                                Console.WriteLine(shout[0]);
                                int placeholder = shout[0];
                                board[x, y] = placeholder;
                                row[x].Remove(placeholder);
                                col[y].Remove(placeholder);
                                cell[cell1].Remove(placeholder);
                                break;
                            }
                        }
                    }
                }
                for(int kek = 0; kek < 9; kek++)
                {
                    for (int monk = 0; monk < 9; monk++)
                    {
                        if (board[kek, monk] == 0)
                        {
                            loop = true;
                            break;
                        }
                        else if (board[kek, monk] != 0)
                        {
                            loop = false;
                            
                        }
                    }
                    if(loop == true)
                    {
                        break;
                    }
                }
                
                counter++;

            }
            Console.WriteLine("This is the number of atttempts: " + counter);
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Console.Write(board[x, y] + "\t");
                    

                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
