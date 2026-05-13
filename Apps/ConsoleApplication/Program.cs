using Board;


namespace ChessEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            var board = new BoardGen();
            PrintBoard(board);
        }

        private static void PrintBoard(BoardGen board)
        {
            int size = board.Size;
            // Needs work to accurately map and print a chess board
            for (int y=0; y < size; y++)
            {
                for (int x=0; x < size; x++)
                {
                    Console.WriteLine(board.generated_board[x,y].Display_Location());
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}