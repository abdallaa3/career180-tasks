using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2c180.models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Bref { get; set; }

        // علاقة One-to-Many مع News
        public virtual ICollection<News> NewsItems { get; set; }
    }
}
