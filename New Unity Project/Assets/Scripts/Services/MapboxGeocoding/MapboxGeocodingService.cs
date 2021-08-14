using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.Geocoding;
using Models.Requests;

namespace Services.MapboxGeocoding
{
    public class MapboxGeocodingService : IMapboxGeocodingService
    {
        public async Task<Response<Geocoding>> GetForwardGeocoding(GetForwardGeocodingRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<Geocoding>> GetReverseGeocoding(GetReverseGeocodingRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Geocoding>>> GetReverseBatchGeocoding(GetReverseBatchGeocodingRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Geocoding>>> GetForwardBatchGeocoding(GetForwardBatchGeocodingRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}