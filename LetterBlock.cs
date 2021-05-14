public class LetterBlock
{
    public char Letter { get; }
    public int Count { get; set; }

    public LetterBlock(char letter) : this(letter, count: 1)
    {
    }

    public LetterBlock(char letter, int count)
    {
        Letter = letter;
        Count = count;
    }
}
