using System.Data;
using System.Data.Common;
using System.Reflection;

namespace Tools.Database
{
    public static class DbConnectionExtensions
    {
        public static async Task<int> ExecuteNonQueryAsync(this DbConnection dbConnection, string sql, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand command = CreateCommand(dbConnection, sql, isStoredProcedure, parameters))
            {
                return await command.ExecuteNonQueryAsync();
            }
        }

        public static int ExecuteNonQuery(this DbConnection dbConnection, string sql, bool isStoredProcedure = false, object? parameters = null)
        {
            using(DbCommand command = CreateCommand(dbConnection, sql, isStoredProcedure, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        public static IEnumerable<TResult> ExecuteReader<TResult>(this DbConnection dbConnection, string sql, Func<IDataRecord, TResult> selector, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand command = CreateCommand(dbConnection, sql, isStoredProcedure, parameters))
            {
                using(DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yield return selector(reader);
                    }
                }
            }
        }

        public static async IAsyncEnumerable<TResult> ExecuteReaderAsync<TResult>(this DbConnection dbConnection, string sql, Func<IDataRecord, TResult> selector, bool isStoredProcedure = false, object? parameters = null)
        {
            using (DbCommand command = CreateCommand(dbConnection, sql, isStoredProcedure, parameters))
            {
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        yield return selector(reader);
                    }
                }
            }
        }

        private static DbCommand CreateCommand(DbConnection dbConnection, string sql, bool isStoredProcedure, object? parameters)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sql;

            if (isStoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;

            if (parameters is not null)
            {
                Type type = parameters.GetType();

                foreach (PropertyInfo propertyInfo in type.GetProperties().Where(p => p.CanRead))
                {
                    DbParameter dbParameter = dbCommand.CreateParameter();
                    dbParameter.ParameterName = propertyInfo.Name;
                    dbParameter.Value = propertyInfo.GetMethod!.Invoke(parameters, null) ?? DBNull.Value;

                    dbCommand.Parameters.Add(dbParameter);
                }
            }

            return dbCommand;
        }
    }
}
