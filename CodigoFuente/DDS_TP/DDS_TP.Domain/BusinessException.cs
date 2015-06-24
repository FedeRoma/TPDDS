using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDS_TP.Domain
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
