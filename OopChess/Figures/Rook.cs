using OopChess.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess.Figures
{
    public class Rook : Figure     
    {
        public Rook(ChessBoard chessBoard, Location location, Color color) : base(chessBoard, location, color)
        {

        }

        public override string DisplayName => "T";

        public override void Move(Location toLocation)
        {
            // checks
          
           



            if (CurrentLocation.X == toLocation.X && toLocation.Y != CurrentLocation.Y)
            {
                var loc = new Location { X = toLocation.X, Y = CurrentLocation.Y };
                for (int x = 1; x <= Math.Abs(toLocation.Y - CurrentLocation.Y); x++)
                {

                    if (toLocation.Y < loc.Y)
                    {
                        loc.Y--;
                    }
                    else if (toLocation.Y > loc.Y)
                    {
                        loc.Y++;
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
            else if (CurrentLocation.Y == toLocation.Y && toLocation.X != CurrentLocation.X)
            {
                var loc = new Location { Y = toLocation.Y, X = CurrentLocation.X };
                for (int x = 1, i = Math.Abs(toLocation.X - CurrentLocation.X); x <= i; x++)
                {

                    if (toLocation.X < loc.X)
                    {
                        loc.X--;
                    }
                    else if (toLocation.X > loc.X)
                    {
                        loc.X++;
                    }

                    var betFigure = chessBoard.GetFigure(loc);
                    if (toLocation.X == loc.X && toLocation.Y == loc.Y)
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
