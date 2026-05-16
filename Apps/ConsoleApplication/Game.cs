using Board;
using Board.Pieces;

namespace ChessEngine
{
    public class Game
    {
        public BoardGen Board { get; }

        public Game(BoardGen board)
        {
            Board = board;
            ConsoleKeyInfo KeyPress = Console.ReadKey();

            while (KeyPress.Key != ConsoleKey.Escape)
            {
                //Logic
                KeyPress = Console.ReadKey();
            }
        }
    }
}