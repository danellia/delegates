using System;

namespace MatrixCalculator
{
	public class SquareMatrix : IComparable
	{
		private double[,] matrix = new double[size, size];

		public double this[int x, int y]
		{
			get
			{
				return matrix[x, y];
			}
			set
			{
				matrix[x, y] = value;
			}
		}

		public static int size;
		public static void GetSize()
		{
			Random random = new Random();
			size = random.Next(2, 3);
		}

		public SquareMatrix()
		{
			Random random = new Random();

			for (int rowIndex = 0; rowIndex < size; ++rowIndex)
			{
				for (int colIndex = 0; colIndex < size; ++colIndex)
				{
					matrix[rowIndex, colIndex] = random.Next(1000);
				}
			}
		}

		public override string ToString()
		{
			string result = "\n";
			for (int rowIndex = 0; rowIndex < size; ++rowIndex)
			{
				for (int colIndex = 0; colIndex < size; ++colIndex)
				{
					if (this[rowIndex, colIndex] == 0)
                    {
						result += "0      ";
                    } else {
						result += String.Format("{0,-7:#}", this[rowIndex, colIndex]);
					}
				}
				result += "\n";
			}
			result += "\n";
			return result;
		}

		public static double Determinant(SquareMatrix mt)
		{
			double det = -1.0;
			switch (size)
			{
				case 2:
					det = mt[0, 0] * mt[1, 1] - mt[0, 1] * mt[1, 0];
					break;
				case 3:
					det = mt[0, 0] * (mt[1, 1] * mt[2, 2] - mt[1, 2] * mt[2, 1]) -
						mt[0, 1] * (mt[1, 0] * mt[2, 2] - mt[1, 2] * mt[2, 0]) +
						mt[0, 2] * (mt[1, 0] * mt[2, 1] - mt[1, 1] * mt[2, 0]);
					break;
			}
			return det;
		}

		public static SquareMatrix Inverse(SquareMatrix mt)
		{
			double det = Determinant(mt);
			SquareMatrix result = new SquareMatrix();
            if (det == 0)
            {
				throw new NonInversibleMatrixException("Данная матрица вырождена => необратима");
            }
			else
            {
				for (int rowIndex = 0; rowIndex < size; ++rowIndex)
				{
					for (int colIndex = 0; colIndex < size; ++colIndex)
					{
						result[rowIndex, colIndex] = mt[colIndex, rowIndex] / det;
					}
				}
				return result;
            }
		}

		public static SquareMatrix operator +(SquareMatrix left, SquareMatrix right)
		{
			SquareMatrix result = new SquareMatrix();
			for (int rowIndex = 0; rowIndex < size; ++rowIndex)
			{
				for (int colIndex = 0; colIndex < size; ++colIndex)
				{
					result[rowIndex, colIndex] = left[rowIndex, colIndex] + right[rowIndex, colIndex];
				}

			}
			return result;
		}

		public static SquareMatrix operator --(SquareMatrix mt)
		{
			SquareMatrix result = new SquareMatrix();
			for (int rowIndex = 0; rowIndex < size; ++rowIndex)
			{
				for (int colIndex = 0; colIndex < size; ++colIndex)
				{
					result[rowIndex, colIndex] = mt[rowIndex, colIndex] - 1;
				}

			}
			return result;
		}

		public static SquareMatrix operator *(int left, SquareMatrix right)
		{
			SquareMatrix result = new SquareMatrix();
			for (int rowIndex = 0; rowIndex < size; ++rowIndex)
			{
				for (int colIndex = 0; colIndex < size; ++colIndex)
				{
					result[rowIndex, colIndex] = left * right[rowIndex, colIndex];
				}

			}
			return result;
		}

		public override bool Equals(object obj)
		{
			bool result = false;
			if (obj is SquareMatrix && obj == this)
			{
				result = true;
			}
			return result;
		}

		public override int GetHashCode()
		{
			double det = Determinant(this);
			return (int)det;
		}

		int IComparable.CompareTo(object obj)
        {
			if (obj is SquareMatrix)
            {
				var param = obj as SquareMatrix;
				if (Determinant(param) > Determinant(this)) return -1;
				if (Determinant(param) == Determinant(this)) return 0;
				if (Determinant(param) < Determinant(this)) return 1;
				
			}
			return -1;
        }
	}

	public static class SquareMatrixExtensions
    {
		public static SquareMatrix Transpose(this SquareMatrix mt)
		{
			SquareMatrix result = new SquareMatrix();
			for (int rowIndex = 0; rowIndex < SquareMatrix.size; ++rowIndex)
			{
				for (int colIndex = 0; colIndex < SquareMatrix.size; ++colIndex)
				{
					result[rowIndex, colIndex] = mt[colIndex, rowIndex];
				}
			}
			return result;
		}


		public static double Trace(this SquareMatrix mt)
		{
			double trace = 0.0;
			for (int rowIndex = 0; rowIndex < SquareMatrix.size; ++rowIndex)
			{
				trace += mt[rowIndex, rowIndex];
			}
			return trace;
		}
	}
}