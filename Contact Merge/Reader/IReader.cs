#region License & Terms
//    ContactMerge - Programming Exercise
//    Copyright (c) 2015 Todd Seymour.  

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.

//    A copy of the GNU General Public License is available with the software.
//    Otherwise, the license information can be found at <http://www.gnu.org/licenses/>.
#endregion

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
