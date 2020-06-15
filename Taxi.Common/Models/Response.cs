using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Common.Models
{
    public class Response
    {
        public bool IsSuccess { set; get; }
        public string Message { set; get; }
        public object Result { set; get; }
    }
}
