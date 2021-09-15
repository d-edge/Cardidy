namespace Dedge.Model;

internal record PaddedRange
{
    internal int Min { get; }
    internal int Max { get; }

    internal PaddedRange(int fix) : this(fix, fix) { }

    internal PaddedRange(int min, int max)
    {
        Min = min.PadRight(6, 0);
        Max = max.PadRight(6, 9);
    }

    internal bool Contains(int value) => value >= Min && value <= Max;
}
