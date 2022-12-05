namespace WebApplication1.Model.DTO
{
    public class AddRegionRequest
    {
        public string code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long populatiom { get; set; }
    }
}
