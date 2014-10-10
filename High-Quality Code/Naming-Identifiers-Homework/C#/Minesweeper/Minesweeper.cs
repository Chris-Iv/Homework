using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Minesweeper
    {
        public class Ranking
        {
            private string name;

            private int points;

            public string Player
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public int Points
            {
                get
                {
                    return points;
                }

                set
                {
                    points = value;
                }
            }

            public Ranking()
            {
            }

            public Ranking(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        private static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = createField();
            char[,] bombs = createBombs();
            int counter = 0;
            bool bang = false;
            List<Ranking> champions = new List<Ranking>(6);
            int row = 0;
            int column = 0;
            bool firstFlag = true;
            const int max = 35;
            bool secondFlag = false;

            do
            {
                if (firstFlag)
                {
                    Console.WriteLine(
                        "Lets play Minesweeper. Try your luck in finding the mine-free fields."
                        + " The command 'top' shows the ranking, 'restart' starts new game, 'exit' exits the game!");
                    dump(field);
                    firstFlag = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ranking(champions);
                        break;
                    case "restart":
                        field = createField();
                        bombs = createBombs();
                        dump(field);
                        bang = false;
                        firstFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                yourTurn(field, bombs, row, column);
                                counter++;
                            }

                            if (max == counter)
                            {
                                secondFlag = true;
                            }
                            else
                            {
                                dump(field);
                            }
                        }
                        else
                        {
                            bang = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (bang)
                {
                    dump(bombs);
                    Console.Write("\nHrrrrrr! You died heroicly {0} points. " + "Enter your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Ranking top = new Ranking(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(top);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < top.Points)
                            {
                                champions.Insert(i, top);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Ranking r1, Ranking r2) => r2.Player.CompareTo(r1.Player));
                    champions.Sort((Ranking r1, Ranking r2) => r2.Points.CompareTo(r1.Points));
                    ranking(champions);

                    field = createField();
                    bombs = createBombs();
                    counter = 0;
                    bang = false;
                    firstFlag = true;
                }

                if (secondFlag)
                {
                    Console.WriteLine("\nBRAVOOO! You opened all 35 cells without a drop of blood.");
                    dump(bombs);
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Ranking points = new Ranking(name, counter);
                    champions.Add(points);
                    ranking(champions);
                    field = createField();
                    bombs = createBombs();
                    counter = 0;
                    secondFlag = false;
                    firstFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Come on.");
            Console.Read();
        }

        private static void ranking(List<Ranking> points)
        {
            Console.WriteLine("\Points:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, points[i].Player, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("empty ranking!\n");
            }
        }

        private static void yourTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char bombsCount = count(bombs, row, column);
            bombs[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static void dump(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] createField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] createBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int rnd = random.Next(50);
                if (!r3.Contains(rnd))
                {
                    r3.Add(rnd);
                }
            }

            foreach (int i2 in r3)
            {
                int column = i2 / columns;
                int row = i2 % columns;
                if (row == 0 && i2 != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static void calculations(char[,] field)
        {
            int column = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char counter = count(field, i, j);
                        field[i, j] = counter;
                    }
                }
            }
        }

        private static char count(char[,] firstRow, int secondRow, int thirdRow)
        {
            int counter = 0;
            int rows = firstRow.GetLength(0);
            int columns = firstRow.GetLength(1);

            if (secondRow - 1 >= 0)
            {
                if (firstRow[secondRow - 1, thirdRow] == '*')
                {
                    counter++;
                }
            }

            if (secondRow + 1 < rows)
            {
                if (firstRow[secondRow + 1, thirdRow] == '*')
                {
                    counter++;
                }
            }

            if (thirdRow - 1 >= 0)
            {
                if (firstRow[secondRow, thirdRow - 1] == '*')
                {
                    counter++;
                }
            }

            if (thirdRow + 1 < columns)
            {
                if (firstRow[secondRow, thirdRow + 1] == '*')
                {
                    counter++;
                }
            }

            if ((secondRow - 1 >= 0) && (thirdRow - 1 >= 0))
            {
                if (firstRow[secondRow - 1, thirdRow - 1] == '*')
                {
                    counter++;
                }
            }

            if ((secondRow - 1 >= 0) && (thirdRow + 1 < columns))
            {
                if (firstRow[secondRow - 1, thirdRow + 1] == '*')
                {
                    counter++;
                }
            }

            if ((secondRow + 1 < rows) && (thirdRow - 1 >= 0))
            {
                if (firstRow[secondRow + 1, thirdRow - 1] == '*')
                {
                    counter++;
                }
            }

            if ((secondRow + 1 < rows) && (thirdRow + 1 < columns))
            {
                if (firstRow[secondRow + 1, thirdRow + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}