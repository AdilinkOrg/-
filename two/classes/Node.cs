using two.interfaces;

namespace two.classes {
    class Node<T>:Device<T>, ISpecifications {
        private string purpose;
        private int minWorkCelsiusTemperature = 20;
        private int maxWorkCelsiusTemperature = 100;

        virtual public string Purpose {
            get { return purpose; }
            set { purpose = value; }
        }
        virtual public int MinWorkCelsiusTemperature {
            get { return minWorkCelsiusTemperature; }
            set { minWorkCelsiusTemperature = value; }
        }
        virtual public int MaxWorkCelsiusTemperature {
            get { return maxWorkCelsiusTemperature; }
            set { maxWorkCelsiusTemperature = value; }
        }

        public Node() { }
        public Node(string _purpose) {
            purpose = _purpose;
        }
        public Node(string _purpose, string _name) {
            purpose = _purpose;
            Name = _name;
        }
        public Node(string _purpose, string _name, string _code) {
            purpose = _purpose;
            Name = _name;
            Code = _code;
        }

        override public string ToString() {
            return "Node name: " + Name + " Code: " + Code + " Purpose: " + purpose;
        }
        int ISpecifications.AvgValue() {
            return minWorkCelsiusTemperature + maxWorkCelsiusTemperature / 2;
        }
    }
}
