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
