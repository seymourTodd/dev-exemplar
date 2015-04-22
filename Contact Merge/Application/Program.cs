using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ContactMerge.Exercise
{
    /// <summary>
    /// The ContactMerge exercise uses a console type application to execute
    /// the contact reading / merging / writing code running on a separate
    /// separate thread and doesn’t exit until the output file is written.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mediator MergeMediator = new Mediator();
            try
            {
                //A Task is used to run the reading, merging and writing on a seperate thread
                var MergeTask = new Task<List<Contact>>(() => MergeMediator.ProcessMerge());
                MergeTask.Start();
                //The console application does not exit until the merge process is complete
                MergeTask.Wait();
                Console.WriteLine("The merge completed.");
            }
            catch (AggregateException ae)
            {
                // Exceptions thrown by tasks are returned as AggregateExceptions, therefore,
                // we need to examine the InnerExceptions and handle as approapriate for our app.
                ae.Handle((x) =>
                {
                    if (x is FileNotFoundException)
                    {
                        Console.WriteLine("The input file could not be found.");
                        return true;
                    }
                    return false;
                });
            }
        }
    }
}