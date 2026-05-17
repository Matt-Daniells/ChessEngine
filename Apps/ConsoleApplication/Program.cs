using Board;
using Board.Pieces;


namespace ChessEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var board = new BoardGen();

            Console.WriteLine("Press n to start a game, or Esc to exit.");
            ConsoleKeyInfo KeyPress = Console.ReadKey();
            Console.WriteLine();

            switch (KeyPress.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

                case ConsoleKey.N:
                    Console.WriteLine("Which side do you want to play as? (w or b)");
                    string? input = Console.ReadLine();

                    if (input == "w" || input == "b")
                    {
                        GeneratePieces(board, true);
                        PrintBoard(board, input);
                        var game = new Game(board, input);
                    }

                    else
                    {
                        // Doesn't loop, needs fixing
                        Console.WriteLine("Incorrect input. Exiting...");
                    }
                    
                    break;

                default:
                    break;
            }


        }

        private static void PrintBoard(BoardGen board, string Colour)
        {
            int size = board.Size;
            string colour = Colour;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();

            if (colour == "w")
            {
                for (int x=size+1; x >= 2; x--)
                {
                    Console.ResetColor();
                    Console.Write($"{(x-2) + 1} "); //rank labels
                    
                    for (int y=1; y <= size; y++)
                    {
                        PrintSquare(board, x, y);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  a b c d e f g h"); // file labels
            }

            else if (colour == "b")
            {
                for (int x=2; x <= size+1; x++)
                {
                    Console.ResetColor();
                    Console.Write($"{(x-2) + 1} "); //rank labels
                    
                    for (int y=size; y >= 1; y--)
                    {
                        PrintSquare(board, x, y);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  h g f e d c b a"); // file labels
            }

            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.WriteLine();
        }

        private static void PrintSquare(BoardGen board, int x, int y)
        {
            bool isLightSquare = (x + y) % 2 == 0;

            Console.BackgroundColor = isLightSquare ? ConsoleColor.Gray : ConsoleColor.Green; // makes the pieces easier to see
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{board.generated_board[x,y].Piece?.Unicode ?? ' '} ");
            Console.ResetColor();
        }

        private static void GeneratePieces(BoardGen board, bool standard)
        {
            int size = board.Size;
            
            // Standard piece layout
            if (standard)
            {
                // White Pieces
                board.generated_board[2, 1].Piece = new Rook("WHITE");
                board.generated_board[2, 2].Piece = new Knight("WHITE");
                board.generated_board[2, 3].Piece = new Bishop("WHITE");
                board.generated_board[2, 4].Piece = new Queen("WHITE");
                board.generated_board[2, 5].Piece = new King("WHITE");
                board.generated_board[2, 6].Piece = new Bishop("WHITE");
                board.generated_board[2, 7].Piece = new Knight("WHITE");
                board.generated_board[2, 8].Piece = new Rook("WHITE");
                
                // White pawns
                for (int y = 1; y < size+1; y++)
                {
                    board.generated_board[3, y].Piece = new Pawn("WHITE");
                }
                
                // Black pawns
                for (int y = 1; y < size+1; y++)
                {
                    board.generated_board[8, y].Piece = new Pawn("BLACK");
                }
                
                // Black pieces
                board.generated_board[9, 1].Piece = new Rook("BLACK");
                board.generated_board[9, 2].Piece = new Knight("BLACK");
                board.generated_board[9, 3].Piece = new Bishop("BLACK");
                board.generated_board[9, 4].Piece = new Queen("BLACK");
                board.generated_board[9, 5].Piece = new King("BLACK");
                board.generated_board[9, 6].Piece = new Bishop("BLACK");
                board.generated_board[9, 7].Piece = new Knight("BLACK");
                board.generated_board[9, 8].Piece = new Rook("BLACK");
            }
        }
    }
}