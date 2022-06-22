using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Data.Models
{
    public class Server : BaseModel<int>
    {
        public DateTime CreatedDateTime { get; set; }
        public DateTime? RemoveDateTime { get; set; }
    }

    public static class UserModelBuilderExtention
    {
        public static string TABLE_NAME = "Servers";

        public static void DescribeUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>(f => {
                f.Property(p => p.CreatedDateTime).IsRequired(true);
            });

            modelBuilder.Entity<Server>().ToTable(TABLE_NAME);
        }
    }
}
