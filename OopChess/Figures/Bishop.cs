using OopChess.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess.Figures
{
    public class Bishop : Figure
    {
        public Bishop(ChessBoard chessBoard, Location location, Color color) : base(chessBoard, location, color)
        {
        }

        public override string DisplayName => "L";

        public override void Move(Location toLocation)
        {
           
            if (Math.Abs(CurrentLocation.X - toLocation.X) == Math.Abs(CurrentLocation.Y - toLocation.Y))
            {
                var loc = new Location { X = CurrentLocation.X, Y = CurrentLocation.Y };
                for (int x = 1; x <= Math.Abs(toLocation.Y - CurrentLocation.Y); x++)
                {
                    if(CurrentLocation.X - toLocation.X > 0 && CurrentLocation.Y - toLocation.Y > 0)
                    {
                        loc.X--;
                        loc.Y--;
                    }
                    else if (CurrentLocation.X - toLocation.X < 0 && CurrentLocation.Y - toLocation.Y < 0)
                    {
                        loc.X++;
                        loc.Y++;
                    }
                    else if (CurrentLocation.X - toLocation.X > 0 && CurrentLocation.Y - toLocation.Y < 0)
                    {
                        loc.X--;
                        loc.Y++;
                    }
                    else if (CurrentLocation.X - toLocation.X < 0 && CurrentLocation.Y - toLocation.Y > 0)
                    {
                        loc.X++;
                        loc.Y--;
                    }

                    var betFigure = chessBoard.GetFigure(loc);
                    if (toLocation.Equals(loc))
                    {
                        if (betFigure != null && betFigure.color == color)
                        {
                            throw new MoveNotPossibleException();
                        }

                        chessBoard.BeatFigure(toLocation);
                        CurrentLocation = toLocation;
                    }
                    else if (betFigure != null)
                    {
                        throw new MoveNotPossibleException();
                    }
                }

            }
            else
            {
                throw new MoveNotPossibleException();

            }
        }
    }
}
