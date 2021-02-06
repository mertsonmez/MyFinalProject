using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context nesnesi: db tabloları ile proje classlarını bağlamak.context demek veri tabanı ile kendi entitilerimizi ilişkilendirdiğimiz yerdir.
    public class NorthwindContext : DbContext
    {
        /*
         * Hangi veri Tabanı ??
         * Hangi tablolarla hangi entitiyler bağlantılı ??
         */

        //Bu method senin projenin hangi veritabanı ile ilişkilendirildiğini belittiğin yer !!!
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection stringde büyük küçük farketmez sql case insensitive olduğu için.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=true;");
        }

        //benim hangi classım hangi tabloya karşılık geliyor ?? burada belirtiyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
