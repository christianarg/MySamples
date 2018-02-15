using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace EfPerformance
{
    class Program
    {
        const int totalRecords = 10000;

        static List<MyTable> listOfMyTables = new List<MyTable>();

        static void Main(string[] args)
        {
            for (int i = 0; i < totalRecords; i++)
            {
                listOfMyTables.Add(new MyTable { Text = RandomString(500) });
            }

            using (var context = new MyDbContext())
            {
                context.Database.ExecuteSqlCommand("truncate table mytables");
            }

            switch (args[0])
            {
                case "1":
                    ExecuteNewContextPerRecord();
                    break;
                case "2":
                    ExecuteReUseContextWithDefaultChangeDetection();
                    break;
                case "3":
                    ExecuteReUseContext();
                    break;
                case "4":
                    ReUseContextAddRange();
                    break;
                case "5":
                    ExecuteReUseContextWithBatches();
                    break;
                case "6":
                    ReUseContextAddRangeWithBatches();
                    break;
                case "7":
                    ExecuteNewContextPerBatch();
                    break;
                case "8":
                    ExecuteNewContextPerBatchWithAddRange();
                    break;
                case "9":
                    ExecuteNewContextPerRecordDisableChangeTracker();
                    break;
                default:
                    break;
            }
        }

        private static void ExecuteNewContextPerRecord()
        {
            ExecuteTest("NewContextPerRecord", () =>
            {
                foreach (var myTable in listOfMyTables)
                {
                    using (var dbContext = new MyDbContext())
                    {
                        AddMyTable(myTable, dbContext);
                        dbContext.SaveChanges();
                    }
                }
            });
        }

        private static void ExecuteNewContextPerRecordDisableChangeTracker()
        {
            ExecuteTest("ExecuteNewContextPerRecordDisableChangeTracker", () =>
            {
                foreach (var myTable in listOfMyTables)
                {
                    using (var dbContext = new MyDbContext())
                    {
                        dbContext.Configuration.AutoDetectChangesEnabled = false;
                        AddMyTable(myTable, dbContext);
                        dbContext.SaveChanges();
                    }
                }
            });
        }


        private static void ExecuteNewContextPerBatchWithAddRange()
        {
            ExecuteTest("ExecuteNewContextPerBatchWithAddRange", () =>
            {
                foreach (var myTableList in listOfMyTables.Batch(1000))
                {
                    using (var dbContext = new MyDbContext())
                    {
                        dbContext.Configuration.AutoDetectChangesEnabled = false;

                        dbContext.MyTable.AddRange(myTableList);

                        dbContext.SaveChanges();
                    }
                }
            });
        }

        private static void ExecuteNewContextPerBatch()
        {
            ExecuteTest("ExecuteNewContextPerBatch", () =>
            {
                foreach (var myTableList in listOfMyTables.Batch(1000))
                {
                    using (var dbContext = new MyDbContext())
                    {
                        dbContext.Configuration.AutoDetectChangesEnabled = false;

                        foreach (var myTable in myTableList)
                        {
                            AddMyTable(myTable, dbContext);
                        }

                        dbContext.SaveChanges();
                    }
                }
            });
        }

        private static void ExecuteReUseContext()
        {
            ExecuteTest("ReUseContext", () =>
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                    //dbContext.Configuration.ValidateOnSaveEnabled = false;

                    foreach (var myTable in listOfMyTables)
                    {
                        AddMyTable(myTable, dbContext);
                    }
                    dbContext.SaveChanges();
                }
            });
        }

        private static void ExecuteReUseContextWithDefaultChangeDetection()
        {
            ExecuteTest("ReUseContext", () =>
            {
                using (var dbContext = new MyDbContext())
                {
                    foreach (var myTable in listOfMyTables)
                    {
                        AddMyTable(myTable, dbContext);
                    }
                    dbContext.SaveChanges();
                }
            });
        }

        private static void ExecuteReUseContextWithBatches()
        {
            ExecuteTest("ExecuteReUseContextWithBatches", () =>
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                    //dbContext.Configuration.ValidateOnSaveEnabled = false;

                    foreach (var myTableList in listOfMyTables.Batch(1000))
                    {
                        foreach (var myTable in listOfMyTables)
                        {
                            AddMyTable(myTable, dbContext);
                        }
                    }
                    dbContext.SaveChanges();
                }
            });
        }

        private static void ReUseContextAddRange()
        {
            ExecuteTest("ReUseContextAddRange", () =>
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;

                    dbContext.MyTable.AddRange(listOfMyTables);

                    dbContext.SaveChanges();
                }
            });
        }


        private static void ReUseContextAddRangeWithBatches()
        {
            ExecuteTest("ReUseContextAddRangeWithBatches", () =>
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;

                    foreach (var myTableList in listOfMyTables.Batch(1000))
                    {
                        dbContext.MyTable.AddRange(myTableList);
                    }

                    dbContext.SaveChanges();
                }
            });
        }

        //private static void ReUseContextOptimized()
        //{
        //    ExecuteTest("ReUseContextOptimized", () =>
        //    {
        //        using (var dbContext = new MyDbContext())
        //        {
        //            dbContext.Configuration.AutoDetectChangesEnabled = false;
        //            dbContext.Configuration.ValidateOnSaveEnabled = false;
        //            for (int i = 0; i < totalRecords; i++)
        //            {
        //                AddMyTable(dbContext);
        //            }
        //            dbContext.SaveChanges();
        //        }
        //    });
        //}

        //private static void ExecuteReUseContext()
        //{
        //    ExecuteTest("ReUseContext", () =>
        //    {
        //        using (var dbContext = new MyDbContext())
        //        {
        //            for (int i = 0; i < totalRecords; i++)
        //            {
        //                AddMyTable(dbContext);
        //            }
        //            dbContext.SaveChanges();
        //        }
        //    });
        //}

        //private static void ExecuteNewContextPerRecord()
        //{
        //    ExecuteTest("NewContextPerRecord", () =>
        //    {
        //        for (int i = 0; i < totalRecords; i++)
        //        {
        //            using (var dbContext = new MyDbContext())
        //            {

        //                AddMyTable(dbContext);
        //                dbContext.SaveChanges();
        //            }
        //        }
        //    });
        //}


        private static void ExecuteTest(string name, Action action)
        {
            var stopWatch = Stopwatch.StartNew();

            action();

            stopWatch.Stop();
            File.AppendAllText($"{name}.log", $"{stopWatch.ElapsedMilliseconds}{Environment.NewLine}");
        }

        private static void AddMyTable(MyTable myTable, MyDbContext dbContext)
        {
            dbContext.MyTable.Add(myTable);
        }

        private static void AddMyTable(MyDbContext dbContext)
        {
            dbContext.MyTable.Add(new MyTable { Text = RandomString(500) });
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<MyTable> MyTable { get; set; }
    }

    public class MyTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
