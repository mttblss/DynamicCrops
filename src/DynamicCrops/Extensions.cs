using System.Diagnostics.CodeAnalysis;
using mttblss.DynamicCrops.Core;
using Umbraco.Cms.Core.Models;

namespace mttblss.DynamicCrops;

public static class Extensions
{
    [return: NotNullIfNotNull("mediaWithCrops")]
    public static DynamicCrops? ToDynamicCrops(this MediaWithCrops? mediaWithCrops)
    {
        return mediaWithCrops is null ? null : new DynamicCrops(mediaWithCrops);
    }

    public static string BackgroundPositionCss(this DynamicCrops image)
    {
        return image._crops.BackgroundPositionCss();
    }

    public static string ObjectPositionCss(this DynamicCrops image)
    {
        return image._crops.ObjectPositionCss();
    }

    public static string BackgroundPositionCss(this MediaWithCrops image)
    {
        return image.ToDynamicCrops()._crops.BackgroundPositionCss();
    }

    public static string ObjectPositionCss(this MediaWithCrops image)
    {
        return image.ToDynamicCrops()._crops.ObjectPositionCss();
    }

    public static string? BackgroundPositionClass(this DynamicCrops image)
    {
        return image._crops.BackgroundPositionClass();
    }

    public static string AspectRatioCss(this DynamicCrops image)
    {
        return image._crops.AspectRatioCss();
    }


}
