using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using GitTFS_Migration.Service.Interfaces;

namespace GitTFS_Migration.Service.Classes
{
    public class FileReader : IFileReader
    {
        public DataTable ParseCSVToDataTable(string filePath, DataColumn[] dataColumns = null)
        {
            DataTable result = new DataTable();

            List<string[]> rows = File.ReadAllLines(filePath)
                .Select(x => x.Split(','))
                .ToList();

            if (dataColumns != null)
                result.Columns.AddRange(dataColumns);

            rows.ForEach(repository => result.Rows.Add(repository));

            return result;
        }
    }
}
