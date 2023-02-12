using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Commons.Core
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public object Value { get; set; }
        public string Error { get; set; }

        public static Result Success(object value)
        {
            return new Result { IsSuccess = true, Value = value };
        }

        public static Result Failure(string error)
        {
            return new Result { IsSuccess = false, Error = error };
        }
    }
}
