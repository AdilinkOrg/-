using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace three.classes {
    delegate void UIp(Point point);
    class PointEvent {
        public event UIp pointEvent;
        public void OnPointEvent(Point point) {
            pointEvent(point);
        }

        public void AddEvent(UIp del) {
            pointEvent += del;
        }
    }

    [Serializable]
    class RectangleExeption:Exception {
        private Point errorPoint;
        private PointEvent events = new PointEvent();
        public Point ErrorPoint {
            get {
                return errorPoint;
            }
        }

        private void errorPointHendler(Point errorPoint) {
            Console.WriteLine("Ошибка построения");
            Console.WriteLine(errorPoint.ToString());
        }

        public RectangleExeption() { }
        public RectangleExeption(string message) : base(message) { }
        public RectangleExeption(string message, Point _errorPoint) : base(message) {
            errorPoint = _errorPoint;
            events.AddEvent(new UIp(errorPointHendler));
            events.OnPointEvent(_errorPoint);
        }
        public RectangleExeption(string message, Exception inner) : base(message, inner) { }
    }
}