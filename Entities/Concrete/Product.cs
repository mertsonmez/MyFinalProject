using Core.Entities; //bunlara işaretleme diyoruz..

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        //bir class erişim belirgeçinin defaultu internaldır
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
