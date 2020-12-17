using two.interfaces;

namespace two.classes {
    class Mechanism<T>:Product<T> {
        private string significance;

        virtual public string Significance {
            get { return significance; }
            set { significance = value; }
        }

        public Mechanism() { }
        public Mechanism(string _significance) {
            significance = _significance;
        }
        public Mechanism(string _significance, string _name) {
            significance = _significance;
            Name = _name;
        }
        public Mechanism(string _significance, string _name, string _code) {
            significance = _significance;
            Name = _name;
            Code = _code;
        }

        override public string ToString() {
            return "\t\tMechanism name: " + Name + " Code: " + Code + " Significance: " + significance;
        }
    }
}
