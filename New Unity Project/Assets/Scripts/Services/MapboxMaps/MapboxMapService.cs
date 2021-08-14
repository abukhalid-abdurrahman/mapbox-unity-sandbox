using System;
using System.Net.Http;
using System.Threading.Tasks;
using Enums;
using Models;
using Models.Map;

namespace Services.MapboxMaps
{
    public class MapboxMapService : IMapboxMapService
    {
        private readonly string _mapBoxToken;
        private readonly string _baseUrl;

        private readonly HttpClient _httpClient;
        
        public MapboxMapService()
        {
            _baseUrl = "https://api.mapbox.com";
            _mapBoxToken = "pk.eyJ1IjoiZmFoYS1iZXJkaWV2IiwiYSI6ImNrczl3MTdvMzFhMDkyb3MwNzFlNTZpcmwifQ.aeRE3fuGsx2eyvArIoXPUg";
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = TimeSpan.FromMinutes(1)
            };
        }

        public async Task<Response<VectorTile>> GetVectorTileMap()
        {
            var response = new Response<VectorTile>();
            try
            {
                var tilesetId = "mapbox.mapbox-streets-v8";
                var zoom = "1";
                var x = "0";
                var y = "0";
                var format = "mvt";
                var httpRequest = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"/v4/{tilesetId}/{zoom}/{x}/{y}.{format}?access_token={_mapBoxToken}")
                };

                var responseMessage = await _httpClient.SendAsync(httpRequest);
                var responseBytes = await responseMessage.Content.ReadAsByteArrayAsync();
                response.Payload.Bytes = responseBytes;
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseStatusCode.Fail;
                response.Message = e.Message;
                return response;
            }
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