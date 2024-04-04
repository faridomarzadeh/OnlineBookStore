using Common.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class DuplicatedSlugException:BaseDomainException
    {
        public DuplicatedSlugException():base(Constants.Exceptions.DUPLICATED_SLUG)
        {
            
        }
        public DuplicatedSlugException(string message):base(message)
        {

        }
    }
}
