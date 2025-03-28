namespace mttblss.DynamicCrops.Core;

public class Crop
{
   public Crop(string name, decimal aspectRatio, Coordinate? topLeft = null, Coordinate? bottomRight = null)
   {
      Name = name;
      AspectRatio = aspectRatio;
      TopLeft = topLeft;
      BottomRight = bottomRight;
   }

   public string Name { get; set; }
   public decimal AspectRatio { get; set; }
   public Coordinate? TopLeft { get; set; }
   public Coordinate? BottomRight { get; set; }
}
