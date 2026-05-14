using Board;
using Board.Pieces;


namespace ChessEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            var board = new BoardGen();
            PrintBoard(board);
            Console.WriteLine(Queen.Unicode);
        }

        private static void PrintBoard(BoardGen board)
        {
            int size = board.Size;
            // Needs work to accurately map and print a chess board
            for (int x=0; x < size; x++)
            {
                for (int y=0; y < size; y++)
                {
                    Console.Write(board.generated_board[x,y].DisplayValue());
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}