using System;
using System.Collections.Generic;

namespace three.classes {
    class Rectangle {
        private string name;
        private RectangleEvent events = new RectangleEvent();
        private double area;
        private List<Point> points = new List<Point>();

        private void ValidPoint(Point point) {
            if (points.Count > 4) {
                throw new RectangleExeption("Число точек не может быть больше 4");
            }
            if (point.X < 0 || point.Y < 0) {
                throw new RectangleExeption("Координаты должны быть положительными числами");
            }
        }
        private void ValidPoints() {
            if (points.Count == 4) {
                for (int i = 0; i < points.Count; i++) {
                    if (points[i].X != points[((i + 1) % 4)].Y && points[i].Y != points[((i + 1) % 4)].X) {
                        if(i == 0)
                            throw new RectangleExeption("Невозможно построить прямоугольник по данным координатам", points[i]);
                        else
                            throw new RectangleExeption("Невозможно построить прямоугольник по данным координатам", points[i+1]);
                    }
                }
            }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public double Area {
            get { return area; }
        }
        virtual public Point this[int i] {
            get { return points[i]; }
            set {
                ValidPoint(value);
                points[i] = value;
            }
        }
        virtual public List<Point> Items {
            get { return points; }
            set {
                for (int i = 0; i < value.Count; i++) {
                    ValidPoint(value[i]);
                    points.Add(value[i]);
                }
            }
        }
        virtual public void addPoint(Point point) {
            ValidPoint(point);
            points.Add(point);
        }

        public void AreaHendler(double oldValue) {
            Console.WriteLine("площадь фигуры равна 1");
            Console.WriteLine("Старое значение:" + oldValue.ToString());
        }

        public Rectangle() {
            events.AddEvent(new UI(AreaHendler));
        }
        public Rectangle(string _name) {
            name = _name;
            events.AddEvent(new UI(AreaHendler));
        }
        public Rectangle(string _name, List<Point> _points) {
            name = _name;
            for (int i = 0; i < _points.Count; i++) {
                ValidPoint(_points[i]);
                points.Add(_points[i]);
            }
            events.AddEvent(new UI(AreaHendler));
        }
        public Rectangle(string _name, params Point[] _points) {
            name = _name;
            for(int i=0; i < _points.Length - 1; i++) {
                ValidPoint(_points[i]);
                points.Add(_points[i]);
            }
            events.AddEvent(new UI(AreaHendler));
        }

        public double GetArea() {
            ValidPoints();

            double _area = default(double);

            for (int i = 0; i < points.Count - 1; i++) {
                _area += points[i].X * points[i + 1].Y - points[i].Y * points[i + 1].X;
            }

            _area += points[points.Count - 1].X * points[0].Y - points[points.Count - 1].Y * points[0].X;
            _area = Math.Abs(_area) / 2;

            if (_area == 1)
                events.OnRectangleEvents(area);

            area = _area;

            return area;
        }
    }
}