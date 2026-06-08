using Board;
using Board.Pieces;


namespace ChessEngine
{
    public class Program
    {
        // main entry point. Prompts the user, chooses sides, and starts a game
        static void Main(string[] args)
        {

            var board = new BoardGen();

            Console.WriteLine("Press n to start a game, or Esc to exit.");
            ConsoleKeyInfo keyPress = Console.ReadKey();
            Console.WriteLine();

            switch (keyPress.Key)
            {
                case ConsoleKey.Escape:

                    Environment.Exit(0);
                    break;

                case ConsoleKey.N:

                    Console.WriteLine("Which side do you want to play as? (w or b)");
                    keyPress = Console.ReadKey();
                    Console.WriteLine();

                    while (true)
                    {
                        switch (keyPress.Key)
                        {
                            case ConsoleKey.W:
                                StartGame(board, "White");
                                return;

                            case ConsoleKey.B:
                                StartGame(board, "Black");
                                return;

                            default:
                                Console.WriteLine("Invalid input, please try again...");
                                keyPress = Console.ReadKey();
                                Console.WriteLine();
                                continue; // loop back for retry
                        }
                    }

                default:
                    break;
            }


        }

        private static void StartGame(BoardGen board, string colour)
        {
            // set up the initial board position, print the board, and begin the game loop
            GeneratePieces(board, true);
            PrintBoard(board, colour);
            var game = new Game(board, colour);
        }

        // render the board from the perspective of the player (Dependent on colour)
        private static void PrintBoard(BoardGen board, string colour)
        {
            int size = board.Size;

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine();

            //needs refactoring
            if (colour == "White")
            {
                for (int x = size + 1; x >= 2; x--)
                {
                    Console.ResetColor();
                    Console.Write($"{(x - 2) + 1} "); //rank labels

                    for (int y = 1; y <= size; y++)
                    {
                        PrintSquare(board, x, y);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("  a b c d e f g h"); // file labels
            }

            else if (colour == "Black")
            {
                for (int x = 2; x <= size + 1; x++)
                {
                    Console.ResetColor();
                    Console.Write($"{(x - 2) + 1} "); //rank labels

                    for (int y = size; y >= 1; y--)
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

        // draw a single square on the console, including the board color and piece symbol (If there is one)
        private static void PrintSquare(BoardGen board, int x, int y)
        {
            bool isLightSquare = (x + y) % 2 == 0;

            Console.BackgroundColor = isLightSquare ? ConsoleColor.Gray : ConsoleColor.Green; // makes the pieces easier to see
            Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{board.GeneratedBoard[x, y].Piece?.Unicode ?? ' '} ");
            Console.ResetColor();
        }

        // populate the board with a standard chess starting position
        private static void GeneratePieces(BoardGen board, bool standard)
        {
            GenerateBackRank(board, 2, "WHITE");
            GenerateBackRank(board, 9, "BLACK");
            GeneratePawns(board);

        }

        // place a back rank on the specified board rank using the standard piece order
        private static void GenerateBackRank(BoardGen board, int rank, string colour)
        {
            var pieces = new Piece[]
            {
                new Rook(colour),
                new Knight(colour),
                new Bishop(colour),
                new Queen(colour),
                new King(colour),
                new Bishop(colour),
                new Knight(colour),
                new Rook(colour)
            };

            for (int file = 1; file <= pieces.Length; file++)
            {
                board.GeneratedBoard[rank, file].Piece = pieces[file - 1];
            }
        }

        // place pawns on the default second rank for each side
        private static void GeneratePawns(BoardGen board)
        {
            for (int y = 1; y < board.Size + 1; y++)
            {
                board.GeneratedBoard[3, y].Piece = new Pawn("WHITE");
                board.GeneratedBoard[8, y].Piece = new Pawn("BLACK");
            }
        }
    }
}
