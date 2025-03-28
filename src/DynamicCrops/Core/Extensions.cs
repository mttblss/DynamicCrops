namespace mttblss.DynamicCrops.Core;

public static class Extensions
{
    public static int ToIntPercent(this decimal value)
    {
        return (int)Math.Round(ToDecimalPercent(value),0);
    }

    public static decimal ToDecimalPercent(this decimal value)
    {
        return value * 100;
    }

    public static bool HasCoordinates(this Crop? crop)
    {
        return crop is { TopLeft: not null, BottomRight: not null };
    }

    public static string BackgroundPositionCss(this Crops image)
    {
        return
            $"background-position: {image.BackgroundLeft().ToIntPercent()}% {image.BackgroundTop().ToIntPercent()}%;";
    }

    public static string ObjectPositionCss(this Crops image)
    {
        return
            $"object-position: {image.BackgroundLeft().ToIntPercent()}% {image.BackgroundTop().ToIntPercent()}%;";
    }

    public static string? BackgroundPositionClass(this Crops image)
    {
        return $"fpx{image.BackgroundLeft().ToIntPercent()} fpy{image.BackgroundTop().ToIntPercent()}";
    }

    public static string AspectRatioCss(this Crops image)
    {
        return $"aspect-ratio: {image.ImageAspectRatio:F3};";
    }

    public static string DataPosition(this Crops image)
    {
        return $"{image.BackgroundLeft().ToIntPercent()}% {image.BackgroundTop().ToIntPercent()}%";
    }
}
