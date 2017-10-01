namespace Chef.Store.DB
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using Resource;
    using Salad;

    internal class InitializationDB
    {
        private const int CountColomns = 5;
        private static SqlConnection connection;
        private static string connectionString;
        private static DataTable table = new DataTable();

        private static SqlDataAdapter dataAdpater;

        internal InitializationDB(string fileName, Salad salad)
        {
            var databaseName = Path.GetFileNameWithoutExtension(fileName);
            connectionString = string.Format(ConfigurationManager.ConnectionStrings["WorkWithDBFile"].ConnectionString, fileName);

            if (!File.Exists(fileName))
            {
                CreateDBAndTable(fileName, databaseName, connectionString);
            }

            InitializationDB.connection = new SqlConnection(connectionString);

            InitializationDB.dataAdpater = new SqlDataAdapter();
            InitializationDB.dataAdpater.InsertCommand = new SqlCommand("INSERT INTO Vegetables(VegetableID, Name, Color, Weight, Calories) VALUES(@VegetableID, @Name, @Color, @Weight, @Calories)", InitializationDB.connection);
            IndentifyParametrsCommand(InitializationDB.dataAdpater.InsertCommand);

            InitializationDB.dataAdpater.SelectCommand = new SqlCommand("SELECT * FROM [dbo].[Vegetables]", InitializationDB.connection);
            IndentifyParametrsCommand(InitializationDB.dataAdpater.SelectCommand);
        }

        internal static DataTable Table
        {
            get
            {
                return InitializationDB.table;
            }
        }

        internal static SqlDataAdapter DataAdpater
        {
            get
            {
                return InitializationDB.dataAdpater;
            }
        }

        internal static void Delete()
        {
            InitializationDB.CreateCommand($"DELETE FROM [dbo].[Vegetables]", connectionString);
        }

        internal static void SetPrimaryKey()
        {
            if (InitializationDB.table.PrimaryKey.Length == 0)
            {
                InitializationDB.table.PrimaryKey = InitializationDB.dataAdpater.FillSchema(InitializationDB.table, SchemaType.Source).PrimaryKey;
            }
        }

        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static DataColumn CreateColumn(string columnName, Type dataType, bool autoIncrement, string caption, bool readOnly, bool unique)
        {
            var column = new DataColumn(columnName, dataType);

            column.AutoIncrement = autoIncrement;
            column.Caption = caption;
            column.ReadOnly = readOnly;
            column.Unique = unique;

            return column;
        }

        private static void IndentifyParametrsCommand(SqlCommand operation)
        {
            operation.Parameters.Add("@VegetableID", SqlDbType.Int, 4, "VegetableID");
            operation.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            operation.Parameters.Add("@Color", SqlDbType.NVarChar, 50, "Color");
            operation.Parameters.Add("@Weight", SqlDbType.Int, 4, "Weight");
            operation.Parameters.Add("@Calories", SqlDbType.Int, 4, "Calories");

            // Otherwise exception.
            operation.Parameters["@VegetableID"].Value = 1;
            operation.Parameters["@Name"].Value = string.Empty;
            operation.Parameters["@Color"].Value = string.Empty;
            operation.Parameters["@Weight"].Value = 100;
            operation.Parameters["@Calories"].Value = 50;
        }

        private static void CreateDBAndTable(string fileName, string databaseName, string connectionStringToMDFFile)
        {
            var queryToCreateDB = string.Format("CREATE DATABASE {0} ON PRIMARY (NAME={0}, FILENAME='{1}')", databaseName, string.Format(Text.PathToDB, Environment.CurrentDirectory, fileName));

            var quertyToDetachDB = string.Format("EXEC sp_detach_db '{0}', 'true'", databaseName);

            var quertyToCreateTable = @"CREATE TABLE [dbo].[Vegetables]
                                       (
                                        [VegetableID] INT NOT NULL PRIMARY KEY,
                                        [Name] NVARCHAR(50) NOT NULL,
                                        [Color] NVARCHAR(50) NOT NULL,
                                        [Weight] INT NOT NULL, 
                                        [Calories]INT NOT NULL
                                       )";

            InitializationDB.CreateCommand(queryToCreateDB, ConfigurationManager.ConnectionStrings["CreateFileDB"].ConnectionString);
            InitializationDB.CreateCommand(quertyToDetachDB, ConfigurationManager.ConnectionStrings["CreateFileDB"].ConnectionString);
            InitializationDB.CreateCommand(quertyToCreateTable, connectionStringToMDFFile);
            InitializationDB.CreateTable();
        }

        private static void CreateTable()
        {
            DataColumn column;

            column = InitializationDB.CreateColumn("VegetableID", typeof(int), true, "VegetableID", true, true);
            InitializationDB.table.Columns.Add(column);

            column = InitializationDB.CreateColumn("Name", typeof(string), false, "Name", false, false);
            InitializationDB.table.Columns.Add(column);

            column = InitializationDB.CreateColumn("Color", typeof(string), false, "Color", false, false);
            InitializationDB.table.Columns.Add(column);

            column = InitializationDB.CreateColumn("Weight", typeof(int), false, "Weight", false, false);
            InitializationDB.table.Columns.Add(column);

            column = InitializationDB.CreateColumn("Calories", typeof(int), false, "Calories", false, false);
            InitializationDB.table.Columns.Add(column);

            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = InitializationDB.table.Columns["VegetableID"];
            InitializationDB.table.PrimaryKey = new DataColumn[1]
            {
                primaryKey[0]
            };
        }
    }
}