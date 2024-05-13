public static class LinkedListTester {
    public static void Run() {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        // Problem 1 sample test didn't really need changes.
        // I added additional InsertTail statements to ensure
        // proper functionallity.
        var ll = new LinkedList();
        ll.InsertTail(2);
        ll.InsertTail(2);
        ll.InsertTail(2);
        ll.InsertTail(1);
        ll.InsertHead(3);
        ll.InsertHead(4);
        ll.InsertHead(5);

        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1};
        ll.InsertTail(0);
        ll.InsertTail(-1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1, 0, -1};

        var ll2 = new LinkedList();
        ll2.InsertTail(1);
        Console.WriteLine(ll2.HeadAndTailAreNotNull()); // True

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        // Problem 2 sample test seems to cover all the necessary
        // results. Ensure the correct sequence of values returned
        // from the list. Ensure that it can function with both
        // empty lists and single value lists.
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1, 0}
        ll.RemoveTail();
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 3, 2, 2, 2, 1}

        var ll3 = new LinkedList();
        ll3.RemoveTail();
        Console.WriteLine(ll3.ToString()); // <LinkedList>{}
        ll3.InsertHead(2);
        ll3.RemoveTail();
        Console.WriteLine(ll3.ToString()); // <LinkedList>{}
        Console.WriteLine(ll3.HeadAndTailAreNull()); // True

        Console.WriteLine("\n=========== PROBLEM 3 TESTS ===========");
        // Problem 3 sample test seems to cover all the necessary
        // results. Ensure the correct sequence of values returned
        // from the list. Ensure that it can function with both
        // empty lists and single value lists.
        ll.InsertAfter(3, 35);
        ll.InsertAfter(5, 6);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 3, 35, 2, 2, 2, 1}
        ll.Remove(-1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 3, 35, 2, 2, 2, 1}
        ll.Remove(3);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 6, 4, 35, 2, 2, 2, 1}
        ll.Remove(6);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2, 1}
        ll.Remove(1);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2}
        ll.Remove(7);
        Console.WriteLine(ll.ToString()); // <LinkedList>{5, 4, 35, 2, 2, 2}
        ll.Remove(5);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 2, 2, 2}
        ll.Remove(2);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 2, 2}

        var ll4 = new LinkedList();
        ll4.Remove(0);
        Console.WriteLine(ll4.ToString()); // <LinkedList>{}
        ll4.InsertHead(2);
        ll4.Remove(2);
        Console.WriteLine(ll4.ToString()); // <LinkedList>{}
        Console.WriteLine(ll4.HeadAndTailAreNull()); // True

        Console.WriteLine("\n=========== PROBLEM 4 TESTS ===========");
        // Problem 4 tests needed minimal additions, we test to see if
        // replacing multiple values works as expected, we ensure not
        // replacing a value works, and we ensure replacing a single
        // value works. I added functionallity to ensure replacing in
        // an empty list doesn't cause any errors.
        ll.Replace(2, 10);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 10, 10}
        ll.Replace(7, 5);
        Console.WriteLine(ll.ToString()); // <LinkedList>{4, 35, 10, 10}
        ll.Replace(4, 100);
        Console.WriteLine(ll.ToString()); // <LinkedList>{100, 35, 10, 10}

        var ll5 = new LinkedList();
        ll.Replace(2, 10);
        Console.WriteLine(ll5.ToString()); // <LinkedList>{}

        Console.WriteLine("\n=========== PROBLEM 5 TESTS ===========");
        // Problem 5 is pretty straightforward, it takes the provided
        // list and returns the reversed version of it.
        Console.WriteLine(ll.Reverse().AsString()); // <IEnumerable>[10, 10, 35, 100}
    }
}