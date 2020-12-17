using System.Collections.Generic;

namespace two.classes {
    abstract class Device<T> {
        private string name;
        private string code;
        private List<T> items = new List<T>();


        virtual public T this[int i] {
            get { return items[i]; }
            set { items[i] = value; }
        }
        virtual public List<T> Items {
            get { return items; }
            set { items = value; }
        }
        virtual public void addItem(T item) {
            items.Add(item);
        }

        virtual public string Name{
            get { return name; }
            set { name = value; }
        }
        virtual public string Code {
            get { return code; }
            set { code = value; }
        }

        override public string ToString() {
            return "Name: " + name + " Code: " + code;
        }
        virtual public List<T> Find(string fildName, string findValue) {
            List<T> result = new List<T>();
            var dynMethod = typeof(T).GetMethod("get_" + fildName);

            foreach (T item in items) {
                if (dynMethod.Invoke(item, null).ToString() == findValue)
                    result.Add(item);
            }

            return result;
        }
    }
}
