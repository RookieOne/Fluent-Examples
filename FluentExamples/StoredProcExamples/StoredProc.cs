using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FluentExamples.StoredProcExamples
{
    /// <summary>
    /// Facade helper class for calling Stored Procedures
    /// </summary>
    public class StoredProc
    {
        private static IStoredProc _storedProc;
        private readonly List<IStoredProcParameter> _inParameters;
        private readonly List<IStoredProcParameter> _outParameters;
        private readonly string _storedProcedureName;
        private int? _timeOut;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProc"/> class.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        private StoredProc(string storedProcedureName)
        {
            _storedProcedureName = storedProcedureName;
            _inParameters = new List<IStoredProcParameter>();
            _outParameters = new List<IStoredProcParameter>();
        }

        /// <summary>
        /// Adds the out param.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public StoredProc AddOutParam<T>(string parameterName, int size)
        {
            StoredProcParameter<T> parameter = new StoredProcParameter<T>(parameterName, size);

            _outParameters.Add(parameter);

            return this;
        }

        /// <summary>
        /// Adds the param to the parameter collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns></returns>
        public StoredProc AddParam<T>(string parameterName, T parameterValue)
        {
            StoredProcParameter<T> parameter = new StoredProcParameter<T>(parameterName, parameterValue);

            _inParameters.Add(parameter);

            return this;
        }

        /// <summary>
        /// Executes the stored procedure.
        /// </summary>
        /// <returns></returns>
        public StoredProc Execute()
        {
            try
            {
                SetupStoredProc();

                _storedProc.Execute();
            }
            catch (Exception ex)
            {
                // handle exception
                throw;
            }

            return this;
        }

        /// <summary>
        /// Executes the stored proc and returns a data set.
        /// </summary>
        /// <returns></returns>
        public DataSet ExecuteAndReturnDataSet()
        {
            DataSet ds;
            try
            {
                SetupStoredProc();

                ds = _storedProc.ExecuteAndReturnDataSet();
            }
            catch (Exception ex)
            {
                // handle exception
                throw;
            }

            return ds;
        }

        /// <summary>
        /// Sets the stored proc implementation to use with facades
        /// </summary>
        /// <param name="storedProc">The stored proc implementation.</param>
        public static void SetStoredProcImplementation(IStoredProc storedProc)
        {
            _storedProc = storedProc;
        }

        /// <summary>
        /// Sets the timeout.
        /// </summary>
        /// <param name="timeOut">The time out.</param>
        /// <returns></returns>
        public StoredProc SetTimeout(int timeOut)
        {
            _timeOut = timeOut;
            return this;
        }

        /// <summary>
        /// Creates and adds parameters to the stored proc implentation.
        /// </summary>
        private void SetupStoredProc()
        {
            _storedProc.Create(_storedProcedureName);

            if (_timeOut != null)
                _storedProc.SetTimeout(_timeOut ?? 0);

            foreach (IStoredProcParameter parameter in _inParameters)
            {
                _storedProc.AddParameter(parameter.ParameterName, parameter.DbType, parameter.Value);
            }
        }

        /// <summary>
        /// Factory method for a StoredProc facade
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <returns></returns>
        public static StoredProc Using(string storedProcedureName)
        {
            return new StoredProc(storedProcedureName);
        }
    }
}
