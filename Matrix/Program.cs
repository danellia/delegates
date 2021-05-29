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
			
			while (true)
			{
				chain.Run();
				/*
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
						SquareMatrix transposedSecond = secondMatrix.Transpose();
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
						Console.WriteLine(firstMatrix.Trace());
						break;
					case 12:
						Console.WriteLine(diagonal(secondMatrix).ToString());
						break;
					default:
						break;
				}*/
			}
		}
	}

	public class Chain
	{
		public Chain()
		{
			eventHandler = new HandlerStart();
		}
		public void Run()
		{
			Console.WriteLine(menu);
			HandleEvent(GetEvent());
		}
		private void HandleEvent(IEvent ev)
		{
			eventHandler.Handle(ev);
		}
		private IEvent GetEvent()
		{
			IEvent resultEvent = new Event1();
			int userIndex = Convert.ToInt32(Console.ReadLine());
			switch (userIndex)
			{
				case 1:
					resultEvent = new Event1();
					break;
				case 2:
					resultEvent = new Event2();
					break;
				case 3:
					resultEvent = new Event3();
					break;
				case 4:
					resultEvent = new Event4();
					break;
				case 5:
					resultEvent = new Event5();
					break;
				case 6:
					resultEvent = new Event6();
					break;
				case 7:
					resultEvent = new Event7();
					break;
				case 8:
					resultEvent = new Event8();
					break;
				case 9:
					resultEvent = new Event9();
					break;
				case 10:
					resultEvent = new Event10();
					break;
				default:
					Console.WriteLine(menu);
					break;
			}
			Console.WriteLine("Generated event: {0}", resultEvent.EventType);
			return resultEvent;
		}

		private BaseHandler eventHandler;
		public string menu = "\nЧто сделать?\n" +
					  "1 - сложение\n" +
					  "2 - декремент 1\n" +
					  "3 - умножение на 2 (2)\n" +
					  "4 - детерминант 1\n" +
					  "5 - инверсия 2\n" +
					  "6 - транспонирование 1\n" +
					  "7 - gethashcode 2\n" +
					  "8 - equals\n" +
					  "9 - след 1\n" +
					  "10 - диагональный вид 2\n" +
					  "Другая клавиша для выхода\n";
	}
}