using System;
using System.Net.Http;
using System.Threading.Tasks;
using Enums;
using Extensions;
using Models;
using Models.Map;
using Models.Requests;

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
        
        public async Task<Response<VectorTile>> GetVectorTileMap(GetVectorTileRequest request)
        {
            if(request == null)
                throw new ArgumentNullException();
            var response = new Response<VectorTile>();
            try
            {
                response.Payload.Bytes = await RetrieveBytes($"v4/{request.TilesetId}/{request.Zoom}/{request.X}/{request.Y}.{request.Format.GetDescription()}?access_token={_mapBoxToken}");
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseStatusCode.Fail;
                response.Message = e.Message;
                return response;
            }
        }

        public async Task<Response<RasterTile>> GetRasterTileMap(GetRasterTileRequest request)
        {
            if(request == null)
                throw new ArgumentNullException();
            var response = new Response<RasterTile>();
            try
            {
                response.Payload.Bytes = await RetrieveBytes($"v4/{request.TilesetId}/{request.Zoom}/{request.X}/{request.Y}@2x.{request.Format.GetDescription()}?access_token={_mapBoxToken}");
                return response;
            }
            catch (Exception e)
            {
                response.StatusCode = ResponseStatusCode.Fail;
                response.Message = e.Message;
                return response;
            }
        }

        public async Task<Response<StaticImage>> GetStaticImageMap(GetStaticImageRequest request)
        {
            var response = new Response<StaticImage>();
            try
            {
                response.Payload.Bytes = await RetrieveBytes($"styles/v1/{request.Username}/{request.StyleId}/static/{request.Overlay}/{request.Longitude},{request.Latitude},{request.Zoom},{request.Bearing},{request.Pitch}/{request.Width}x{request.Height}@2x?access_token={_mapBoxToken}");
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