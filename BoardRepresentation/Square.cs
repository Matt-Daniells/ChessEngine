using System.Data;

namespace Board
{
    // Using structs as they're more efficient than classes when in arrays
    public struct Square(int rank, int file)
    {
        public int Rank = rank;
        public int File = file;
    }
}