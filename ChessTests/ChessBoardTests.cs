using NUnit.Framework;
using OopChess;
using OopChess.Exceptions;
using OopChess.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessTests
{
    class ChessBoardTests
    {
        private ChessBoard board = new ChessBoard();

        [Test]
        public void GetFigure()
        {
            var figure = board.GetFigure(new Location { X = XLocation.B, Y = YLocation._1 });
            Assert.IsTrue(figure.DisplayName == "S" && figure.color == Color.White, "Not the correct figure");
        }

        [Test]
        public void IsFieldFreeTest()
        {
            board.InitializeBoard();
            Assert.IsFalse(board.IsFieldFree(new Location { X = XLocation.A, Y = YLocation._1 }), "Field is Free");
            Assert.IsTrue(board.IsFieldFree(new Location { X = XLocation.D, Y = YLocation._5 }), "Field is not free");
        }

        [Test]
        public void IncrementLocation()
        {
            var loc = new Location() { X = XLocation.A, Y = YLocation._1 };
            var temp = loc.ToString();
            loc.X++;
            loc.X++;
            temp = loc.ToString();
            loc.Y++;
            temp = loc.ToString();
        }

        [Test]
        public void ExceptionTest()
        {
            try
            {
                var a = 1 + 1;
                ThrowExampleException();
                var AnasWeißNichtWieExceptionsFunktionieren = 5 + 5;
            }
            catch (Exception ex)
            {
                //do something here
            }
        }

        private void ThrowExampleException()
        {
            throw new Exception();
        }

        [Test]
        public void KingTest()
        {
            try
            {
                var board = new ChessBoard();
                var king = new King(board, new Location() { X = XLocation.D, Y = YLocation._4 }, Color.White);
                board.Figures.Add(king);
                var newLoc = new Location() { X = king.CurrentLocation.X + 1, Y = king.CurrentLocation.Y + 1 };
                king.Move(newLoc);
            }
            catch (MoveNotPossibleException)
            {
                Console.WriteLine("Zuge nicht möglich!");
            }

        }
        [Test]
        public void RookTest()
        {
            /////////////


            var loc = new Location() { X = XLocation.B, Y = YLocation._1 };
            if (board.IsFieldFree(loc))
            {
                int x = 1;
            }

            ///////////
            try
            {
                var board = new ChessBoard();
                var Rook = new Rook(board, new Location() { X = XLocation.D, Y = YLocation._4 }, Color.White);
                board.Figures.Add(Rook);
                var newLoc = new Location() { X = Rook.CurrentLocation.X + 2, Y = Rook.CurrentLocation.Y };
                Rook.Move(newLoc);
            }
            catch (MoveNotPossibleException)
            {
                Console.WriteLine("Zuge nicht möglich!");
            }

        }

        [Test]
        public void NullOperandsTest()
        {
            board.InitializeBoard();
            Location loc = new Location() { X = XLocation.C, Y = YLocation._3 };
            Figure figure = board.GetFigure(loc);

            string figurestring = figure?.ToString() ?? "  " ;

            int? x = null;
            int y = x ?? 1;

        }

    }
}
