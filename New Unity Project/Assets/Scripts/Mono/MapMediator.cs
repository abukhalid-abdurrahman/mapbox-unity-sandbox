using Enums;
using Services.MapboxMaps;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mono
{
    public class MapMediator : MonoBehaviour
    {
        [FormerlySerializedAs("OutputTransform")] 
        public Transform outputTransform;

        private IMapboxMapService _mapboxMapService;

        private void Start()
        {
            _mapboxMapService = new MapboxMapService();
            var rasterImage = _mapboxMapService
                .GetRasterTileMap().GetAwaiter().GetResult();
            if (rasterImage.StatusCode == ResponseStatusCode.Success)
            {
                var tex = new Texture2D(2, 2);
                tex.LoadImage(rasterImage.Payload.Bytes);
                outputTransform.GetComponent<Renderer>().material.mainTexture = tex;
            }
            else
            {
                Debug.LogError(rasterImage.Message);
            }
        }
    }
}