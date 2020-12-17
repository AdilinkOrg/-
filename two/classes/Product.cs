using System;
using two.interfaces;

namespace two.classes {
    class Product<T>:Node<T>, ISpecifications, IPrices {
        private DateTime validUntil;
        private int minCost = 10;
        private int maxCost = 20;

        virtual public DateTime ValidUntil {
            get { return validUntil; }
            set { validUntil = value; }
        }
        virtual public int MinCost {
            get { return minCost; }
            set { minCost = value; }
        }
        virtual public int MaxCost {
            get { return maxCost; }
            set { maxCost = value; }
        }

        public Product() { }
        public Product(DateTime _validUntil) {
            validUntil = _validUntil;
        }
        public Product(DateTime _validUntil, string _name) {
            validUntil = _validUntil;
            Name = _name;
        }
        public Product(DateTime _validUntil, string _name, string _code) {
            validUntil = _validUntil;
            Name = _name;
            Code = _code;
        }

        override public string ToString() {
            return "\tProduct name: " + Name + " Code: " + Code + " ValidUntil: " + validUntil.ToString();
        }

        int IPrices.AvgValue() {
            return minCost + maxCost / 2;
        }
    }
}
