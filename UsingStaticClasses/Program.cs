using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStaticClasses {
  using System.Console;

  // be sure to declare the class "static" if you'd like to be able
  // to use it with a using statement
  using Helpers;

  using System.Linq.Enumerable;

  class Program {

    static void Main(string[] args) {
      WriteLine("output");

      Helpers.DoSomethingToHelp();
      DoSomethingToHelp();
    }

    static void ExtensionMethodDetails() {
      // Range is an ordinary static method on the Enumerable class
      var range = Range(10, 20);

      // Where is an extension method, but is called like a basic static 
      // function here. The docs show/used to say(?) that this will NOT work in the 
      // future, but it does now (CTP 3, VS 2015 Pre).
      // According to the docs, this call will require full namespace
      // qualification in the future:
      // System.Linq.Enumerable.Where(...)
      var oddNumbers = Where(range, x => x % 2 == 1);

      // Using Where as an extension method is possible now (the extension
      // is brought into scope by the using statement) and will remain
      // possible in the future.
      var oddNumbers_ = range.Where(x => x % 2 == 1);

    }
  }
}

public static class Helpers {
  public static void DoSomethingToHelp() {
  }
}
