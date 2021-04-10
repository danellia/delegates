﻿using System;

namespace MatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
			SquareMatrix.GetSize();
            SquareMatrix firstMatrix = new SquareMatrix();
            SquareMatrix secondMatrix = new SquareMatrix();

			Console.WriteLine("Matrix 1: " + firstMatrix.ToString());
			Console.WriteLine("Matrix 2: " + secondMatrix.ToString());
            while (true)
            {
				Console.WriteLine("\nЧто сделать?\n" +
					"1 - сложение\n" +
					"2 - декремент 1\n" +
					"3 - умножение 2 матрицы на 2\n" +
					"4 - детерминант 1 матрицы\n" +
					"5 - детерминант 2 матрицы\n" +
					"6 - инверсия 1\n" +
					"7 - транспонирование 2\n" +
					"8 - gethashcode 1\n" +
					"9 - gethashcode 2\n" +
					"10 - equals\n" +
					"11 - след 1\n" +
					"12 - след 2\n" +
					"Другая клавиша для выхода\n");

				int userIndex = Convert.ToInt32(Console.ReadLine());
				switch (userIndex)
				{
					case 1:
						Console.WriteLine((firstMatrix + secondMatrix).ToString());
						break;
					case 2:
						Console.WriteLine((--firstMatrix).ToString());
						break;
					case 3:
						Console.WriteLine((2 * secondMatrix).ToString());
						break;
					case 4:
						Console.WriteLine(SquareMatrix.Determinant(firstMatrix));
						break;
					case 5:
						Console.WriteLine(SquareMatrix.Determinant(secondMatrix));
						break;
					case 6:
						SquareMatrix inversedFirst = SquareMatrix.Inverse(firstMatrix);
						Console.WriteLine(inversedFirst.ToString());
						break;
					case 7:
                        SquareMatrix transposedSecond = SquareMatrix.Transpose(secondMatrix);
						Console.WriteLine(transposedSecond.ToString());
						break;
					case 8:
						Console.WriteLine(firstMatrix.GetHashCode());
						break;
					case 9:
						Console.WriteLine(secondMatrix.GetHashCode());
						break;
					case 10:
						Console.WriteLine(firstMatrix.Equals(secondMatrix));
						break;
					case 11:
						Console.WriteLine(SquareMatrix.Trace(firstMatrix));
						break;
					case 12:
						Console.WriteLine(SquareMatrix.Trace(secondMatrix));
						break;
					default:
						break;
				}
            }
		}
    }
}