using OopChess.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess.Figures
{
    public class Pawn : Figure
    {
        public Pawn(ChessBoard chessBoard, Location location, Color color) : base(chessBoard, location, color)
        {
        }

        public override string DisplayName => "B";

        public override void Move(Location toLocation)
        {


            if (((CurrentLocation.Y == YLocation._2) && CurrentLocation.X == toLocation.X && toLocation.Y - CurrentLocation.Y == 2 && chessBoard.GetFigure(new Location {X= CurrentLocation.X,Y = CurrentLocation.Y+1}) == null  && chessBoard.GetFigure(new Location { X = CurrentLocation.X, Y = CurrentLocation.Y + 2 })==null)
            || ((CurrentLocation.Y == YLocation._7) && CurrentLocation.X == toLocation.X && toLocation.Y - CurrentLocation.Y == -2 && chessBoard.GetFigure(new Location { X = CurrentLocation.X, Y = CurrentLocation.Y - 1 }) == null && chessBoard.GetFigure(new Location { X = CurrentLocation.X, Y = CurrentLocation.Y - 2 }) == null))
            {
                chessBoard.BeatFigure(toLocation);
                CurrentLocation = toLocation;
            }
            else if (( CurrentLocation.X == toLocation.X && toLocation.Y - CurrentLocation.Y == 1 && chessBoard.GetFigure(toLocation) == null )
            || ( CurrentLocation.X == toLocation.X && toLocation.Y - CurrentLocation.Y == -1 && chessBoard.GetFigure(toLocation) == null ))
            {
                chessBoard.BeatFigure(toLocation);
                CurrentLocation = toLocation;
            }
            else if (Math.Abs(toLocation.Y - CurrentLocation.Y) == 1 && Math.Abs(toLocation.X - CurrentLocation.X)==1 && chessBoard.GetFigure(toLocation).color != color)// Null???//
            {
                chessBoard.BeatFigure(toLocation);
                CurrentLocation = toLocation;
            }
            else
            {
                throw new MoveNotPossibleException();
            }


        }
    }
}
