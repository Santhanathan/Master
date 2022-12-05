namespace WebApplication1.Model.DTO
{
    public class AddWalkRequest
    {
        public string Name { get; set; }
        public double length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultyID { get; set; }
    }
}
