using System;

namespace MatrixCalculator
{
    public class NonInversibleMatrixException : System.Exception
    {
        public NonInversibleMatrixException() : base()
        {
        }
        public NonInversibleMatrixException(string message) : base(message)
        {
        }
        public NonInversibleMatrixException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}