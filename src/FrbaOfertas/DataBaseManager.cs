using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace FrbaOfertas
{

    public class DataBaseManager
    {

        private SqlConnection _conn;
        string server = ConfigurationManager.AppSettings["server"].ToString();
        string user = ConfigurationManager.AppSettings["user"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string fecha = ConfigurationManager.AppSettings["fecha"].ToString();
        DateTime fechaAsDateTime;

        internal DateTime parse(string fecha)
        {
            return DateTime.Parse(fecha);
        }

        internal string initialize()
        {
            String uri = "data source=" + server + "; initial catalog=GD2C2019; user id=" + user + "; password=" + password + "; MultipleActiveResultSets=True";
            this._conn = new SqlConnection(uri);
            try
            {
                this._conn.Open();
                string val = intentarParsearFecha(fecha);
                if (!formatoFechaOk(fecha))
                {
                    return "La fecha configurada debe ser \"dd/mm/yyyy\".";
                }
                if (!"".Equals(val))
                { 
                    System.Console.Out.WriteLine(val);
                    return "La fecha configurada es invalida.";
                }
                fechaAsDateTime = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                System.Console.Out.WriteLine(e);
                return "¡Error en la conexión a Base de Datos!";
            }
            return "";
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

        internal int executeProcedure(String procedure)
        {
            SqlCommand command = new SqlCommand(procedure, _conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            return command.ExecuteNonQuery();
        }

        internal int executeProcedure(String procedure, Dictionary<string, object> map)
        {
            SqlCommand command = new SqlCommand(procedure, _conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var pair in map)
                {
                    string key = pair.Key;
                    object value = pair.Value;
                    command.Parameters.AddWithValue(key, value);
                }
            return command.ExecuteNonQuery();            
        }

        internal decimal executeSelectDecimal(String query)
        {
            SqlCommand command = new SqlCommand(query, _conn);            
           return  (Decimal)command.ExecuteScalar();             
        }

        internal decimal executeSelectDecimal(String query, Dictionary<string, object> map)
        {
            SqlCommand command = new SqlCommand(query, _conn);
            foreach (var pair in map)
            {
                string key = pair.Key;
                object value = pair.Value;
                command.Parameters.AddWithValue(key, value);
            }
            return (Decimal)command.ExecuteScalar();
        }

        internal int executeSelectInt(String query)
        {
            SqlCommand command = new SqlCommand(query, _conn);
            return (Int32)command.ExecuteScalar();
        }

        internal int executeSelectInt(String query, Dictionary<string, object> map)
        {
            SqlCommand command = new SqlCommand(query, _conn);
            foreach (var pair in map)
            {
                string key = pair.Key;
                object value = pair.Value;
                command.Parameters.AddWithValue(key, value);
            }
            return (Int32)command.ExecuteScalar();
        }

        internal string executeSelectString(String query)
        {
            SqlCommand command = new SqlCommand(query, _conn);
            return (String)command.ExecuteScalar();
        }

        internal string executeSelectString(String query, Dictionary<string, object> map)
        {
            SqlCommand command = new SqlCommand(query, _conn);
            foreach (var pair in map)
            {
                string key = pair.Key;
                object value = pair.Value;
                command.Parameters.AddWithValue(key, value);
            }
            return (String)command.ExecuteScalar();
        }

        internal DateTime getDatetimeFromResultSet(SqlDataReader resultSet, String nombreParametro)
        {
            return getDatetimeFromResultSet(resultSet, nombreParametro, new DateTime());
        }

        internal DateTime getDatetimeFromResultSet(SqlDataReader resultSet, String nombreParametro, DateTime defaultValue)
        {
            try
            {
                return (DateTime)resultSet.GetValue(resultSet.GetOrdinal(nombreParametro));
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }

        internal string intentarParsearFecha(string fecha)
        {
            try
            {
                fechaAsDateTime = DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "";
        }

        internal bool formatoFechaOk(string fecha)
        {
            if (fecha.Length != 10)
            {
                return false;
            }
            try
            {
                if ("/".Equals(fecha.Substring(2, 1)) && ("/".Equals(fecha.Substring(5, 1))))
                {
                    int dia = int.Parse(fecha.Substring(0, 2));
                    int mes = int.Parse(fecha.Substring(3, 2));
                    int anio = int.Parse(fecha.Substring(6, 4));
                    return true;
                }
            }
            catch (Exception e) { }
            return false;
        }
      
    }
}
