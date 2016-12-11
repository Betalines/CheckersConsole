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
        public Piece SelectPiece()
        { throw new NotImplementedException();
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
        { throw new NotImplementedException();
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
