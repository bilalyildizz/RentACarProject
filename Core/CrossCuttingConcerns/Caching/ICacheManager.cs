using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //cache içine yeni bir şey ekleyebiliriz.
        void Add(string key, object value, int duration);
        // veri getrmek için key veririz hangi tip olduğunuda belirtiriz.
        T Get<T>(string key);
        object Get(string key);
        bool IsAdd(string key);
        void Remove(string key);

        //&ayırt edici olabilecek bu sayede içinde belirli bir kelime var mı diye belirteceğiz
        void RemoveByPattern(string pattern);

    }
}
