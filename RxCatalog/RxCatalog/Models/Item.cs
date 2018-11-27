using System;
namespace RxCatalog.Models
{
    public class Item
    {

        private string _name;
        private string _type;
        private int _number;
        private string _noc;
        private int _qty;
        private int _days;
        private int _refills;
        private DateTime _refillDate;
        private decimal _cost;
        private bool _insurance;
        private string _used;

        public int ItemId { get; set; }
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public int Number { get => _number; set => _number = value; }
        public string Noc { get => _noc; set => _noc = value; }
        public int Qty { get => _qty; set => _qty = value; }
        public int Days { get => _days; set => _days = value; }
        public int Refills { get => _refills; set => _refills = value; }
        public DateTime RefillDate { get => _refillDate; set => _refillDate = value; }
        public decimal Cost { get => _cost; set => _cost = value; }
        public bool Insurance { get => _insurance; set => _insurance = value; }
        public string Used { get => _used; set => _used = value; }
    }
}
