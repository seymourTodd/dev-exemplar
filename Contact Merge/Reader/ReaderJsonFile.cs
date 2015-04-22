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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// The ReaderJsonFile class uses the Newtonsoft Json Nuget package to deserialize data
    /// </summary>
    public class ReaderJsonFile : IReader
    {
        /// <summary>
        /// The Read method opens a file, reads the contents and deserializes
        /// the Json format into a list of Contact objects.
        /// </summary>
        public List<Contact> Read()
        {
            //The path of file containing the serialized data to load
            string filePath = @"..\..\..\Data\ContactDataInput.txt";
            List<Contact> TestContactData = null;
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                TestContactData = JsonConvert.DeserializeObject<List<Contact>>(json);
            }
            return (TestContactData);
        }

    }
}
