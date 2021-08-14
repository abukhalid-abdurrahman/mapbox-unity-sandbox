namespace Models.Requests
{
    public class GetRasterTileRequest
    {
        public string TilesetId { get; set; }
        public decimal Zoom { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public string Format { get; set; }
    }
}