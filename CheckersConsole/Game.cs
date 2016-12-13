using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public enum Color { UNDEFINED, WHITE, BLACK };

    class Game
    {
        protected enum State { GAME, GAMEOVER, NOGAME };

        protected State gameState;
        protected CheckerBoard board;
        protected Player player1,
            player2,
            currentPlayer;

        public Game()
        {
            InitGame();
        }

        public void InitGame()
        {

            throw new NotImplementedException();

            // kolor dla gracza wylosowac
            // ustawic graczy, plansze stworzyc

        }

        public void Run()
        {
            while (gameState == State.GAME)
            {
                if (IsGameOver())
                    gameState = State.GAMEOVER;

                currentPlayer.Turn(board);
                if (currentPlayer == player1)
                    currentPlayer = player2;
                else
                    currentPlayer = player1;
            }
        }

        private bool IsGameOver()
        {
            throw new NotImplementedException();

        }

        private void AnnounceWinning()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        public static void Main()
        {
            // mozna sobie cos posprawdzac
            Console.WriteLine("Checkers");
            int[,] array = { {2, 0, 2, 0, 2, 0, 2, 0},
                             {0, 2, 0, 2, 0, 2, 0, 2},
                             {2, 0, 2, 0, 2, 0, 2, 0},
                             {0, 0, 0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0, 0, 0, 0},
                             {1, 0, 1, 0, 1, 0, 1, 0},
                             {0, 1, 0, 1, 0, 1, 0, 1},
                             {1, 0, 1, 0, 1, 0, 1, 0},
                            
                             
                                };
            var myBoard = new CheckerBoard();
            var myPlayer = new Player(Color.BLACK, myBoard);
            if (myBoard[2, 2] == null)
                Console.WriteLine("NULL REFERENCE");
            else Console.WriteLine("IsCorrectPiece: " + myPlayer.IsCorrectPiece(myBoard[2, 2]));
            myBoard.DrawBoard(myPlayer);

            Console.WriteLine("CanAttack: " + myBoard[4, 2].CanAttack(myBoard));
            Position dest;
            Piece myPiece;
            myPlayer.Input(out myPiece, out dest, myBoard);
            myPiece.Move(myBoard, dest);
            myBoard.DrawBoard(myPlayer);
            Console.ReadKey();

        }
    }
}