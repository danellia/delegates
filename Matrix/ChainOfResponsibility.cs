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
                Console.WriteLine("umm");
            }
            else
            {
                Console.WriteLine("Sending event to next Handler...");
                if (Next != null)
                    Next.Handle(ev);
                else
                    Console.WriteLine("Unknown event. Can't handle.");

            }
        }

        public void SetNextHandler(BaseHandler newHandler)
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
            Console.WriteLine((HandlerStart.firstMatrix + HandlerStart.secondMatrix).ToString());
        }
    }
    class Handler2 : BaseHandler
    {
        public Handler2()
        {
            PrivateEvent = new Event2();
            Console.WriteLine((--HandlerStart.firstMatrix).ToString());
            Next = new Handler3();
        }
    }
    class Handler3 : BaseHandler
    {
        public Handler3()
        {
            PrivateEvent = new Event3();
            Console.WriteLine((2 * HandlerStart.secondMatrix).ToString());
            Next = new Handler4();
        }
    }
    class Handler4 : BaseHandler
    {
        public Handler4()
        {
            PrivateEvent = new Event4();
            Console.WriteLine(SquareMatrix.Determinant(HandlerStart.firstMatrix));
            Next = new Handler5();
        }
    }
    class Handler5 : BaseHandler
    {
        public Handler5()
        {
            PrivateEvent = new Event5();
            SquareMatrix inversedFirst = SquareMatrix.Inverse(HandlerStart.secondMatrix);
            Console.WriteLine(inversedFirst.ToString());
            Next = new Handler6();
        }
    }
    public class Handler6 : BaseHandler
    {
        public Handler6()
        {
            PrivateEvent = new Event6();
            SquareMatrix transposedSecond = HandlerStart.firstMatrix.Transpose();
            Console.WriteLine(transposedSecond.ToString());
            Next = new Handler7();
        }
    }
    class Handler7 : BaseHandler
    {
        public Handler7()
        {
            PrivateEvent = new Event7();
            Console.WriteLine(HandlerStart.secondMatrix.GetHashCode());
            Next = new Handler8();
        }
    }
    class Handler8 : BaseHandler
    {
        public Handler8()
        {
            PrivateEvent = new Event3();
            Console.WriteLine(HandlerStart.firstMatrix.Equals(HandlerStart.secondMatrix));
            Next = new Handler9();
        }
    }
    class Handler9 : BaseHandler
    {
        public Handler9()
        {
            PrivateEvent = new Event4();
            Console.WriteLine(HandlerStart.firstMatrix.Trace().ToString());
            Next = new Handler10();
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
            Console.WriteLine(diagonal(HandlerStart.secondMatrix).ToString());
            Next = null;
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

            Console.WriteLine("Matrix 1: " + firstMatrix.ToString());
            Console.WriteLine("Matrix 2: " + secondMatrix.ToString());

            Next = null;
        }
    }
}

