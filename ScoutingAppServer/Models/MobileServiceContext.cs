using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;
using FlipitServer.SQLDataObjects;
using flipyserverService.SQLDataObjects;
using System.Data.Entity.Validation;

namespace flipyserverService.Models
{
    public class MobileServiceContext : DbContext {

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public MobileServiceContext() : base(connectionStringName) {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public static MobileServiceContext Create() {
            return new MobileServiceContext();
        }

        public override int SaveChanges() {
            try {
                return base.SaveChanges();
            }catch(DbEntityValidationException err) {
                var errMess = err.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errMess);

                var exceptionMessage = string.Concat(err.Message, " the Validation Errors are: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, err.EntityValidationErrors);
            }
        }
    }

}
