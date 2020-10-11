using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IEnumerableExperiment {
    public class MyProgram {

        public static void Main(String[] args) {
            MyEnumerable ojb = new MyEnumerable();

            Func<List<string>, IEnumerable<string>> pred = (col) => { return col.Where(s => s.Length < 3); };

            ojb.myCollection.AddRange(new[]{"UttaraKhand", "ladhak", "Kashmir", "Punjab", "Haryana", "goa", "12"});
            foreach (var s in ojb.MySelect(MyPredicate)) {
                Console.WriteLine(s);
            }
            Console.WriteLine("Hello to Myworld");
            Console.ReadLine();
        }

        internal IEnumerable<string> MyPredicate(List<string> col)
        {
            return col.Where(s => s.Length < 3);
        }

        internal void LoopThrough() {


        }
    }
}
