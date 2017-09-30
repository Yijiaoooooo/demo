using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    /// <summary>
    /// 封装公共属性
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        private Guid _rowGuid;

        public Guid rowGuid
        {
            get
            {
                if (_rowGuid == Guid.Empty)
                {
                    _rowGuid = Guid.NewGuid();
                }
                return _rowGuid;
            }
            set
            {
                _rowGuid = value;
            }
        }

    }
}
