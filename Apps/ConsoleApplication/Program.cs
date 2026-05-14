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
            GeneratePieces(board, true);
            PrintBoard(board);

        }

        private static void PrintBoard(BoardGen board)
        {
            int size = board.Size;
            
            for (int x=0; x < size; x++)
            {
                for (int y=0; y < size; y++)
                {
                    Console.Write(board.generated_board[x,y].Piece?.Unicode ?? ' ');
                Console.WriteLine(Environment.NewLine);
                }
            }
        }

        private static void GeneratePieces(BoardGen board, bool standard)
        {
            int size = board.Size;
            if (standard)
            {
                // Need to implement
                for (int x=0; x < size; x++)
                {
                    for (int y=0; y < size; y++)
                    {
                        if (x==1) {board.generated_board[x,y].Piece = new Pawn("WHITE");}
                    }
                }
            }
        }
    }
}