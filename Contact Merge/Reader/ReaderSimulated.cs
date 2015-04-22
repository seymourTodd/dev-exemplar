using System.Collections.Generic;
using System.Linq;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// The ReaderSimulated class utilizes the Faker.Net Nuget package
    /// to simulate contact data that might be retrieved from a database
    /// </summary>
    public class ReaderSimulated : IReader
    {
        /// <summary>
        /// Instance variable used to hold simulated contact data
        /// </summary>
        private List<Contact> ContactData;

        /// <summary>
        /// Class constructor initializes simulated data
        /// </summary>
        /// <param name="numberOfFakeRecords">Optional number of records to generate</param>
        public ReaderSimulated(int numberOfFakeRecords = 10)
        {
            InitializeData(numberOfFakeRecords);
        }

        /// <summary>
        /// The InitializeData method generates simulated data and stores in an instance variable
        /// </summary>
        /// <param name="numberOfFakeRecords">The number of records to generate</param>
        private void InitializeData(int numberOfFakeRecords)
        {
            if (ContactData == null)
            {
                ContactData = new List<Contact>();
                for (int i = 0; i < numberOfFakeRecords; i++)
                {
                    ContactData.Add(new Contact()
                    {
                        FirstName = Faker.Name.First(),
                        LastName = Faker.Name.Last(),
                        EmailAddress = Faker.Internet.Email(),
                        PhoneNumber = Faker.Phone.Number(),
                        JobCompany = Faker.Company.Name()
                    });
                }
            }
        }

        /// <summary>
        /// The Read method dictated by the IReader interface
        /// </summary>
        /// <returns>A simulated list of contact objects</returns>
        public List<Contact> Read()
        {
            return (ContactData);
        }
    }
}