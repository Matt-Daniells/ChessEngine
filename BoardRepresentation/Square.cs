using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Board
{
    // Using structs as they're more efficient than classes when in arrays
    public struct Square(int rank, int file)
    {
        public int Rank = rank;
        public int File = file;

        // return a value 0-63 for each square
        public int DisplayValue()
        {
            return Rank*8 + File;
        }

        // return a chessboard style value for each square i.e a1
        public string DisplayLocation()
        {
            return $"{(char)('a' + File)}{Rank + 1}";
        }
    }
}