using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params : istediğin kadar parametre eklememizi sağlıyor.
        //Liste şeklinde de yapabiliriz!!
        //public static List<IResult> Run(params IResult[] logics) //logic iş kuralı demek
        public static IResult Run(params IResult[] logics) //logic iş kuralı demek
        {
            //List<IResult> errorResults = new List<IResult>();

            foreach (var logic in logics)
            {
                if (!logic.Success) //logic in success durumu başarısız ise
                {
                    return logic;
                    //parametre ile gönderdiğimiz iş kurallarından başlarırız olanı gönderiyoruz.

                    //errorResults.Add(logic);

                }
            }

            //return errorResults;
            return null;
        }
    }
}
