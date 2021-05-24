using System.Collections.Generic;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        List<LetterBlock> letterBlocks = ParseEncodingInput(input);
        var result = new StringBuilder();

        foreach (var block in letterBlocks)
        {
            if(block.Count > 1)
            {
                result.Append(block.Count);
            }
            result.Append(block.Letter);
        }
        return result.ToString();
    }

    public static string Decode(string input)
    {
        List<LetterBlock> blocks = ParseDecodingInput(input);
        var output = new StringBuilder();
        foreach (var block in blocks)
        {
            for (int i = 0; i < block.Count; i++)
            {
                output.Append(block.Letter);
            }
        }
        return output.ToString();
    }

    private static List<LetterBlock> ParseEncodingInput(string input)
    {
        var blocks = new List<LetterBlock>();
        foreach (var currentLetter in input)
        {
            if(blocks.Count == 0)
            {
                blocks.Add(new LetterBlock(currentLetter));
                continue;
            }

            var lastBlock = blocks[^1];
            if (lastBlock.Letter == currentLetter)
            {
                lastBlock.Count++;
                blocks[^1] = lastBlock;
            }
            else
            {
                blocks.Add(new LetterBlock(currentLetter));
            }
        }
        return blocks;
    }

    private static List<LetterBlock> ParseDecodingInput(string input)
    {
        var blocks = new List<LetterBlock>();
        var countBuilder = new StringBuilder();
        foreach (char symbol in input)
        {
            if (char.IsDigit(symbol))
            {
                countBuilder.Append(symbol);
            }
            else
            {
                int count = countBuilder.Length > 0 ? int.Parse(countBuilder.ToString()) : 1;
                blocks.Add(new LetterBlock(symbol, count));
                countBuilder.Clear();
            }
        }
        return blocks;
    }
}
