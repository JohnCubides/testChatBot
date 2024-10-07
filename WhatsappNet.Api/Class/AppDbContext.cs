using Microsoft.EntityFrameworkCore;
using WhatsappNet.Api.Models;
using WhatsappNet.Api.Models.prueba;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WhatsappNet.Api.Class
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<ClientModel> Clientes { get; set; } // Cambia 'TuEntidad' por el nombre de tu modelo

        //public DbSet<InvoiceModel> Facturas { get; set; }

        //public DbSet<MessageModel> Messages { get; set; }
        //public DbSet<WhatsAppBusinessAccountModel> WhatsAppBusinessAccounts { get; set; }
        ////public DbSet<ContactModel> Contacts { get; set; }
        //public DbSet<MessageModel> MessagesModel { get; set; }
        //public DbSet<MediaModel> Media { get; set; }
        ////public DbSet<ErrorModel> Errors { get; set; }
        //public DbSet<InteractiveModel> Interactives { get; set; }
        //public DbSet<OrderModel> Orders { get; set; }
        //public DbSet<ReferralModel> Referrals { get; set; }

        // nueva base de datos

        public DbSet<ValueModel> Values { get; set; }
        public DbSet<ContactsModel> Contacts { get; set; }
        public DbSet<ErrorModel> Errors { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<StatusesModel> Statuses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            // Relación uno a muchos (ValueModel - ContactsModel)
            modelBuilder.Entity<ValueModel>()
                .HasMany(v => v.Contacts)
                .WithOne(c => c.Values)
                .HasForeignKey(c => c.ValueModelId);

            // Relación uno a muchos (ValueModel - StatusesModel)
            modelBuilder.Entity<ValueModel>()
                .HasMany(v => v.Statuses)
                .WithOne(s => s.Values)
                .HasForeignKey(s => s.ValueModelId);

            // Configura la relación uno a uno entre ContactsModel y StatusesModel
            modelBuilder.Entity<ContactsModel>()
                .HasOne(c => c.Statuses)
                .WithOne(s => s.Contacts)
                .HasForeignKey<ContactsModel>(c => c.StatusesModelId); // Configura la clave foránea


        }
    }
}
