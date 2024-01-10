using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SignalRDemo;

public class ChatContext(DbContextOptions<ChatContext> options) : DbContext(options)
{
    public DbSet<Chat> Chats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
