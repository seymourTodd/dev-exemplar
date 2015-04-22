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
using System.IO;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// The WriterJsonFile class uses the Newtonsoft Json Nuget package to serialize data
    /// </summary>
    public class WriterJsonFile : IWriter
    {
        /// <summary>
        /// The Write method deserializes data and saves to an output file
        /// </summary>
        /// <param name="dataToSave">An object containing the data to be serialized and saved</param>
        public void Write(object dataToSave)
        {
            string filePath = @"..\..\..\Data\ContactDataOutput.txt";

            // Use Newtonsoft Json Nuget package to serialize data
            string SerializedJsonData = JsonConvert.SerializeObject(dataToSave);

            File.WriteAllText(filePath, SerializedJsonData);
        }
    }
}