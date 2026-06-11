using Board;
using Board.Pieces;

namespace ChessEngine;

public class Program
{
    internal interface IConsole
    {
        ConsoleKeyInfo ReadKey();
        void WriteLine(string value);
    }

    internal class SystemConsole : IConsole
    {
        public ConsoleKeyInfo ReadKey() => Console.ReadKey();
        public void WriteLine(string value) => Console.WriteLine(value);
    }
    // main entry point. Only calls run() method
    public static void Main() => Run(new SystemConsole());

    internal static int Run(IConsole console)
    {
        var board = new BoardGen();
        console.WriteLine("Press n to start a game, or Esc to exit.");
        var keyPress = console.ReadKey();
        console.WriteLine("\n");

        return keyPress.Key switch
        {
            ConsoleKey.Escape => 0,
            ConsoleKey.N => HandleNewGame(console, board),
            _ => 1
        };
    }

    private static int HandleNewGame(IConsole console, BoardGen board)
    {
        console.WriteLine("Which side do you want to play as? (w or b)");
        var keyPress = console.ReadKey();
        console.WriteLine("\n");

        while (true)
        {
            switch (keyPress.Key)
            {
                case ConsoleKey.W:
                    StartGame(board, "White");
                    return 0;

                case ConsoleKey.B:
                    StartGame(board, "Black");
                    return 0;

                default:
                    Console.WriteLine("Invalid input, please try again...");
                    keyPress = Console.ReadKey();
                    Console.WriteLine();
                    continue; // loop back for retry
            }
        }
    }

    private static void StartGame(BoardGen board, string colour)
    {
        // set up the initial board position, print the board, and begin the game loop
        GeneratePieces(board, true);
        PrintBoard(board, colour);
        _ = new Game(board, colour);
    }

    private static (IEnumerable<int> rankRange, IEnumerable<int> fileRange, string fileLabels) GetBoardOrientation(string colour) =>
        colour == "White"
        ? (Enumerable.Range(2, 8).Reverse(), Enumerable.Range(1, 8), "a b c d e f g h")
        : (Enumerable.Range(2, 8), Enumerable.Range(1, 8).Reverse(), "h g f e d c b a");

    private static string GetRankLabel(int rowIndex, string colour, BoardGen board)
    {
        int rank = rowIndex - 1;

        return colour == "White"
            ? rank.ToString()
            : (board.Size + 1 - rank).ToString();
    }

    // render the board from the perspective of the player (Dependent on colour)
    private static void PrintBoard(BoardGen board, string colour)
    {
        var (rankRange, fileRange, labels) = GetBoardOrientation(colour);
        foreach (var x in rankRange)
        {
            Console.Write($"{GetRankLabel(x, colour, board)} ");
            foreach (var y in fileRange)
            { PrintSquare(board, x, y); }
            Console.WriteLine();
        }
        Console.WriteLine($"  {labels}");
    }

    // draw a single square on the console, including the board color and piece symbol (If there is one)
    private static void PrintSquare(BoardGen board, int x, int y)
    {
        bool isLightSquare = (x + y) % 2 == 0;

        Console.BackgroundColor = isLightSquare ? ConsoleColor.Gray : ConsoleColor.Green; // makes the pieces easier to see
        var piece = board.GeneratedBoard[x, y].Piece;
        Console.ForegroundColor = piece is null ? ConsoleColor.Black : (piece.Colour == "WHITE" ? ConsoleColor.White : ConsoleColor.Black);
        Console.Write($"{piece?.Unicode ?? ' '} ");
        Console.ResetColor();
    }

    // populate the board with a standard chess starting position
    private static void GeneratePieces(BoardGen board, bool standard)
    {
        if (standard)
        {
            GenerateBackRank(board, 2, "WHITE");
            GenerateBackRank(board, 9, "BLACK");
            GeneratePawns(board);
        }
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
