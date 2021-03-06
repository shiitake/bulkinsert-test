namespace BulkInsert
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogsContext : DbContext
    {
        public LogsContext()
            : base("name=LogsContext")
        {
        }        
        public virtual DbSet<Log> Logs { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
        }
    }
}
