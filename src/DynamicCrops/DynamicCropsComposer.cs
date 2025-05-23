using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace mttblss.DynamicCrops
{
    internal class DynamicCropsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.ManifestFilters().Append<DynamicCropsManifestFilter>();
        }
    }
}
