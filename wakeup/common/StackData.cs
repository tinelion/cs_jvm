using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsJVM.wakeup.common
{
    public class StackData<T>
    {
        private int size = 0;
        private Elemente<T> top;

        public int Size { get => size; set => size = value; }

        public void Push(T value)
        {
            if(value != null)
            {
                Elemente<T> elemente = new Elemente<T>(value);
                elemente.SetLower(top);
                this.top = elemente;
                Size++;
            }
        }

        public T Pop()
        {
            if(Size <= 0)
            {
                return default(T);
            }
            Elemente<T> temp = top;
            top = top.Lower();
            temp.SetLower(null);
            Size--;
            return temp.Value;
        }
    }


    public class Elemente<T>
    {
        private T value;
        private Elemente<T> next;

        public Elemente(T value)
        {
            this.value = value;
        }

        public T Value { get => value; set => this.value = value; }

        public Elemente<T> Lower()
        {
            return this.next;
        }

        public void SetLower(Elemente<T> elemente)
        {
            this.next = elemente;
        }
    }
}
