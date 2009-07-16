using System;
using System.Data;

namespace FluentExamples.StoredProcExamples
{
    /// <summary>
    /// Implements IStoredProcedureParameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StoredProcParameter<T> : IStoredProcParameter
    {
        private readonly string _parameterName;
        private readonly T _parameterValue;
        private readonly int _size;
        private DbType _dbType;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcParameter&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        public StoredProcParameter(string parameterName,
                                   T parameterValue)
        {
            _parameterName = parameterName;
            _parameterValue = parameterValue;

            InferDbType();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcParameter&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="size">The size.</param>
        public StoredProcParameter(string parameterName, int size)
        {
            _parameterName = parameterName;
            _size = size;

            InferDbType();
        }

        /// <summary>
        /// Gets the Db Type.
        /// </summary>
        /// <value>The type of the db.</value>
        public DbType DbType
        {
            get { return _dbType; }
        }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        public string ParameterName
        {
            get { return _parameterName; }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value
        {
            get { return _parameterValue; }
        }

        /// <summary>
        /// Infers the Db Type from the Generic Type.
        /// </summary>
        /// <param name="t">The t.</param>
        private void InferDbType()
        {
            Type t = typeof (T);

            if (t == typeof (string))
                _dbType = DbType.String;

            if (t == typeof (int))
                _dbType = DbType.Int32;
        }
    }
}