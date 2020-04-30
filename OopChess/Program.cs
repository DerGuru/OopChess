using System;

namespace OopChess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard();
            board.InitializeBoard();
            board.Play();
        }
    }
}
