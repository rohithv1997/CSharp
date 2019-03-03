using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Demo_1
{
    class BetterComparison
    {
        public bool Compare<T>(T x,T y)
        {
            return x.Equals(y);
        }
        public bool Compare<T,K>(T x,K y)
        {
            return x.Equals(y);
        }
    }
    class BestComparison<T,K>
    {
        public T Something { get; set; }
        public bool Compare(T x,T y)
        {
            return x.Equals(y);
        }
        public bool Compare(T x,K y)
        {
           
            return x.Equals(y);
        }
        public K MyMethod(K x)
        {
            K y;
            y = x;
            return y;
        }
    }
    struct MyStruct<T>
    {

    }
    interface IInterface<T>
    {

    }
}
