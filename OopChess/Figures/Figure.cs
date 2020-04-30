using System;
using System.Collections.Generic;
using System.Text;

namespace OopChess.Figures
{
    public abstract class Figure : Object
    {
        protected readonly ChessBoard chessBoard;

        public readonly Color color;

        public abstract string DisplayName { get;}

        public Location CurrentLocation { get; protected set; }

        public abstract void Move(Location toLocation);

        public override string ToString() { return (color  == Color.Black ? 'S' : 'W') + DisplayName; }

        public Figure (ChessBoard chessBoard, Location location, Color color)
        {
            this.chessBoard = chessBoard;
            this.CurrentLocation = location;
            this.color = color;
        }
    }
}
