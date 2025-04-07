using Umbraco.Cms.Core.Manifest;

namespace mttblss.DynamicCrops
{
    internal class DynamicCropsManifestFilter : IManifestFilter
    {
        public void Filter(List<PackageManifest> manifests)
        {
            var assembly = typeof(DynamicCropsManifestFilter).Assembly;

            manifests.Add(new PackageManifest
            {
                PackageName = "Dynamic Crops ",
                Version = assembly.GetName()?.Version?.ToString(3) ?? "0.1.0",
                AllowPackageTelemetry = true,
                Scripts = new string[] {
                    // List any Script files
                    // Urls should start '/App_Plugins/DynamicCrops/' not '/wwwroot/DynamicCrops/', e.g.
                    // "/App_Plugins/DynamicCrops/Scripts/scripts.js"
                },
                Stylesheets = new string[]
                {
                    // List any Stylesheet files
                    // Urls should start '/App_Plugins/DynamicCrops/' not '/wwwroot/DynamicCrops/', e.g.
                    // "/App_Plugins/DynamicCrops/Styles/styles.css"
                }
            });
        }
    }
}
