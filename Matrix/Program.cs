using System;

namespace MatrixCalculator
{
	delegate SquareMatrix DiagonalMatrix(SquareMatrix mt);

	class Program
	{
		static void Main(string[] args)
		{
			SquareMatrix.GetSize();
			Chain chain = new Chain();
			Console.WriteLine(chain.menu);

			while (true)
			{
				int userIndex = Convert.ToInt32(Console.ReadLine());
				chain.Run(userIndex);
			}
		}
	}
}