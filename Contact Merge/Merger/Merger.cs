using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// The Merger class contains an algorithm that will merge the contacts from two lists
    /// Contacts that appear to be same person should be merged and combined as a contact.   
    /// </summary>
    public class Merger : IMerger
    {
        /// <summary>
        /// The Merge method merges two Lists with a Union, using firstname and lastname
        ///  as the key value in the lookup and aggregating the content fields with a simple coalesce
        /// </summary>
        /// <param name="first">A list of objects to merge</param>
        /// <param name="second">Another list of object to merge</param>
        /// <returns>The resulting List of Contact object based on the union/lookup criteria</returns>
        public List<Contact> Merge(List<Contact> first, List<Contact> second)
        {
            List<Contact> MergedContactData = new List<Contact>();

            if (first == null || first.Count == 0)
            {
                MergedContactData = second;
            }
            else if (second == null || second.Count == 0)
            {
                MergedContactData = first;
            }
            else
            {
                // The Merge algorithm uses LINQ Union, Lookup and Aggregate methods:
                // The Union method produces the set union of two sequences using deferred execution.
                // The Lookup method groups items by a key, which allows access in an efficient manner.
                // The Aggregate method applies an accumulator value over a sequence calling a func.
                MergedContactData = first.Union(second).
                    ToLookup(x => new { x.FirstName, x.LastName }).
                    Select(x => new Contact()
                {
                    LastName = x.Key.LastName,
                    FirstName = x.Key.FirstName,
                    EmailAddress = x.Select(y => y.EmailAddress).Aggregate((a1, a2) => string.IsNullOrEmpty(a1) ? a2 : a1),
                    PhoneNumber = x.Select(y => y.PhoneNumber).Aggregate((a1, a2) => string.IsNullOrEmpty(a1) ? a2 : a1),
                    JobCompany = x.Select(y => y.JobCompany).Aggregate((a1, a2) => string.IsNullOrEmpty(a1) ? a2 : a1),
                    JobTitle = x.Select(y => y.JobTitle).Aggregate((a1, a2) => string.IsNullOrEmpty(a1) ? a2 : a1)
                }).ToList();
            }
            return (MergedContactData);
        }
    }
}