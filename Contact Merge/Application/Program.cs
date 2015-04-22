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