using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2c180.models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Bref { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        // العلاقة مع Catalog
        public int CatalogId { get; set; }
        public virtual Category Catalog { get; set; }

        // العلاقة مع Author
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
