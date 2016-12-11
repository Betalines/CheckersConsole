using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class Player
    {
        protected Color color;
        protected List<Piece> pieces;

        public Player(Color c, List<Piece> _pieces)
        {
            color = c;
            pieces = _pieces;
        }
        public Piece SelectPiece(CheckerBoard board)
        {
            while(true)
            {
                Console.WriteLine("Write the x coordinate");
                string x = Console.ReadLine();
                Console.WriteLine("Write the y coordinate");
                string y = Console.ReadLine();
                int coordX = int.Parse(x);
                int coordY = int.Parse(y);
                if (coordX >= 0 && coordX < Config.Cfg.board_size && coordY >= 0 && coordY < Config.Cfg.board_size)
                {
                    if (board[coordX, coordY] == null)
                    {
                        Console.WriteLine("No piece on this position !!!");
                        continue;
                    }
                    if (!IsCorrectPiece(board[coordX, coordY]))
                    {
                        Console.WriteLine("Not your piece !!!");
                        continue;
                    }
                    return board[coordX, coordY];
                }
                Console.WriteLine("Bad coordinates");
            }
            //wprowadzenie pozycje pionkow
        }
        public Position SelectDestination(CheckerBoard board)
        {
            while (true)
            {
                Console.WriteLine("Write the x coordinate");
                string x = Console.ReadLine();
                Console.WriteLine("Write the y coordinate");
                string y = Console.ReadLine();
                int coordX = int.Parse(x);
                int coordY = int.Parse(y);
                if (coordX >= 0 && coordX < Config.Cfg.board_size && coordY >= 0 && coordY < Config.Cfg.board_size)
                {
                    return new Position(coordX, coordY);
                }
                Console.WriteLine("Bad coordinates");
            }
            //wprowadzenie pozycje pionkow
        }

        public bool IsCorrectPiece(Piece piece)
        {
            return piece.pieceColor == color;
        }

        public bool IsPossibleAttack(CheckerBoard board)
        {
            //przechodzi po liscie pionkow i jesli jest mozliwe bicie dla ktoregos pionka
            //zwraca true
            foreach (Piece x in pieces)
                if (x.CanAttack(board))
                    return true;
            return false;
        }

        public void Input(out Piece piece, out Position destination, CheckerBoard board)
        {
            piece = null;
            destination = new Position(-1,-1);
            bool attackPossible = IsPossibleAttack(board);
            if (pieces.Count == 0)
                return;
            while (true)
            {
                Console.WriteLine("Select piece !!!");
                piece = SelectPiece(board);
                Console.WriteLine("Select destination !!!");
                destination = SelectDestination(board);

                if (attackPossible)
                {
                    if (piece.IsCorrectDestination(true, destination, board))
                    {
                        break;
                    }
                    Console.WriteLine("You have to atack !!!");
                }
                else
                {
                    if (piece.IsCorrectDestination(false, destination, board))
                    {
                        break;
                    }
                    Console.WriteLine("Can't move your piece to this position !!!");
                }
            }
            //zwraca pionek
            //i poprawny cel w sensie ze jest puste pole
        }

        public void Turn(CheckerBoard board)
        {

            bool attackFlag = IsPossibleAttack(board);
            Piece piece;
            Position destination;

            while (true)
            {
                Input(out piece, out destination, board);
                if (piece.IsCorrectDestination(attackFlag, destination, board))
                    break;
            }

            if(attackFlag)
            {
                Piece deletePiece = piece.FunkcjaCudzika(destination);
                deletePiece.RemovePiece(board, pieces);
            }
            piece.Move(board, destination);

            while(piece.CanAttack(board))
            {
                Piece pp;

                while (true)
                {
                    Input(out pp, out destination, board);
                    if(pp.Equals(piece))
                        if (piece.IsCorrectDestination(attackFlag, destination, board))
                            break;
                }
                
                  Piece deletePiece = piece.FunkcjaCudzika(destination);
                  deletePiece.RemovePiece(board, this.pieces);
                  piece.Move(board, destination);
            }
            if (piece.IsBecomeQueen())
                piece.ChangePieceToQueen(board, this.pieces);
        }


    }
}
