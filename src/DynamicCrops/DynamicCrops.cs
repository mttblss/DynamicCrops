using mttblss.DynamicCrops.Core;
using Umbraco.Cms.Core.Models;

namespace mttblss.DynamicCrops;

public class DynamicCrops
{
    internal readonly Crops _crops;

    public DynamicCrops(MediaWithCrops mediaWithCrops)
    {
        _crops = new Crops();
        InitializeDynamic(mediaWithCrops);
    }

    private void InitializeDynamic(MediaWithCrops mediaWithCrops)
    {
        var crops = (from crop in mediaWithCrops.LocalCrops?.Crops
            let topLeft = crop.Coordinates is null
                ? null
                : new Coordinate(crop.Coordinates.X1, crop.Coordinates.Y1)
            let bottomRight = crop.Coordinates is null
                ? null
                : new Coordinate(1 - crop.Coordinates.X2, 1 - crop.Coordinates.Y2)
            select new Crop(crop.Alias ?? "", (decimal)crop.Width / crop.Height, topLeft, bottomRight)).ToList();

        _crops.ImageFocalPoint = mediaWithCrops.LocalCrops?.FocalPoint is null
            ? null
            : new Coordinate(mediaWithCrops.LocalCrops.FocalPoint.Left, mediaWithCrops.LocalCrops.FocalPoint.Top);
        _crops.ImageAspectRatio = AspectRatio(mediaWithCrops);
        _crops.WideCrop = crops.Count == 0 ? null : crops.MaxBy(x => x.AspectRatio);
        _crops.NarrowCrop = crops.Count == 0 ? null : crops.MinBy(x => x.AspectRatio);
    }

    private static decimal AspectRatio(MediaWithCrops mediaWithCrops)
    {
        var width = mediaWithCrops.Content.GetProperty("umbracoWidth")?.GetValue() as int?;
        var height = mediaWithCrops.Content.GetProperty("UmbracoHeight")?.GetValue() as int?;
        return (width is not null && height is not null ? (decimal)width / height : 0) ?? 0;
    }

    public Crop? WideCrop => _crops.WideCrop;
    public Crop? NarrowCrop => _crops.NarrowCrop;
    public decimal ImageAspectRatio => _crops.ImageAspectRatio;
    public Coordinate? ImageFocalPoint => _crops.ImageFocalPoint;
}
