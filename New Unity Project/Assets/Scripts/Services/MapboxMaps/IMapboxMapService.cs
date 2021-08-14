using System.Threading.Tasks;
using Models;
using Models.Map;

namespace Services.MapboxMaps
{
    public interface IMapboxMapService
    {
        Task<Response<VectorTile>> GetVectorTileMap();
        Task<Response<RasterTile>> GetRasterTileMap();
        Task<Response<StaticImage>> GetStaticImageMap();
        Task<Response<StaticTile>> GetStaticTileMap();
    }
}
