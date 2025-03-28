namespace mttblss.DynamicCrops.Core;

public class Coordinate
{
    public Coordinate(decimal left, decimal top)
    {
        Left = left;
        Top = top;
    }

    public decimal Left { get; set; }
    public decimal Top { get; set; }
}
