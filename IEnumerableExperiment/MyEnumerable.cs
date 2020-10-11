using System;
using System.Collections.Generic;

namespace IEnumerableExperiment {
    public class MyEnumerable {


        internal List<string> myCollection = new List<string>();

        internal IEnumerable<string> MySelect(Func<List<string>, IEnumerable<string>> pred) {
            return pred(myCollection);
        }
    }
}
