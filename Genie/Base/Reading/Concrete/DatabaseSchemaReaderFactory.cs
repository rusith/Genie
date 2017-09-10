using Genie.Base.Reading.Abstract;
using System.Globalization;

namespace Genie.Base.Reading.Concrete 
{
    internal class DatabaseSchemaReaderFactory : IDatabaseSchemaReaderFactory
    {
        public IDatabaseSchemaReader GetReader(string databaseManagementSystemName)
        {
            switch(databaseManagementSystemName.ToLower()) 
            {
                case "mssql":
                    return new SqlServerSchemaReader();
                case "mysql":
                    return new MySqlSchemaReader();
                default:
                    return null;
            }
        }
    }
}