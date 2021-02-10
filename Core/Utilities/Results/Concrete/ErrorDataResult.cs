using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //1.yol
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //2.yol
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //3.yol data default haliyle kullanabilir
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        //4.Yol
        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
