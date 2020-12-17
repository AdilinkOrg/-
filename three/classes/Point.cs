namespace three.classes {
    class Point {
        private char name;
        private double x;
        private double y;

        public char Name {
            get { return name; }
            set { name = value; }
        }
        public double X {
            get { return x; }
            set { x = value; }
        }
        public double Y {
            get { return y; }
            set { y = value; }
        }

        public Point() { }
        public Point(char _name) {
            name = _name;
        }
        public Point(char _name, double _x, double _y) {
            name = _name;
            x = _x;
            y = _y;
        }

        override public string ToString() {
            return "Point name: " + name + " x: " + x + " y: " + y;
        }
    }
}