using eService.Data.Contracts;

namespace eService.Data
{
    public class SaveContext : ISaveContext
    {
        private readonly MsSqlContext context;

        public SaveContext(MsSqlContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
