using ConsoleOdbc.Models;
using System;
using System.Collections.Generic;
using System.Data.Odbc; // PhD: Required for ODBC connectivity.
using System.Globalization;
using System.Reflection;

namespace ConsoleOdbc
{
    public class OdbcMeublex : IDisposable
    {
        private string _dsnName;
        private ToSqlServer _toSqlServer;

        public OdbcMeublex(string dsnName, ToSqlServer toSqlServer)
        {
            _dsnName = dsnName;
            _toSqlServer = toSqlServer;
        }

        public void UpdateTable(string tableName, string setCriteria, string whereCriteria)
        {
            using (OdbcConnection connection = new OdbcConnection(_dsnName))
            {
                connection.Open();
                using (OdbcCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "UPDATE " + tableName +
                                              " SET " + setCriteria + " WHERE " + whereCriteria + "  ";

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("UpdateTable()->Exception->" + ex.Message);
                    }
                }// using (OdbcCommand command = connection.CreateCommand())
            }// using (OdbcConnection connection = new OdbcConnection

        }

        public void DeleteFromTable(string tableName, string whereClause)
        {
            using (OdbcConnection connection = new OdbcConnection(_dsnName))
            {
                connection.Open();
                using (OdbcCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "DELETE FROM " + tableName +
                                              " WHERE " + whereClause + "  ";

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DeleteFromTable()->Exception->" + ex.Message);
                    }
                }// using (OdbcCommand command = connection.CreateCommand())
            }// using (OdbcConnection connection = new OdbcConnection

        }


        public void InsertIntoTable(string tableName, string columnsNames, string columnValues)
        {
            using (OdbcConnection connection = new OdbcConnection(_dsnName))
            {
                connection.Open();
                using (OdbcCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "INSERT INTO " + tableName +
                                              " ( " + columnsNames + " ) " +
                                              " VALUES ( " + columnValues + " ) ";

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("InsertIntoTable()->Exception->" + ex.Message);
                    }
                }// using (OdbcCommand command = connection.CreateCommand())
            }// using (OdbcConnection connection = new OdbcConnection

        }



        public void DoGetDbData(string tableName)
        {
            using (OdbcConnection connection = new OdbcConnection(_dsnName))
            {
                connection.Open();
                using (OdbcCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM " + tableName;
                    using (OdbcDataReader DbReader = command.ExecuteReader())
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

        public void GetMeublexData(string tableName)
        {
            using (OdbcConnection connection = new OdbcConnection(_dsnName))
            {
                connection.Open();
                using (OdbcCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM " + tableName;
                    using (OdbcDataReader DbReader = command.ExecuteReader())
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

        }//GetMeublexData


        public void GetMeublexDbData<T>(string tableName)
        {
            List<T> retval = null;
            using (OdbcConnection odbcConnection = new OdbcConnection(_dsnName))
            {
                odbcConnection.Open();
                using (OdbcCommand odbcCommand = odbcConnection.CreateCommand())
                {
                    if (!Enum.IsDefined(typeof(eTables), tableName))
                    {
                        return;//false
                    }
                    if (!Enum.TryParse<eTables>(tableName, out var eTable))
                    {
                        return;//"Unknown enum eGetCode"
                    }
                    odbcCommand.CommandText = "SELECT TOP 10000 * FROM " + eTable.ToString();
                    using (OdbcDataReader odbcReader = odbcCommand.ExecuteReader())
                    {
                        retval = DoReader<T>(odbcReader);
                    }
                }
            }//using (OdbcConnection
            Console.WriteLine("DoSql() Processed Table: " + tableName);

            _toSqlServer.InsertTableData<T>(retval, tableName);

        }//GetMeublexDbData()



        public IList<T> GenericGetMeublexDbData<T>(string tableName)
        {
            IList<T> retval = null;
            using (OdbcConnection odbcConnection = new OdbcConnection(_dsnName))
            {
                odbcConnection.Open();
                using (OdbcCommand odbcCommand = odbcConnection.CreateCommand())
                {
                    if (!Enum.IsDefined(typeof(eTables), tableName))
                    {
                        return retval;//false
                    }
                    if (!Enum.TryParse<eTables>(tableName, out var eTable))
                    {
                        return retval;//"Unknown enum eGetCode"
                    }

                    odbcCommand.CommandText = "SELECT TOP 10000 * FROM " + eTable.ToString();
                    using (OdbcDataReader odbcReader = odbcCommand.ExecuteReader())
                    {
                        switch (eTable)
                        {
                            case eTables.CATEGORIE:
                                var retca = DoReader<CATEGORIE>(odbcReader);
                                //_toSqlServer.DoSql<Categorie>(retca, nameof(Categorie));
                                retval = retca as IList<T>;
                                break;
                            case eTables.CD_ACTIVITE:
                                var reta = DoReader<CD_ACTIVITE>(odbcReader);
                                //_toSqlServer.DoSql<CdActivite>(reta, nameof(CdActivite));
                                retval = reta as IList<T>;
                                break;
                            case eTables.CD_FINI:
                                var retf = DoReader<CD_FINI>(odbcReader);
                                //_toSqlServer.DoSql<CdFini>(retf, nameof(CdFini));
                                retval = retf as IList<T>;
                                break;
                            case eTables.CD_MODELE:
                                var retm = DoReader<CD_MODELE>(odbcReader);
                                retval = retm as IList<T>;
                                break;
                            case eTables.CD_SERVICE:
                                var rets = DoReader<CD_SERVICE>(odbcReader);
                                break;
                            case eTables.CLIENT:
                                var retcl = DoReader<CLIENT>(odbcReader);
                                break;
                            case eTables.DEPARTEMENT:
                                var retdp = DoReader<DEPARTEMENT>(odbcReader);
                                break;
                            case eTables.DIVISION:
                                var retdv = DoReader<DIVISION>(odbcReader);
                                break;
                            case eTables.FOURNISSEUR:
                                var retfr = DoReader<FOURNISSEUR>(odbcReader);
                                break;
                            case eTables.HISTORIQUE_VENTE:
                                var rethv = DoReader<HISTORIQUE_VENTE>(odbcReader);
                                break;
                            //case eTables.HISTORIQUE_VENTE_PAR_MOIS:
                            //    var rethvpm = DoReader<HISTORIQUEVENTEPARMOIS>(odbcReader);
                            //    break;
                            case eTables.HISTORIQUE_VENTE_SERVICE:
                                var rethvs = DoReader<HISTORIQUE_VENTE_SERVICE>(odbcReader);
                                break;
                            case eTables.MAGASIN:
                                var retmg = DoReader<MAGASIN>(odbcReader);
                                break;
                            case eTables.PUBLICITE:
                                var retpb = DoReader<PUBLICITE>(odbcReader);
                                break;
                            case eTables.REGION:
                                var retrg = DoReader<REGION>(odbcReader);
                                break;
                            case eTables.TERME_PAIEMENT:
                                var rettp = DoReader<TERME_PAIEMENT>(odbcReader);
                                break;
                            case eTables.VENDEUR:
                                var retvd = DoReader<VENDEUR>(odbcReader);
                                break;
                            default:
                                Console.WriteLine("DoSql() Unknown Table: " + tableName);
                                break;
                        }//switch (eTable)
                    }//using (OdbcDataReader
                }//using (OdbcCommand odbcCommand
            }//using (OdbcConnection
            Console.WriteLine("DoSql() Processed Table: " + tableName);
            return retval;
        }//GenericGetMeublexDbData()




        private List<T> DoReader<T>(OdbcDataReader odbcReader)
        {
            var retval = new List<T>();

            try
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                int columnCount = odbcReader.FieldCount;
                string columnName = "";
                while (odbcReader.Read())
                {
                    var iter = Activator.CreateInstance(typeof(T));

                    for (int i = 0; i < columnCount; i++)
                    {
                        try
                        {
                            if (odbcReader.IsDBNull(i))
                                continue;

                            var rawColumnName = odbcReader.GetName(i);

                            //columnName = textInfo.ToTitleCase(rawColumnName.ToLower());
                            //columnName = columnName.Replace("_", "");
                            //columnName = columnName.Replace("\0", "");

                            columnName = rawColumnName.Replace("\0", "");

                            var columnValue = odbcReader.GetValue(i);
                            var prop = iter.GetType().GetProperty(columnName);
                            if (prop != null)
                            {
                                prop.SetValue(iter, columnValue);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(columnName + "->Exception->" + ex.Message);
                        }
                    }
                    retval.Add((T)iter);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return retval;
        }

        private bool PropertyExists<T>(T clsObject, string columnName)
        {
            bool retval = false;
            PropertyInfo[] properties = clsObject.GetType().GetProperties();//typeof(T).GetProperties();
            foreach (var info in properties)
            {
                // if a string and null, set to String.Empty
                if (info.PropertyType == typeof(string) && info.GetValue(clsObject, null) == null)
                {
                    info.SetValue(clsObject, String.Empty, null);
                    // or set some boolean etc since you know the property at this point is of type string
                }
            }
            return retval;
        }



        /*

        ****************
        ****************
        ****************
        *Dispose Below**
        ****************
        ****************
        ****************

        */

        // IDisposable Implementation Begin
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (_odbcConnection != null)
                //{
                //    _odbcConnection.Dispose();
                //    _odbcConnection = null;
                //}
            }
        }
        // IDisposable Implementation End




    }
}
