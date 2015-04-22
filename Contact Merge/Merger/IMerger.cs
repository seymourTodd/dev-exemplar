using System.Collections.Generic;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// A standard interface for merging
    /// </summary>
    public interface IMerger
    {
        /// <summary>
        /// The Merge method needed for the standard interface
        /// </summary>
        /// <param name="first">A list of objects to merge</param>
        /// <param name="second">Another list of object to merge</param>
        /// <returns>The resulting List of Contact object</returns>
        List<Contact> Merge(List<Contact> first, List<Contact> second);
    }
}