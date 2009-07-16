using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace FluentExamples.StoredProcExamples
{
    /// <summary>
    /// Implements IStoredProcImplementation using Enterprise Library Data Block
    /// </summary>
    public class EntLibStoredProc : IStoredProc
    {
        private Database _db;
        private DbCommand _dbCommand;

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="value">The value.</param>
        public void AddParameter(string parameterName, DbType dbType, object value)
        {
            _db.AddInParameter(_dbCommand, parameterName, dbType, value);
        }

        /// <summary>
        /// Creates the stored procedure specified.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        public void Create(string storedProcedureName)
        {
            _db = DatabaseFactory.CreateDatabase();
            _dbCommand = _db.GetStoredProcCommand(storedProcedureName);
        }

        /// <summary>
        /// Executes the stored procedure and returns nothing.
        /// </summary>
        public void Execute()
        {
            if (_db == null || _dbCommand == null)
                return;

            _db.ExecuteNonQuery(_dbCommand);
        }

        /// <summary>
        /// Executes the stored procedure and returns the result as a dataset.
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteAndReturnDataSet()
        {
            if (_db == null || _dbCommand == null)
                return new DataSet();

            return _db.ExecuteDataSet(_dbCommand);
        }

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        public void SetTimeout(int timeout)
        {
            _dbCommand.CommandTimeout = timeout;
        }
    }
}