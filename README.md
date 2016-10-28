# bulkinsert-test
A repository for testing Bulk Inserts

This is a small console application that shows how you can configure the [EntityFramework.BulkInsert](https://efbulkinsert.codeplex.com/) extension to accept SqlBulkCopy options. 

Here's the key component:

```C#
using (var dataContext = new LogsContext())
{
    Console.Write("Let's bulk insert text.");
    var logList = new List<Log>();
    logList.Add(new Log { Text = "bulk inserted again" });
    logList.Add(new Log { Text = "bulk inserted again" });

    var options = new BulkInsertOptions();
    options.SqlBulkCopyOptions = System.Data.SqlClient.SqlBulkCopyOptions.FireTriggers;

    dataContext.BulkInsert(logList, options);
    dataContext.SaveChanges();
 }
```
