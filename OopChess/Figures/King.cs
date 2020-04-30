using OopChess.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess.Figures
{
    public class King : Figure
    {
        public King(ChessBoard chessBoard, Location location, Color color) : base(chessBoard, location, color)
        {
        }

        public override string DisplayName => "K";

        public override void Move(Location toLocation)
        {
            if (!(Math.Abs(toLocation.X - CurrentLocation.X) <= 1 && Math.Abs(toLocation.Y - CurrentLocation.Y) <= 1))
            {
                throw new MoveNotPossibleException();
            }

            var betFigure = chessBoard.GetFigure(toLocation);
            if (betFigure != null && betFigure.color == color)
            {
                throw new MoveNotPossibleException();
            }
            chessBoard.BeatFigure(toLocation);
            CurrentLocation = toLocation;
        }
    }
}
