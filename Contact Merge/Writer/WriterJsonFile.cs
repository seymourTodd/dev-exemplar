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