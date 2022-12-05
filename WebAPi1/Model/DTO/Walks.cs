//using WebApplication1.Model.Domain;

namespace WebApplication1.Model.DTO
{
    public class Walks
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultyID { get; set; }
        public Region Region { get; set; }
        public WalkDificulty Walkdifficulty { get; set; }
    }
}
