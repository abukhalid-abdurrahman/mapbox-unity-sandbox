﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Enums;
using Models;
using Models.Isochrone;
using Models.Requests;
using Newtonsoft.Json;

namespace Services.MapboxIsochrone
{
    public class MapboxIsochrone : IMapboxIsochrone
    {
        private readonly string _mapBoxToken;
        private readonly string _baseUrl;

        private readonly HttpClient _httpClient;
        
        public MapboxIsochrone()
        {
            _baseUrl = "https://api.mapbox.com/";
            _mapBoxToken = "pk.eyJ1IjoiZmFoYS1iZXJkaWV2IiwiYSI6ImNrczl3MTdvMzFhMDkyb3MwNzFlNTZpcmwifQ.aeRE3fuGsx2eyvArIoXPUg";
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_baseUrl),
                Timeout = TimeSpan.FromMinutes(1)
            };
        }
        
        public async Task<Response<Isochrone>> GetIsochrone(GetIsochroneRequest request)
        {
            if (request == null)
                throw new ArgumentNullException();
            
            var response = new Response<Isochrone>();
            
            try
            {
                var url = $"/isochrone/v1/{request.RoutingProfile}/{request.Coordinate}?{request.ContoursMeters}?access_token={_mapBoxToken}";
                var requestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_httpClient.BaseAddress + url)
                };
                var responseMessage = await _httpClient.SendAsync(requestMessage);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    response.StatusCode = ResponseStatusCode.Fail;
                    response.Message = responseMessage.ReasonPhrase;
                    return response;
                }
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<Isochrone>(responseContent);
                response.Payload = entity;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.StatusCode = ResponseStatusCode.Fail;
                return response;
            }
        }
    }
}