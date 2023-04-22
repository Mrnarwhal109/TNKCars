namespace TNKCars.DataAccess
{
    public class Engine
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CylinderCount { get; set; }

        public double Displacement { get; set; }

        public DateTime AddedAt { get; set; }

        public Engine(int id, string title, int cylinder_count, double displacement, DateTime added_at) 
        {
            Id = id;
            Title = title;
            CylinderCount = cylinder_count;
            Displacement = displacement;
            AddedAt = added_at;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
