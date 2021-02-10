using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //base e birşey göndermek istiyorsak base keywordu kullanırız Base Burada Result
        public SuccessResult(string message) : base(true , message)
        {
            //true yu default vermek için bu yapıyı kurduk!!
        }

        public SuccessResult() : base(true)
        {
                
        }

    }
}
