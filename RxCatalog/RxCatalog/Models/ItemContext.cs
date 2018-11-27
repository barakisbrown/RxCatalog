using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RxCatalog.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }

        public ItemContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connections = "Data Source = RxInventory.db";
            options.UseSqlite(connections);
        }

        public static void LoadData(string csvFileName)
        {
            using (var db = new ItemContext())
            {
                db.Database.EnsureCreated();
                // Lines will contain the csv file in memory
                string[] lines = System.IO.File.ReadAllLines(csvFileName);

                List<Item> Items = new List<Item>();
                foreach (var line in lines)
                {
                    string[] splitLine = line.Split(",");
                    // Need this to convert splitLine[9] to a boolean
                    var isInsured = (splitLine[9] == "YES");
                    // Need this to convert splitLine[8] to a decimal
                    var costRegex = new Regex(@"([\d,.]+)");
                    var match = costRegex.Match(splitLine[8]);
                    var costStr = match.Value;
                    // Begin parsing the string into the mapped object
                    var item = new Item()
                    {
                        Name = splitLine[0],
                        Type = splitLine[1],
                        Number = Int32.Parse(splitLine[2]),
                        Noc = splitLine[3],
                        Qty = Int16.Parse(splitLine[4]),
                        Days = Int16.Parse(splitLine[5]),
                        Refills = Int16.Parse(splitLine[6]),
                        RefillDate = DateTime.Parse(splitLine[7]),
                        Cost = decimal.Parse(costStr),
                        Insurance = isInsured,
                        Used = splitLine[10]
                    };
                    Items.Add(item);
                }

                // IMPORT INTO THE DATABASE HERE
                foreach (var item in Items)
                {
                    db.Items.Add(item);
                }
                // commit the changes
                db.SaveChanges();
            }
        }
        public DbSet<Item> Items { get; set; }
    }
}
