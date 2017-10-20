using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.comment
{
    public class comment : BaseEntity 
    {
        public string content { get; set; }

        public int IsEnable { get; set; }

        public int Like { get; set; }

        public int Hate { get; set; }

        public int ArticleId { get; set; }

        private DateTime createTime;

        public DateTime CreateTime
        {
            get
            {
                if (createTime == Convert.ToDateTime("0001/1/1 0:00:00"))
                {
                    createTime = DateTime.Now;
                }
                return createTime;
            }
            set
            {
                createTime = value;
            }
        }
    }
}
