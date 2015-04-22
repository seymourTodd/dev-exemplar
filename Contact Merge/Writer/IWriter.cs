using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// A standard interface for a data writer
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// The Write method needed as part of the contract
        /// </summary>
        /// <param name="data">A data object to write to the file</param>
        void Write(object data);
    }
}
