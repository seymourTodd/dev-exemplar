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
using System.IO;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// The Mediator class provides a simple layer of abstraction between the console 
    /// application and the underlying merge functionality; reading, merging & writing
    /// </summary>
    public class Mediator
    {
        private Merger ListMerger = new Merger();
        private IReader SimulatedDataReader = new ReaderSimulated();
        private IReader JsonFileDataReader = new ReaderJsonFile();
        private IWriter JsonFileDataWriter = new WriterJsonFile();

        /// <summary>
        /// The ProcessMerge method does the following:
        /// 1. loads data from a file that contains contacts formatted in Json,
        /// 2. generates contacts from a simulated database via a "fake" framework, 
        /// 3. merges the two lists
        /// 4. outputs the merge results, in Json format, to a file 
        /// </summary>
        /// <returns></returns>
        public List<Contact> ProcessMerge()
        {
            List<Contact> ContactListOne = null;
            List<Contact> ContactListTwo = null;
            List<Contact> ResultsContactList = null;

            ContactListOne = JsonFileDataReader.Read();
            ContactListTwo = SimulatedDataReader.Read();

            ResultsContactList = ListMerger.Merge(ContactListOne, ContactListTwo);

            JsonFileDataWriter.Write(ResultsContactList);
            return (ResultsContactList);
        }
    }
}