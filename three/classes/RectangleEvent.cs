using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace three.classes {
    delegate void UI(double oldValue);
    class RectangleEvent {
        public event UI rectangleEvents;
        public void OnRectangleEvents(double oldValue) {
            rectangleEvents(oldValue);
        }

        public void AddEvent(UI del) {
            rectangleEvents += del;
        }
    }
}
