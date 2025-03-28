namespace mttblss.DynamicCrops.Core;

public class Crops
{
    public Coordinate? ImageFocalPoint { get; set; }
    public decimal ImageAspectRatio { get; set; }
    public Crop? WideCrop { get; set; }
    public Crop? NarrowCrop { get; set; }

    private static decimal Inverse(decimal value)
    {
        return value == 0 ? value : 1 / value;
    }

    private static decimal InRange(decimal value, decimal min = 0, decimal max = 1)
    {
        return value <= min ? min : value >= max ? max : value;
    }

    public decimal BackgroundLeft(decimal defaultValue = 0.5m)
    {
        var leftValue = NarrowCrop.HasCoordinates()
            ? (NarrowCrop!.TopLeft!.Left + NarrowCrop.BottomRight!.Left) / 2
            : ImageFocalPoint?.Left ?? defaultValue;
        if (NarrowCrop == null) return leftValue;
        var leftScale = (ImageAspectRatio + NarrowCrop.AspectRatio / 2) / ImageAspectRatio;
        var leftAdjust = leftValue + leftValue * leftScale - leftScale / 2;
        return InRange(leftAdjust);
    }

    public decimal BackgroundTop(decimal defaultValue = 0.5m)
    {
        var topValue = WideCrop.HasCoordinates()
            ? (WideCrop!.TopLeft!.Top +  WideCrop.BottomRight!.Top) / 2
            : ImageFocalPoint?.Top ?? defaultValue;
        if (WideCrop == null) return topValue;
        var topScale = Inverse(ImageAspectRatio) / (Inverse(ImageAspectRatio) + Inverse(WideCrop.AspectRatio) / 2);
        var topAdjust = topValue + topValue * topScale - topScale / 2;
        return InRange(topAdjust);
    }
}
