namespace WebApplication7.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication7.Models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        public System.Data.Entity.DbSet<WebApplication7.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.Food> Foods { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.Order> Orders { get; set; }

        public DbSet<WebApplication7.Models.OrderDetail> OrderDetails { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}