using System.Data.Entity;

namespace SamplesTestProyect.Concurrency
{
    public class Content
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("name=DefaultConnection"){}
        public DbSet<Content> Contents { get; set; }
    }
}
