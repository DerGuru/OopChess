using OopChess.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopChess
{
    public class ChessBoard
    {
        public List<Figure> Figures { get; set; } = new List<Figure>();

        public void InitializeBoard()
        {
            // Fill board
            Figures = new List<Figure>()
            {
                new Rook(this, new Location{X = XLocation.A, Y = YLocation._1 }, Color.White),
                new Rook(this, new Location{X = XLocation.H, Y = YLocation._1 }, Color.White),
                new Rook(this, new Location{X = XLocation.A, Y = YLocation._8 }, Color.Black),
                new Rook(this, new Location{X = XLocation.H, Y = YLocation._8 }, Color.Black),
                new Knight(this, new Location{X = XLocation.B, Y = YLocation._1}, Color.White),
                new Knight(this, new Location{X = XLocation.G, Y = YLocation._1}, Color.White),
                new Knight(this, new Location{X = XLocation.B, Y = YLocation._8}, Color.Black),
                new Knight(this, new Location{X = XLocation.G, Y = YLocation._8}, Color.Black),
                new Bishop(this, new Location{X = XLocation.C, Y = YLocation._1}, Color.White),
                new Bishop(this, new Location{X = XLocation.F, Y = YLocation._1}, Color.White),
                new Bishop(this, new Location{X = XLocation.C, Y = YLocation._8}, Color.Black),
                new Bishop(this, new Location{X = XLocation.F, Y = YLocation._8}, Color.Black),
                new Queen(this, new Location{X = XLocation.D, Y = YLocation._1}, Color.White),
                new Queen(this, new Location{X = XLocation.D, Y = YLocation._8}, Color.Black),
                new King(this, new Location{X = XLocation.E, Y = YLocation._1}, Color.White),
                new King(this, new Location{X = XLocation.E, Y = YLocation._8}, Color.Black),
            };

            for (var xLoc = XLocation.A; xLoc <= XLocation.H; ++xLoc)
            {
                Figures.Add(new Pawn(this, new Location { X = xLoc, Y = YLocation._2 }, Color.White));
                Figures.Add(new Pawn(this, new Location { X = xLoc, Y = YLocation._7 }, Color.Black));
            }
        }

        internal void BeatFigure(Location location)
        {
            var betFigure = GetFigure(location);
            if (betFigure == null)
                return;
            Figures.Remove(betFigure);
        }

        public bool IsFieldFree(Location location)
        {
            return !Figures.Any(f => f.CurrentLocation.Equals(location));
        }

        public Figure GetFigure(Location location)
        {
            return Figures.FirstOrDefault(f => f.CurrentLocation.Equals(location));
        }

        public void Play()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"       A      B      C      D      E      F      G      H{Environment.NewLine}");
            sb.Append($"    #########################################################{Environment.NewLine}");

            for (var Y = YLocation._1; Y <= YLocation._8; ++Y)
            {
                sb.Append($"    #      #      #      #      #      #      #      #      #{Environment.NewLine}    #");

                for (var X = XLocation.A; X <= XLocation.H ; ++X )
                {
                    var loc = new Location { X = X, Y = Y };
                    sb.Append($"  {GetFigure(loc)?.ToString() ?? "  "}  #");
                }
                sb.Append($"{Environment.NewLine}    #      #      #      #      #      #      #      #      #{Environment.NewLine}");
                sb.Append($"    #########################################################{Environment.NewLine}");
            }
            /*
            StringBuilder sb = new StringBuilder();
            sb.Append($"       A      B      C      D      E      F      G      H{Environment.NewLine}");
            sb.Append($"    #########################################################{Environment.NewLine}");

            for (Location loc = new Location() { X = XLocation.A, Y = YLocation._1 }; !(loc.X == XLocation.A && loc.Y == YLocation._8 + 1); loc.X++)
            {
                if (loc.X == XLocation.A)
                    sb.Append($"    #      #      #      #      #      #      #      #      #{Environment.NewLine}    #");

                sb.Append($"  {GetFigure(loc)?.ToString() ?? "  "}  #");

                if (loc.X == XLocation.H)
                {
                    sb.Append($"{Environment.NewLine}    #      #      #      #      #      #      #      #      #{Environment.NewLine}");
                    sb.Append($"    #########################################################{Environment.NewLine}");
                    loc.Y++;
                    loc.X = XLocation.A -1;
                }
            }
            */

            /*
            for (int x = 0; x < 64; x++)
            {
                
               
                
                    << " " << x + 1 << "  #  " << chessMap[x][0] << "  #  " << chessMap[x][1] << "  #  " << chessMap[x][2] << "  #  " << chessMap[x][3] << "  #  " << chessMap[x][4] << "  #  " << chessMap[x][5] << "  #  " << chessMap[x][6] << "  #  " << chessMap[x][7] << "  # " << " " << x + 1 << '\n'
                    << "    #      #      #      #      #      #      #      #      #" << '\n'
                     if (x % 8 == 0)
                {
                    << "    ######################################################### " << '\n';
                }
                    
            }
            std::cout << "       H      G      F      E      D      C      B      A " << '\n';
            */
            return sb.ToString();
        }
    }
}
