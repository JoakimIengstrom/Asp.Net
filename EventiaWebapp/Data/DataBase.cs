using EventiaWebapp.Services.Data;

namespace EventiaWebapp.Data
{
    public class DataBase
    {
        private EventiaDbContext ctx;

        public DataBase(EventiaDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void PrepDatabase()
        {
            using var ctx = new EventiaDbContext();

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.Seed();

        }
    }
}
