using System;

namespace MatrixCalculator
{
    public abstract class IEvent
    {
        public string EventType { get; set; }
    }

    class Event1 : IEvent
    {
        public Event1() { EventType = "1"; }
    }

    class Event2 : IEvent
    {
        public Event2() { EventType = "2"; }
    }

    class Event3 : IEvent
    {
        public Event3() { EventType = "3"; }
    }

    class Event4 : IEvent
    {
        public Event4() { EventType = "4"; }
    }

    class Event5 : IEvent
    {
        public Event5() { EventType = "5"; }
    }

    class Event6 : IEvent
    {
        public Event6() { EventType = "6"; }
    }

    class Event7 : IEvent
    {
        public Event7() { EventType = "7"; }
    }

    class Event8 : IEvent
    {
        public Event8() { EventType = "8"; }
    }

    class Event9 : IEvent
    {
        public Event9() { EventType = "9"; }
    }

    class Event10 : IEvent
    {
        public Event10() { EventType = "10"; }
    }
    class EventStart : IEvent
    {
        public EventStart() { EventType = "EventStart"; }
    }

    public abstract class BaseHandler
    {
        protected BaseHandler Next { get; set; }
        protected IEvent PrivateEvent { get; set; }
        public BaseHandler() { Next = null; }

        public virtual void Handle(IEvent ev)
        {
            if (PrivateEvent.EventType == ev.EventType)
            {
                Console.WriteLine("success!");
            }
            else
            {
                Console.WriteLine("sending to next handler");
                if (Next != null)
                    Next.Handle(ev);
                else
                    Console.WriteLine("can't handle this one");

            }
        }

        private void SetNextHandler(BaseHandler newHandler)
        {
            Next = newHandler;
        }
    }
    			  
    class Handler1 : BaseHandler
    {
        public Handler1()
        {
            PrivateEvent = new Event1();
            Next = new Handler2();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 1: " + HandlerStart.firstMatrix.ToString());
            Console.Write("Matrix 2: " + HandlerStart.secondMatrix.ToString());
            Console.Write("1 - сложение\n" + (HandlerStart.firstMatrix + HandlerStart.secondMatrix).ToString());
        }
    }
    class Handler2 : BaseHandler
    {
        public Handler2()
        {
            PrivateEvent = new Event2();
            Next = new Handler3();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 1: " + HandlerStart.firstMatrix.ToString());
            Console.Write("2 - декремент 1\n" + (--HandlerStart.firstMatrix).ToString());
        }
    }
    class Handler3 : BaseHandler
    {
        public Handler3()
        {
            PrivateEvent = new Event3();
            Next = new Handler4();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 2: " + HandlerStart.secondMatrix.ToString());
            Console.Write("3 - умножение на 2 (2)\n" + (2 * HandlerStart.secondMatrix).ToString());
        }
    }
    class Handler4 : BaseHandler
    {
        public Handler4()
        {
            PrivateEvent = new Event4();
            Next = new Handler5();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 1: " + HandlerStart.firstMatrix.ToString());
            Console.Write("4 - детерминант 1\n" + SquareMatrix.Determinant(HandlerStart.firstMatrix) + "\n");
        }
    }
    class Handler5 : BaseHandler
    {
        public Handler5()
        {
            PrivateEvent = new Event5();
            Next = new Handler6();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 2: " + HandlerStart.secondMatrix.ToString());
            SquareMatrix inversedFirst = SquareMatrix.Inverse(HandlerStart.secondMatrix);
            Console.Write("5 - инверсия 2\n" + inversedFirst.ToString());
        }
    }
    public class Handler6 : BaseHandler
    {
        public Handler6()
        {
            PrivateEvent = new Event6();
            Next = new Handler7();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 1: " + HandlerStart.firstMatrix.ToString());
            SquareMatrix transposedSecond = HandlerStart.firstMatrix.Transpose();
            Console.Write("6 - транспонирование 1\n" + transposedSecond.ToString());
        }
    }
    class Handler7 : BaseHandler
    {
        public Handler7()
        {
            PrivateEvent = new Event7();
            Next = new Handler8();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 2: " + HandlerStart.secondMatrix.ToString());
            Console.Write("7 - gethashcode 2\n" + HandlerStart.secondMatrix.GetHashCode() + "\n");
        }
    }
    class Handler8 : BaseHandler
    {
        public Handler8()
        {
            PrivateEvent = new Event3();
            Next = new Handler9();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 1: " + HandlerStart.firstMatrix.ToString());
            Console.Write("Matrix 2: " + HandlerStart.secondMatrix.ToString());
            Console.Write("8 - equals\n" + HandlerStart.firstMatrix.Equals(HandlerStart.secondMatrix) + "\n");
        }
    }
    class Handler9 : BaseHandler
    {
        public Handler9()
        {
            PrivateEvent = new Event4();
            Next = new Handler10();
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 1: " + HandlerStart.firstMatrix.ToString());
            Console.Write("9 - след 1\n" + HandlerStart.firstMatrix.Trace().ToString() + "\n");
        }
    }
    class Handler10 : BaseHandler
    {
        DiagonalMatrix diagonal = delegate (SquareMatrix mt)
        {
            SquareMatrix result = new SquareMatrix();
            for (int rowIndex = 0; rowIndex < SquareMatrix.size; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < SquareMatrix.size; ++colIndex)
                {
                    if (rowIndex != colIndex)
                    {
                        result[rowIndex, colIndex] = 0;
                    }
                    else
                    {
                        result[rowIndex, colIndex] = mt[rowIndex, colIndex];
                    }
                }
            }
            return result;
        };

        public Handler10()
        {
            PrivateEvent = new Event10();
            Next = null;
        }
        public override void Handle(IEvent ev)
        {
            Console.Write("Matrix 2: " + HandlerStart.secondMatrix.ToString());
            Console.Write("10 - диагональный вид 2\n" + diagonal(HandlerStart.secondMatrix).ToString());
        }
    }

    class HandlerStart : BaseHandler
    {
        public static SquareMatrix firstMatrix;
        public static SquareMatrix secondMatrix;

        public HandlerStart()
        {
            PrivateEvent = new EventStart();

            firstMatrix = new SquareMatrix();
            secondMatrix = new SquareMatrix();

            Console.Write("Matrix 1: " + firstMatrix.ToString());
            Console.Write("Matrix 2: " + secondMatrix.ToString());

            Next = new Handler1();
        }
    }

    public class Chain
    {
        BaseHandler handlerStart;
        BaseHandler h1;
        BaseHandler h2;
        BaseHandler h3;
        BaseHandler h4;
        BaseHandler h5;
        BaseHandler h6;
        BaseHandler h7;
        BaseHandler h8;
        BaseHandler h9;
        BaseHandler h10;

        public Chain()
        {
            handlerStart = new HandlerStart();
            h1 = new Handler1();
            h2 = new Handler2();
            h3 = new Handler3();
            h4 = new Handler4();
            h5 = new Handler5();
            h6 = new Handler6();
            h7 = new Handler7();
            h8 = new Handler8();
            h9 = new Handler9();
            h10 = new Handler10();
        }

        public void Run(int operation)
        {
            switch (operation)
            {
                case 1:
                    h1.Handle(new Event1());
                    break;
                case 2:
                    h2.Handle(new Event2());
                    break;
                case 3:
                    h3.Handle(new Event3());
                    break;
                case 4:
                    h4.Handle(new Event4());
                    break;
                case 5:
                    h5.Handle(new Event5());
                    break;
                case 6:
                    h6.Handle(new Event6());
                    break;
                case 7:
                    h7.Handle(new Event7());
                    break;
                case 8:
                    h8.Handle(new Event8());
                    break;
                case 9:
                    h9.Handle(new Event9());
                    break;
                case 10:
                    h10.Handle(new Event10());
                    break;
                default:
                    Console.WriteLine(menu);
                    break;
            }
            Console.WriteLine(menu);
        }

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