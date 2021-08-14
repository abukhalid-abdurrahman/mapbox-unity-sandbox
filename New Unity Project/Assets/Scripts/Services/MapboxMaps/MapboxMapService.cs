using System;
using System.Threading.Tasks;
using Models;
using Models.Map;

namespace Services.MapboxMaps
{
    public class MapboxMapService : IMapboxMapService
    {
        private readonly string _mapBoxToken;
        private readonly string _baseUrl;
        public MapboxMapService()
        {
            _baseUrl = "https://api.mapbox.com";
            _mapBoxToken = "pk.eyJ1IjoiZmFoYS1iZXJkaWV2IiwiYSI6ImNrczl3MTdvMzFhMDkyb3MwNzFlNTZpcmwifQ.aeRE3fuGsx2eyvArIoXPUg";
        }

        public async Task<Response<VectorTile>> GetVectorTileMap()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<RasterTile>> GetRasterTileMap()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<StaticImage>> GetStaticImageMap()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<StaticTile>> GetStaticTileMap()
        {
            throw new NotImplementedException();
        }
    }
}