using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Article
{
    public class Article : BaseEntity
    {
        private DateTime createTime;

        public string title { get; set; }

        public string body { get; set; }

        public string author { get; set; }

        public int CategoryId { get; set; }

        public String CategoryDesc { get; set; }

        public DateTime CreateTime {
            get {
                if (createTime == Convert.ToDateTime("0001/1/1 0:00:00"))
                {
                    createTime = DateTime.Now;
                }
                return createTime;
            }
            set => createTime = value;
        }
    }
}
