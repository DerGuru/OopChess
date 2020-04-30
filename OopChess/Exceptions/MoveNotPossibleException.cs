using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess.Exceptions
{
    public class MoveNotPossibleException : Exception
    {
        public MoveNotPossibleException() : base("Ungültiger Zug") { }
    }
}
