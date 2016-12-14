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
            // jeden z graczy nie ma pionkow
            if (player1.numberOfPieces == 0 || player2.numberOfPieces == 0)
                return true;
            // gracz nie ma ruchu

            return false;
        }

        private void AnnounceWinning()
        {
            Console.WriteLine("!!! GAME OVER !!!");

        }
    }

    class Program
    {
        public static void Main()
        {
            // mozna sobie cos posprawdzac
            Console.WriteLine("Checkers");
            int[,] array = { {1, 0, 1, 0, 1, 0, 1, 0},
                             {0, 1, 0, 1, 0, 1, 0, 1},
                             {1, 0, 1, 0, 1, 0, 1, 0},
                             {0, 0, 0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 2, 0, 0, 0, 0},
                             {2, 0, 2, 0, 1, 0, 2, 0},
                             {0, 2, 0, 2, 0, 2, 0, 2},
                             {2, 0, 2, 0, 2, 0, 2, 0},
                                };
            var myBoard = new CheckerBoard(array);
            var myPlayer = new Player(Color.BLACK, null);
            if (myBoard[2, 2] == null)
                Console.WriteLine("NULL REFERENCE");
            else Console.WriteLine("IsCorrectPiece: " + myPlayer.IsCorrectPiece(myBoard[2, 2]));
            myBoard.DrawBoard(myPlayer);
            Console.WriteLine("CanAttack: " + myBoard[4, 2].CanAttack(myBoard));

            var BetaBoard = new CheckerBoard();
            BetaBoard.DrawBoard(myPlayer);
            Console.ReadKey();

        }
    }
}