using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaOfertas
{

    public class DataBaseManager
    {

        private SqlConnection _conn;

        internal bool initialize()
        {
            String uri = "data source=.\\SQLSERVER2012; initial catalog=GD2C2019; user id=gdCupon2019; password=gd2019; MultipleActiveResultSets=True";
            this._conn = new SqlConnection(uri);
            try
            {
                this._conn.Open();
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine(e);
                return false;
            }
            return true;
        }

        internal SqlDataReader executeSelect(String query)
        {
            SqlCommand comando = this._conn.CreateCommand();
            comando.CommandText = query;
            try
            {
                return comando.ExecuteReader();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        internal SqlDataReader executeSelect(string query, Dictionary<string, string> map)
        {
            SqlCommand comando = new SqlCommand(query, _conn);
            try
            {
                foreach (var pair in map)
                {
                    string key = pair.Key;
                    string value = pair.Value;
                    comando.Parameters.AddWithValue(key, value);
                }
                return comando.ExecuteReader();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        internal Object getFromResultSet(SqlDataReader resultSet, String nombreParametro)
        {
            return getFromResultSet(resultSet, nombreParametro, null);
        }

        internal Object getFromResultSet(SqlDataReader resultSet, String nombreParametro, Object defaultValue)
        {
            try
            {
                return resultSet.GetValue(resultSet.GetOrdinal(nombreParametro));
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }

        internal String getStringFromResultSet(SqlDataReader resultSet, String nombreParametro)
        {
            return getStringFromResultSet(resultSet, nombreParametro, "");
        }

        internal String getStringFromResultSet(SqlDataReader resultSet, String nombreParametro, String defaultValue)
        {
            try
            {
                return  (String)resultSet.GetValue(resultSet.GetOrdinal(nombreParametro));
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }

        internal int getIntFromResultSet(SqlDataReader resultSet, String nombreParametro)
        {
            return getIntFromResultSet(resultSet, nombreParametro, -1);
        }

        internal int getIntFromResultSet(SqlDataReader resultSet, String nombreParametro, int defaultValue)
        {
            try
            {
                return (int)resultSet.GetValue(resultSet.GetOrdinal(nombreParametro));
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }

        internal Decimal getNumericFromResultSet(SqlDataReader resultSet, String nombreParametro)
        {
            return getNumericFromResultSet(resultSet, nombreParametro, Decimal.MinusOne);
        }

        internal Decimal getNumericFromResultSet(SqlDataReader resultSet, String nombreParametro, Decimal defaultValue)
        {
            try
            {
                return (Decimal)resultSet.GetValue(resultSet.GetOrdinal(nombreParametro));
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }

        internal int executeUpdate(string query, Dictionary<string, object> map)
        {
            SqlCommand comando = new SqlCommand(query, _conn);
            foreach (var pair in map)
            {
                string key = pair.Key;
                object value = pair.Value;
                comando.Parameters.AddWithValue(key, value);
            }
            try
            {
                return comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        internal List<int> executeUpdate(List<string> queries, List<Dictionary<string, object>> maps)
        {
            if (queries.Count != maps.Count)
            {
                return null;
            }
            SqlCommand command = _conn.CreateCommand();
            SqlTransaction transaction = _conn.BeginTransaction("OneTransaction");
            command.Transaction = transaction;
            List<int> results = new List<int>();
            try
            {
                for (int i = 0; i < queries.Count; i++)
                {
                    command.CommandText = queries[i];
                    foreach (var pair in maps[i])
                    {
                        string key = pair.Key;
                        object value = pair.Value;
                        command.Parameters.AddWithValue(key, value);
                    }
                    results.Add(command.ExecuteNonQuery());
                }
                transaction.Commit();
                return results;
            }
            catch (Exception ex)
            {
                transaction.Rollback(); //si aca lanza excepcion falla el rollback
                int resSize = results.Count;
                results.Clear();
                results.Add(resSize);
                return results;
            }

        }

        //con transaccion:

        internal SqlTransaction getTransaction()
        {
            return _conn.BeginTransaction();
        }
        internal void commitTransaction(SqlTransaction tran)
        {
            tran.Commit();
        }
        internal int executeUpdate(SqlTransaction transaction, bool commitNow, String query, Dictionary<string, object> map)
        {
            SqlCommand command = _conn.CreateCommand();
            command.Transaction = transaction;
            try
            {
                command.CommandText = query;
                foreach (var pair in map)
                {
                    string key = pair.Key;
                    object value = pair.Value;
                    command.Parameters.AddWithValue(key, value);
                }
                if(commitNow)
                {
                    transaction.Commit();
                }
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                transaction.Rollback(); //si aca lanza excepcion falla el rollback
                return -1;
            }

        }

    }
}
