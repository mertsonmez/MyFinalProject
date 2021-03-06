﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data , bool success , string message) : base(success,message)  //diğer resulttan tek farkı data var
        {
            Data = data;
        }

        public DataResult(T data , bool success) : base(success) 
        {
            Data = data;
        }


        public T Data { get; }
    }
}
