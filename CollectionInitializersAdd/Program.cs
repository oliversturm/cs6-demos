﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInitializersAdd {
  class Program {
    static void Main(string[] args) {
      var collection = new MyCollection { 3, 5, 7 };
    }
  }

  public class MyCollection : IEnumerable<int> {
    // as long as this method is available, all is good - and has 
    // been good as long as collection initializers have been
    // available
    public void Add(int val) {
      Console.WriteLine("Adding: " + val);
    }

    IEnumerator<int> IEnumerable<int>.GetEnumerator() {
      yield break;
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return ((IEnumerable<int>) this).GetEnumerator();
    }
  }

  public static class CollectionExtensions {
    // this extension Add method was not previously recognized by 
    // the compiler for use with the collection initializer syntax
    // Now it works though.
    public static void Add(this MyCollection collection, int val) {
      Console.WriteLine("Adding in extension method: " + val);
    }
  }
}
