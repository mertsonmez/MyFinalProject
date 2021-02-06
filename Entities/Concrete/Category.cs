using Core.Entities;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın standartı !! herhangi bir interface implementasyonu almıyorsa burada sıkıntı vardır demek.
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }



    }
}
