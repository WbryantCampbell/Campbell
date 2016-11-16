using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repositories
{
    public class ErrorLog
    {
        public ErrorLog()
        {

        }

        public void LogIt(DateTime date, string message)
        {
            var writeColums = false;

            var fileName = @"C:\_repos\bryant-campbell-individual-work\FlooringMastery\Data\ErrorLog\" +
                           date.ToString("yyyy-MM-dd");

            if (!File.Exists(fileName))
            {
                writeColums = true;
            }

            using (StreamWriter sw = File.AppendText(fileName))
            {
                if (writeColums)
                {
                    sw.WriteLine($"This is the error log for {date}. Below are the errors made that day");
                    sw.WriteLine("--------------------------------------------------------------------");
                }

                sw.WriteLine($"{message}");
                sw.WriteLine();
            }

        }
    }
}

