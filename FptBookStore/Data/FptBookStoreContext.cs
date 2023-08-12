using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FptBookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FptBookStore.Data
{
    public class FptBookStoreContext : IdentityDbContext<DefaultUser>
    {
        public FptBookStoreContext (DbContextOptions<FptBookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<CartItem> CartItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
    }
}
