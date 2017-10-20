using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Query
{
    public class ArticleQueryViewModel
    {
        public string title { get; set; }

        public string author { get; set; }

        public int categoryId { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }
    }
}
