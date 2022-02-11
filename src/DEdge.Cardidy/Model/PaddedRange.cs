namespace DEdge.Model;

internal record PaddedRange
{
    private const int identificationNumberLength = 8;
    private const int minDigit = 0;
    private const int maxDigit = 9;

    internal int Min { get; }
    internal int Max { get; }

    internal PaddedRange(int fix) : this(fix, fix) { }

    internal PaddedRange(int min, int max)
    {
        Min = min.PadRight(identificationNumberLength, minDigit);
        Max = max.PadRight(identificationNumberLength, maxDigit);
    }

    internal bool Contains(int value) => value >= Min && value <= Max;
}
