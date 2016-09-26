﻿using System;

namespace GameFifteen
{
    public class WalkInMatrica
    {
        public static void Change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[cd + 1];

            dy = dirY[cd + 1];
        }

        public static bool Check(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (var i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }
                
                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }
            for (var i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;

                        return;
                    }
                }
            }

        }

        public static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}
            var n = 3;
            var matrix = new int[n, n];
            var step = n;
            var k = 1;
            var i = 0;
            var j = 0;
            var dx = 1;
            var dy = 1;
            while (true)
            { //malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[i, j] = k;
                if (!Check(matrix, i, j))
                {
                    break;
                }// prekusvame ako sme se zadunili

                if (i + dx >= n ||
                    i + dx < 0 ||
                    j + dy >= n ||
                    j + dy < 0 ||
                    matrix[i + dx, j + dy] != 0)
                {
                    while ((i + dx >= n ||
                        i + dx < 0 ||
                        j + dy >= n ||
                        j + dy < 0 ||
                        matrix[i + dx, j + dy] != 0))
                    {
                        Change(ref dx, ref dy);

                    }
                }

                i += dx; j += dy; k++;
            }
            for (var p = 0; p < n; p++)
            {
                for (var q = 0; q < n; q++)
                {
                    Console.Write($"{matrix[p, q],3}");
                }

                Console.WriteLine();
            }

            FindCell(matrix, out i, out j);

            if (i != 0 && j != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                dx = 1;
                dy = 1;

                while (true)
                { //malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[i, j] = k;
                    if (!Check(matrix, i, j))
                    {
                        break;
                    }// prekusvame ako sme se zadunili

                    if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
                    {
                        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0))
                        {
                            Change(ref dx, ref dy);

                        }
                    }

                    i += dx; j += dy; k++;
                }
            }

            for (var pp = 0; pp < n; pp++)
            {
                for (var qq = 0; qq < n; qq++)
                {
                    Console.Write($"{matrix[pp, qq],3}");

                }
                Console.WriteLine();
            }
        }
    }
}