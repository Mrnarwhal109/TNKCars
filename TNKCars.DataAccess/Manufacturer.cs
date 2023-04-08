using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNKCars.DataAccess
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int FoundedYear { get; set; }

        public DateTime AddedAt { get; set; }

        public Manufacturer(int id, string title, int founded_year, DateTime added_at)
        {
            Id = id;
            Title = title;
            FoundedYear = founded_year;
            AddedAt = added_at;
        }
    }
}
