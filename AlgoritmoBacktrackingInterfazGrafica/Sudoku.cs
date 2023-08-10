using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace AlgoritmoBacktrackingInterfazGrafica
{
    public class Sudoku
    {
        public int Dimension;
        public int[,] tablero = new int[9, 9];

        public void imprimir(int[,] tablero)
        {
            for (int i = 0; i < Dimension; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                }
                for (int j = 0; j < Dimension; j++)
                {
                    if (j % 3 == 0)
                    {
                        Console.Write(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int[,] tableroResuelto(int[,] tablero)
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (tablero[i, j] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        for (int k = 1; k <= 9; k++)
                        {
                            if (esPosibleInsertar(tablero, i, j, k))
                            {
                                tablero[i, j] = k;
                                Boolean b = resolver(tablero);

                                if (b)
                                {
                                    //return tablero;
                                }
                                tablero[i, j] = 0;
                            }
                        }
                       // return tablero;
                    }
                }
            }
      
            return tablero;
        }

        public Boolean resolver( int[,] tablero)
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (tablero[i, j] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        for (int k = 1; k <= 9; k++)
                        {
                            if (esPosibleInsertar(tablero, i, j, k))
                            {
                                tablero[i, j] = k;
                                Boolean b = resolver(tablero);

                                if (b)
                                {
                                    return true;
                                }
                                tablero[i, j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Solucion Encontrada");
            imprimir(tablero);
            return true;
        }

        public Boolean esPosibleInsertar(int[,] tablero, int i, int j, int valor)
        {
            for (int a = 0; a < Dimension; a++)
            {
                if (a != i && tablero[a, j] == valor)
                {
                    return false;
                }
            }
            for (int a = 0; a < Dimension; a++)
            {
                if (a != j && tablero[i, a] == valor)
                {
                    return false;
                }
            }

            int y = (i / 3) * 3;
            int x = (j / 3) * 3;

            for (int a = 0; a < Dimension / 3; a++)
            {
                for (int b = 0; b < Dimension / 3; b++)
                {
                    if (a != i && b != j && tablero[y + a, x + b] == valor)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public int[,] GenerarTablero()
        {
            //for (int i = 0; i < 9; i += 6)
            //{
            //    for (int j = 0; j < 9; j += 3)
            //    {
            //        RellenarSubmatriz(i, j);
            //    }

            //}
            //imprimir(tablero);
            Random rand = new Random();
            int randi = rand.Next(0,9);
            int randj = rand.Next(0,9);
            RellenarSubmatriz(randi, randj);



            if (resolver(tablero))
            {
                QuitarValores();
               // imprimir(tablero);
            }
            else
            {
                // Console.WriteLine("No se econtro solucion");

                GenerarTablero();
            }

            return tablero;
        }

        public void RellenarSubmatriz(int filaInicio, int colInicio)
        {
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rand = new Random();

            int randomNum = rand.Next(1, 10);
            int randi = rand.Next(filaInicio, filaInicio);
            int randj = rand.Next(colInicio, colInicio);

            tablero[randi, randj] = randomNum;

        }


        public void QuitarValores()
        {
            Random rand = new Random();
            int valoresAQuitar = rand.Next(40, 56);

            for (int i = 0; i < valoresAQuitar; i++)
            {
                int fila = rand.Next(9);
                int columna = rand.Next(9);
                while (tablero[fila, columna] == 0)
                {
                    fila = rand.Next(9);
                    columna = rand.Next(9);
                }
                tablero[fila, columna] = 0;
            }
        }



        public int[,] IngresarTablero()
        {
            int[,] tablero = new int[Dimension, Dimension];
            Console.WriteLine("Ingrese el tablero de Sudoku (use 0 para los espacios en blanco):");

            for (int i = 0; i < Dimension; i++)
            {
                string[] valores = Console.ReadLine().Split(' ');
                for (int j = 0; j < Dimension; j++)
                {
                    tablero[i, j] = int.Parse(valores[j]);
                }
            }

            return tablero;
        }

        //static void Main(string[] args)
        //{

        //    Sudoku sudoku = new Sudoku();

        //    int[,] tablero1 = new int[,]
        //    {
        //        {0, 7, 0,   0, 0, 0,    0, 8, 0},
        //        {0, 5, 8,   6, 0, 0,    0, 0, 1},
        //        {0, 0, 3,   1, 4, 0,    0, 0, 0},

        //        {9, 0, 6,    0, 5, 0,   3, 0, 0},
        //        {0, 0, 0,    0, 0, 0,    0, 0, 0},
        //        {0, 0, 5,    0, 2, 0,   1, 0, 7},

        //        {0, 0, 0,   0, 6, 5,    7, 0, 0},
        //        {3, 0, 0,   0, 0, 1,    9, 2, 0},
        //        {0, 4, 0,   0, 0, 0,    0, 1, 0},
        //    };



        //    Dimension = tablero1.GetLength(0);
        //    Console.WriteLine("El Juego a resolver es: ");
        //    imprimir(tablero1);

        //    if (!resolver(tablero1))
        //    {
        //        Console.WriteLine("El Sudoku no tiene solucion");
        //    }
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Cyan;

        //    sudoku.GenerarTablero();
        //}
    }

    //internal class Sudoku
    //{
    //}

}
