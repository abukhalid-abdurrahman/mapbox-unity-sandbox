using System.Threading.Tasks;
using Models;
using Models.Map;
using Models.Requests;

namespace Services.MapboxMaps
{
    public interface IMapboxMapService
    {
        Task<Response<VectorTile>> GetVectorTileMap();
        Task<Response<RasterTile>> GetRasterTileMap(GetRasterTileRequest request);
        Task<Response<StaticImage>> GetStaticImageMap();
        Task<Response<StaticTile>> GetStaticTileMap();
    }
}
