using PizzaBox.Data;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Client
{
    public static class Dependencies
    {
        public static IRepository CreateRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PizzaBox.Data.Entity.PizzaBoxInformationContext>();
            optionsBuilder.UseSqlServer("Server=tcp:pizzasavinginformation.database.windows.net,1433;Initial Catalog=PizzaBoxInformation;Persist Security Info=False;User ID=dev;Password=Password1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var dbContext = new PizzaBox.Data.Entity.PizzaBoxInformationContext(optionsBuilder.Options);
            return new Repository(dbContext);
        }
    }
}