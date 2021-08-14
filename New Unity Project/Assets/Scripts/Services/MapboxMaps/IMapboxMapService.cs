using System.Threading.Tasks;
using Models.Map;

namespace Services.MapboxMaps
{
    public interface IMapboxMapService
    {
        Task<VectorTile> GetVectorTileMap();
        Task<RasterTile> GetRasterTileMap();
        Task<StaticImage> GetStaticImageMap();
        Task<StaticTile> GetStaticTileMap();
    }
}
