using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConserns.Caching
{
    public interface ICacheManager
    {
        //generic method vereceğiz
        T Get<T>(string key);

        //generic olmayan versiyonu
        object Get(string key); // tip dönüşümünü yapmak gerekir! (boxing)


        void Add(string key, object value, int duration); // key value ve cachde ne kadar duracak onu tutarız duration la

        //Cache de var mı kontrolünü sağlayan method yazarız!
        bool IsAdd(string key);

        void Remove(string key);

        //RegEx pattern örn: başı sonu önemli değil içinde get olanları silen
        void RemoveByPattern(string pattern);

    }
}
