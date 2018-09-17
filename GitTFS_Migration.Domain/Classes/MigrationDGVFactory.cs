using GitTFS_Migration.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace GitTFS_Migration.Domain.Classes
{
    public class MigrationDGVFactory : IMigrationDGVFactory
    {
        public DataColumn[] GenerateMigrationHeaderRow()
        {
            return new List<DataColumn>
            {
                new DataColumn("Branch Name"),
                new DataColumn("Old TFS Repository"),
                new DataColumn("TFS Valid", typeof(bool)),
                new DataColumn("New Git Repository"),
                new DataColumn("Git Valid", typeof(bool))
            }
            .ToArray();
        }
    }
}
