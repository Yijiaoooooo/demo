using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Reservation
{
    public class Reservation : BaseEntity
    {
        public string Name { get; set; }

        public string Location { get; set; }

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
            set => createTime = value;
        }

        
    }
}
