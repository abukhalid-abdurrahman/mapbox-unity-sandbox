using System.Threading.Tasks;
using Models.Map;

namespace Services.MapboxMaps
{
    public class MapboxMapService : IMapboxMapService
    {
        public async Task<VectorTile> GetVectorTileMap()
        {
            throw new System.NotImplementedException();
        }

        public async Task<RasterTile> GetRasterTileMap()
        {
            throw new System.NotImplementedException();
        }

        public async Task<StaticImage> GetStaticImageMap()
        {
            throw new System.NotImplementedException();
        }

        public async Task<StaticTile> GetStaticTileMap()
        {
            throw new System.NotImplementedException();
        }
    }
}