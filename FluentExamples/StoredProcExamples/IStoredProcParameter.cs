using System.Data;

namespace FluentExamples.StoredProcExamples
{
    /// <summary>
    /// Interface for Stored Procedure Parameter
    /// </summary>
    public interface IStoredProcParameter
    {
        /// <summary>
        /// Gets the Db Type.
        /// </summary>
        /// <value>The type of the db.</value>
        DbType DbType { get; }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        string ParameterName { get; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        int Size { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        object Value { get; }
    }
}