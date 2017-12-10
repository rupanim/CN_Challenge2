using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CN_Challenge2
{
    class Program
    {
        public static int checkLiveNeighboursCount(char [,] array, int indexI, int indexJ)
        {
            int numOfRows = array.GetLength(0);
            int numOfColumns = array.GetLength(1);
            int countLiveNeighbours = 0;

            if (indexJ - 1 >= 0)
            {
                countLiveNeighbours = (array[indexI, indexJ - 1] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;
            }

            if (indexJ + 1 < numOfColumns)
            {
                countLiveNeighbours = (array[indexI, indexJ + 1] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;
            }

            if (indexI - 1 >= 0)
            {
                countLiveNeighbours = (array[indexI - 1, indexJ] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;

                if (indexJ - 1 >= 0)
                {
                    countLiveNeighbours = (array[indexI - 1, indexJ - 1] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;
                }

                if (indexJ + 1 < numOfColumns)
                {
                    countLiveNeighbours = (array[indexI - 1, indexJ + 1] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;
                }
            }

            if (indexI + 1 < numOfRows)
            {
                countLiveNeighbours = (array[indexI + 1, indexJ] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;

                if (indexJ - 1 >= 0)
                {
                    countLiveNeighbours = (array[indexI + 1, indexJ - 1] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;
                }

                if (indexJ + 1 < numOfColumns)
                {
                    countLiveNeighbours = (array[indexI + 1, indexJ + 1] == 'L') ? (countLiveNeighbours + 1) : countLiveNeighbours;
                }
            }
            return countLiveNeighbours;
        }

        public static void ConwaysGame(char[,] array)
        {
            int numOfRows = array.GetLength(0);
            int numOfColumns = array.GetLength(1);
            for (int i = 0; i < numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    char currentCell = array[i, j];
                    int liveNeighbourCount = checkLiveNeighboursCount(array, i, j);
                    switch (liveNeighbourCount)
                    {
                        case 0:
                        case 1: if(currentCell == 'L')
                            {
                                array[i, j] = 'D';
                            }
                            break;
                        case 2: break;
                        case 3:
                            if (currentCell == 'D')
                            {
                                array[i, j] = 'L';
                            }
                            break;
                        default:
                            if (currentCell == 'L')
                            {
                                array[i, j] = 'D';
                            }
                            break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            char[,] grid = new char[16,16];
            int tick = 0;
            int numOfRows = grid.GetLength(0);
            int numOfColumns = grid.GetLength(1);

            for (int i=0;i< numOfRows; i++)
            {
                for (int j = 0; j < numOfColumns; j++)
                {
                    int temp = new Random().Next(0, 1);
                    if (temp == 0)
                    {
                        grid[i, j] = 'L';
                    }
                    else
                    {
                        grid[i, j] = 'D';
                    }
                }
            }

            Console.WriteLine("Initial Grid:");

            for (int i = 0; i < numOfRows; i++)
            {
                Console.Write("|");
                for (int j = 0; j < numOfColumns; j++)
                {
                    Console.Write("{0} | ", grid[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Thread.Sleep(2000);

            Console.WriteLine("The Game Starts now...");           

            Thread.Sleep(2000);

            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    ConwaysGame(grid);
                    for (int i = 0; i < numOfRows; i++)
                    {
                        Console.Write("|");
                        for (int j = 0; j < numOfColumns; j++)
                        {
                            Console.Write("{0} | ", grid[i, j]);
                        }
                        Console.WriteLine();
                    }
                    tick++;
                    Console.WriteLine("Tick Count: {0}", tick);
                    Console.WriteLine("Press ESC to stop");
                    Thread.Sleep(2000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);        

        }
    }
}
