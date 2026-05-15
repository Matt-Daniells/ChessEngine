using System.ComponentModel;
using Board;
using Board.Pieces;


namespace ChessEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            var board = new BoardGen();
            GeneratePieces(board, true);
            PrintBoard(board);

        }

        private static void PrintBoard(BoardGen board)
        {
            int size = board.Size;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();

            for (int x=7; x >= 0; x--)
            {
                Console.ResetColor();
                Console.Write($"{x + 1} ");

                for (int y=0; y < size; y++)
                {
                    bool isLightSquare = (x + y) % 2 == 0;

                    Console.BackgroundColor = isLightSquare
                        ? ConsoleColor.Gray
                        : ConsoleColor.Green;

                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"{board.generated_board[x,y].Piece?.Unicode ?? ' '} ");
                    Console.ResetColor();
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
        }

        private static void GeneratePieces(BoardGen board, bool standard)
        {
            int size = board.Size;
            
            // Standard piece layout
            if (standard)
            {
                // White Pieces
                board.generated_board[0, 0].Piece = new Rook("WHITE");
                board.generated_board[0, 1].Piece = new Knight("WHITE");
                board.generated_board[0, 2].Piece = new Bishop("WHITE");
                board.generated_board[0, 3].Piece = new Queen("WHITE");
                board.generated_board[0, 4].Piece = new King("WHITE");
                board.generated_board[0, 5].Piece = new Bishop("WHITE");
                board.generated_board[0, 6].Piece = new Knight("WHITE");
                board.generated_board[0, 7].Piece = new Rook("WHITE");
                
                // White pawns
                for (int y = 0; y < size; y++)
                {
                    board.generated_board[1, y].Piece = new Pawn("WHITE");
                }
                
                // Black pawns
                for (int y = 0; y < size; y++)
                {
                    board.generated_board[6, y].Piece = new Pawn("BLACK");
                }
                
                // Black pieces
                board.generated_board[7, 0].Piece = new Rook("BLACK");
                board.generated_board[7, 1].Piece = new Knight("BLACK");
                board.generated_board[7, 2].Piece = new Bishop("BLACK");
                board.generated_board[7, 3].Piece = new Queen("BLACK");
                board.generated_board[7, 4].Piece = new King("BLACK");
                board.generated_board[7, 5].Piece = new Bishop("BLACK");
                board.generated_board[7, 6].Piece = new Knight("BLACK");
                board.generated_board[7, 7].Piece = new Rook("BLACK");
            }
        }
    }
}