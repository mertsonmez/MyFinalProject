using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //1.yol
        public SuccessDataResult(T data , string message) : base(data , true , message)
        {

        }
        //2.yol
        public SuccessDataResult(T data) : base(data , true)
        {

        }
        //3.yol data default haliyle kullanabilir
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }
        //4.Yol
        public SuccessDataResult() : base(default,true)
        {

        }

    }
}
