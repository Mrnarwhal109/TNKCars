namespace TNKCars.DataAccess
{
    public class Transmission
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int GearCount { get; set; }

        public bool IsAutomatic { get; set; }

        public DateTime AddedAt { get; set; }

        public Transmission(int id, string title, int cylinder_count, bool is_automatic, DateTime added_at)
        {
            Id = id;
            Title = title;
            GearCount = cylinder_count;
            IsAutomatic = is_automatic;
            AddedAt = added_at;
        }
    }
}
