using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleOdbc
{
    public class ToSqlServer
    {
        private string _connectionString;

        public ToSqlServer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertTableData<T>(List<T> coll, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    string propNames = "";
                    string propValues = "";
                    foreach (var i in coll)
                    {
                        try
                        {
                            foreach (var prop in i.GetType().GetProperties())
                            {
                                string propTypeName = prop.PropertyType.Name;
                                string val = prop.GetValue(i, null).ToString();

                                Console.WriteLine("Name:{0}\tValue:{1}\tType:{2}", prop.Name, val, propTypeName);

                                propNames = propNames + "[" + prop.Name + "]" + ", ";
                                if (propTypeName == "String")
                                { 
                                    val = val.Replace("'", "''");// double apostrophies or breaks SQL string.
                                    propValues = propValues + "'" + val + "', ";
                                }
                                else
                                {
                                    if (val == null )
                                    {
                                        val = "0";
                                    }
                                    propValues = propValues + val + ", ";
                                }
                            }

                            propNames = propNames.Substring(0, propNames.Length - 2); // remove at endofstr ", "
                            propValues = propValues.Substring(0, propValues.Length - 2); // remove at endofstr ", "


                            string insert = "INSERT INTO [MEUBLEX].[STAGINGSCHEMA].[" 
                                + tableName + "] ( " + propNames + " ) "
                                + " VALUES ( " + propValues + " ) ";

                            Console.WriteLine("\r\nSQL: {0}\r\n", insert);

                            command.CommandText = "SET ANSI_WARNINGS OFF";
                            command.ExecuteNonQuery();

                            command.CommandText = insert;
                            command.ExecuteNonQuery();

                            propNames = ""; // reset table column names for next insert
                            propValues = ""; // reset table column values for next insert
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("DoSQL()->Exception->" + ex.Message);
                            propNames = ""; // reset table column names for next insert
                            propValues = ""; // reset table column values for next insert
                        }
                    }
                }// using (OdbcCommand command = connection.CreateCommand())
            }// using (OdbcConnection connection = new OdbcConnection

        }

        public void InsertTableData2(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM " + tableName;
                    using (SqlDataReader DbReader = command.ExecuteReader())
                    {
                        int colCount = DbReader.FieldCount;
                        Console.WriteLine("Table:\t" + tableName + Environment.NewLine);

                        string columnName = "";
                        while (DbReader.Read())
                        {
                            for (int i = 0; i < colCount; i++)
                            {
                                try
                                {
                                    columnName = DbReader.GetName(i);
                                    var columnValue = DbReader.GetString(i);
                                    Console.WriteLine(columnName + ":\t" + columnValue);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(columnName + "->Exception->" + ex.Message);
                                }
                            }
                            Console.WriteLine();
                        }// while(DbReader.Read())
                    }// using ( OdbcDataReader DbReader = command.ExecuteReader() )
                }// using (OdbcCommand command = connection.CreateCommand())
            }// using (OdbcConnection connection = new OdbcConnection

        }

    }
}
