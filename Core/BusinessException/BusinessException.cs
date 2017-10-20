using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessException
{
    public class BusinessException : Exception
    {
        public List<BusinessValidationError> Errors = new List<BusinessValidationError>();
        public BusinessException()
        {
        }

        public BusinessException(string msg) : base(msg)
        {
        }
        public BusinessException(string msg, Exception ex) : base(msg, ex)
        {
        }
        public BusinessException(string msg, string error) : base(msg)
        {
            Errors.Add(new BusinessValidationError() { Message = error });
        }
        public BusinessException(string msg, BusinessValidationError error) : base(msg)
        {
            Errors.Add(error);
        }
        public BusinessException(string msg, List<BusinessValidationError> errors) : base(msg)
        {
            Errors.AddRange(errors);
        }
        public void Merge(BusinessException bex)
        {
            Errors.AddRange(bex.Errors);
        }
        public void Merge(IEnumerable<BusinessValidationError> errors)
        {
            Errors.AddRange(errors);
        }



    }
}
