﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameBroingToDoList.Shared.Errors
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public static implicit operator string(Error error) => error?.Code ?? string.Empty;
        public static readonly Error None = new Error(string.Empty, string.Empty);
    }
}
