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