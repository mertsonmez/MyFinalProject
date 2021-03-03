using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConserns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern : var olan bir sistemi kendi sistemime uyarlıyorum.Ben sana göre değil Sen bana göre çalışacaksın diyoruz.


        //Bu bir interface ve bunu çözmemiz lazım !
        IMemoryCache _memoryCache;
        //nasıl ?
        //oda CoreModule da

        //_memoryCache i injectiondan almamız gerekiyor
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>(); //IMemoryCache karşılığını ver diyoruz.
        }

        public void Add(string key, object value, int duration)
        {
            //Service toolu kullanacağız IMemoryCache _memoryCache; karşılığını vermek için
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration)); 


        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key,out _);//eğer birşey döndürmek istemiyorsan out değeri set edip döndürüyor istemiyorsan x# da şu teknik kullanılır out _
        }

        public void Remove(string key)
        {

            //.net core dan gelen kodu kendimize uyarlıyoruz.
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            //ona verdiğimiz bir pattern e göre silme işlemi yapıcak !!

            //RemoveByPattern bellekten silmeye yarıyor çalışma anında!! bunuda reflectionla yaparız !! 
            //reflection ile kodu çalışma anında birşey yapmaya yarıyor.



            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //git belleğe bak EntriesCollection ı bul
            //cache datalarını EntriesCollection ismiyle tutuyorum


            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            //definition u memerycache olanları bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
            //herbir cache elamanında
            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //bu kurala uyanları
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
            //foreach ile bellekten tek tek siliyor.
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }

        }
    }
}
