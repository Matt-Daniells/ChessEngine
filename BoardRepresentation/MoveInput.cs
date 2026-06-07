namespace Board
{
    public class Move
    {
        public BoardGen board { get; }
        public string notation {get;}

        public Move(BoardGen Board, string Notation)
        {
            board = Board ?? throw new ArgumentNullException(nameof(board));
            notation = Notation ?? throw new ArgumentNullException(nameof(notation));
            //SplitNotation();
            foreach(var chunk in SplitNotation())
            {
                if (chunk.Length > 2)
                {
                    string square_string = chunk[1].ToString() + chunk[2];
                    Square s = (Square)board.LookupSquare(square_string);
                    char piece = chunk[0];
                    Console.WriteLine(CheckOccupation(piece, s).ToString());
                }
            }
        }

        private List<string> SplitNotation()
        {
            char[] splitters = ['x','+','='];
            List<string> chunks = [.. notation.Split(splitters)];

            foreach (char c in notation)
            {
                if (splitters.Contains(c)) {chunks.Add(c.ToString());}
            }

            return chunks;
        }

        private bool Castling()
        {
            return notation[0] == 'O';
        }

        private string CastlingDirection()
        {
            string side = SplitNotation().Count > 2 
            ? "Queen" 
            : "King";

            return side;
        }

        private bool CheckOccupation(char piece, Square square)
        {
            if (square.IsOccupied())
            {
                string type_string = square.Piece.Type.ToString();
                return char.ToUpperInvariant(type_string[0]) == char.ToUpperInvariant(piece);
            }

            return false;
        }
    }
}