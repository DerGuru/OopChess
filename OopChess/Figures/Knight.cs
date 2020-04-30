using System;
using System.Collections.Generic;
using System.Text;
using OopChess.Exceptions;
using OopChess;

namespace OopChess.Figures
{
    public class Knight : Figure
    {
        public Knight(ChessBoard chessBoard, Location location, Color color) : base(chessBoard, location, color)
        {
        }

        public override string DisplayName =>  "S";

        public override void Move(Location toLocation)
        {
            if (!((Math.Abs(toLocation.X - CurrentLocation.X) <= 2 && Math.Abs(toLocation.Y - CurrentLocation.Y) <= 1) 
                && (Math.Abs(toLocation.X - CurrentLocation.X) <= 1 && Math.Abs(toLocation.Y - CurrentLocation.Y) <= 2)))
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
