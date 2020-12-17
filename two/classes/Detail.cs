using two.interfaces;

namespace two.classes {
    class Detail:Mechanism<Detail> {
        private string task;

        virtual public string Task {
            get { return task; }
            set { task = value; }
        }

        public Detail() { }
        public Detail(string _task) {
            task = _task;
        }
        public Detail(string _task, string _name) {
            task = _task;
            Name = _name;
        }
        public Detail(string _task, string _name, string _code) {
            task = _task;
            Name = _name;
            Code = _code;
        }

        override public string ToString() {
            return "\t\t\tDetail name: " + Name + " Code: " + Code + " Task: " + task;
        }


    }
}
