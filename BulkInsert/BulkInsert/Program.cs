using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.BulkInsert.Extensions;
using System.Data.Sql;

namespace BulkInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dataContext = new LogsContext())
            {
                Console.Write("Let's bulk insert text.");
                var logList = new List<Log>();
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                logList.Add(new Log { Text = "bulk inserted again" });
                var options = new BulkInsertOptions();
                options.SqlBulkCopyOptions = System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers;
                
                dataContext.BulkInsert(logList, options);
                dataContext.SaveChanges();

                var query = from l in dataContext.Logs
                            orderby l.Id
                            select l;

                Console.WriteLine("Here's all the stuff from Log:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Id + "\t" + item.Text);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
