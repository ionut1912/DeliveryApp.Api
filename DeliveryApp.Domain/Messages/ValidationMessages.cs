﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Domain.Messages
{
    public static class ValidationMessages
    {
        public  static class  AccountValidator
        {
            public static string NotEmpty(string field)
            {
                return $"Filed {field} should not be empty";
            }

            public static string MaxLength(string field,int maxLength)
            {
                return $"Field {field} should have max length {maxLength}";

            }
        }
    }
}
