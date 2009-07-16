using System.Data;

namespace FluentExamples.StoredProcExamples
{
    /// <summary>
    /// Interface for a StoredProc
    /// </summary>
    public interface IStoredProc
    {
        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="value">The value.</param>
        void AddParameter(string parameterName, DbType dbType, object value);

        /// <summary>
        /// Creates the stored procedure specified.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        void Create(string storedProcedureName);

        /// <summary>
        /// Executes the stored procedure and returns nothing.
        /// </summary>
        void Execute();

        /// <summary>
        /// Executes the stored procedure and returns the result as a dataset.
        /// </summary>
        /// <returns></returns>
        DataSet ExecuteAndReturnDataSet();

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        void SetTimeout(int timeout);
    }
}