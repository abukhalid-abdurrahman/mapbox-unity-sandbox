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
            _baseUrl = "https://api.mapbox.com/";
            _mapBoxToken = "pk.eyJ1IjoiZmFoYS1iZXJkaWV2IiwiYSI6ImNrczl3MTdvMzFhMDkyb3MwNzFlNTZpcmwifQ.aeRE3fuGsx2eyvArIoXPUg";
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = TimeSpan.FromMinutes(1)
            };
        }

        private async Task<byte[]> RetrieveBytes(string url)
        {
            var httpRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_httpClient.BaseAddress + url)
            };
            var responseMessage = await _httpClient.SendAsync(httpRequest);
            var responseBytes = await responseMessage.Content.ReadAsByteArrayAsync();
            return responseBytes;
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
                response.Payload.Bytes = await RetrieveBytes($"v4/{tilesetId}/{zoom}/{x}/{y}.{format}?access_token={_mapBoxToken}");
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
            var response = new Response<RasterTile>();
            try
            {
                var tilesetId = "mapbox.satellite";
                var zoom = "1";
                var x = "0";
                var y = "0";
                var format = "jpg90";
                response.Payload.Bytes = await RetrieveBytes($"v4/{tilesetId}/{zoom}/{x}/{y}@2x.{format}?access_token={_mapBoxToken}");
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseStatusCode.Fail;
                response.Message = e.Message;
                return response;
            }
        }

        public async Task<Response<StaticImage>> GetStaticImageMap()
        {
            var response = new Response<StaticImage>();
            try
            {
                var username = "mapbox";
                var styleId = "streets-v11";
                var overlay = "static";
                var zoom = "15.25";
                var lon = "-122.4241";
                var lat = "37.78";
                var bearing = "0";
                var pitch = "60";
                var width = "400";
                var height = "400";
                response.Payload.Bytes = await RetrieveBytes($"styles/v1/{username}/{styleId}/static/{overlay}/{lon},{lat},{zoom},{bearing},{pitch}/{width}x{height}@2x?access_token={_mapBoxToken}");
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseStatusCode.Fail;
                response.Message = e.Message;
                return response;
            }
        }

        public async Task<Response<StaticTile>> GetStaticTileMap()
        {
            var response = new Response<StaticTile>();
            try
            {
                var x = "1";
                var y = "0";
                var username = "mapbox";
                var styleId = "satellite-v9";
                var tilesize = "1";
                var z = "1";
                response.Payload.Bytes = await RetrieveBytes($"styles/v1/{username}/{styleId}/tiles/{tilesize}/{z}/{x}/{y}@2x?access_token={_mapBoxToken}");
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseStatusCode.Fail;
                response.Message = e.Message;
                return response;
            }        
        }
    }
}