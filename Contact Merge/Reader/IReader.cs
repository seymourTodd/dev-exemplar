using System.Collections.Generic;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// A standard interface for a data reader
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// The read method needed as part of the contract
        /// </summary>
        /// <returns>A list of contact objects</returns>
        List<Contact> Read();
    }
}
