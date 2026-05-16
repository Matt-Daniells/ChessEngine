namespace Board
{
    // Using structs as they're more efficient than classes when in arrays
    public struct Square(int rank, int file)
    {
        public int Rank = rank;
        public int File = file;
        public int Value = -1;

        public Piece? Piece { get; set; }

        // return a value 0-63 for each square

        public void SetValue(int value)
        {
            Value = value;
        }

        // return a chessboard style value for each square i.e a1
        public string DisplayLocation()
        {
            return $"{(char)('a' + File)}{Rank + 1}";
        }

        public bool IsOccupied()
        {
            return Piece != null;
        }
    }
}