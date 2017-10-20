using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessException
{
    public class BusinessValidationError
    {
        public BusinessValidationError()
        {
        }
        public BusinessValidationError(string msg)
        {
            Message = msg;
        }
        public BusinessValidationError(string msg, Exception ex)
        {
            Message = msg;
            Exception = ex;
        }
        public string Message { get; set; }
        public Exception Exception { get; set; }

    }
}
