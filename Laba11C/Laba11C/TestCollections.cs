using System;
using System.Collections.Generic;
using System.Text;
using Laba10_1;

namespace Laba11C
{
    public class TestCollections<K, T> where T : Worker, new() where K : Persona
    {
        public LinkedList<T> LinkedList1 = new LinkedList<T>();
        public LinkedList<string> LinkedList2 = new LinkedList<string>();
        public SortedDictionary<K, T> SortedDictionary1 = new SortedDictionary<K, T>();
        public SortedDictionary<string, T> SortedDictionary2 = new SortedDictionary<string, T>();


        public TestCollections()
        {
            for(int i=0;i<1000;++i)
            {
                T worker = new T();
                do
                {
                    worker.Init();
                } while (LinkedList1.Contains(worker) || LinkedList2.Contains(worker.ToString()) || SortedDictionary1.ContainsKey((K)worker.BasePerson)  ||
                SortedDictionary2.ContainsKey(worker.BasePerson.ToString()));
                LinkedList1.AddFirst(worker);
                LinkedList2.AddFirst(worker.ToString());
                SortedDictionary1.TryAdd((K)worker.BasePerson, worker);
                SortedDictionary2.TryAdd(worker.BasePerson.ToString(), worker);
            }
        }
    }
}
