using RxCatalog.Models;
using System.Collections.Generic;
using System.Linq;

namespace RxCatalog.ViewModel
{
    public class ItemViewModel
    {
        private readonly decimal _avgCost;
        private readonly decimal _totalCost;
        private readonly int _totalCount;

        public List<Item> Items { get; set; }

        public ItemViewModel()
        {
            using (var db = new ItemContext())
            {
                db.Database.EnsureCreated();
                Items = db.Items.Where(w => w.Number != -1).ToList();                  
            }

            _totalCount = Items.Count;
            _totalCost = Items.Sum(s => s.Cost);
            _avgCost = Items.Average(s => s.Cost);
        }

        public decimal AVGCOST => _avgCost;
        public decimal TOTALCOST => _totalCost;
        public int TOTALCOUNT => _totalCount;
    }
}