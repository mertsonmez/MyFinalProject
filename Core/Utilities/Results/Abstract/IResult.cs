using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        //içinde bir işlem sonucu birde bilgilendirme mesajı olsun içinde ki bizi kullanacaklar için bilgilendirme olsun
        bool Success { get; } // başarılı mı başarısız mı örn : yapmaya çalıştığın ekleme işlemi

        string Message { get; } // başarılı yada başarısız sonucuna göre ürün eklendi yada eklenemedi sonucu vericek bize
    }
}
