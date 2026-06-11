namespace Board.Pieces;

public class Knight(string colour) : Piece(colour, PieceType.Knight)
{
    private const char WhiteUnicode = '\u2658';
    private const char BlackUnicode = '\u265E';

    public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
}
