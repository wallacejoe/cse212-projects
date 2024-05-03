public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        // var priorityQueue = new PriorityQueue();
        // Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: A single item can be both added to and removed from the queue
        // Expected Result: Hello World
        Console.WriteLine("Test 1");
        var pq = new PriorityQueue();
        pq.Enqueue("Hello World", 1);
        string value = pq.Dequeue();
        Console.WriteLine(value);

        // Defect(s) Found: No defects were found

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Enqueue and Dequeue multiple items with different priorities
        // Expected Result: Item2, Item3, Item1
        Console.WriteLine("Test 2");
        pq = new PriorityQueue();
        pq.Enqueue("Item1", 1);
        pq.Enqueue("Item2", 3);
        pq.Enqueue("Item3", 2);
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());

        // Defect(s) Found: This found that the Dequeue must remove the priority value at the end of the function
        // Additionally, found that the Dequeue index starting value should be 0 and the -1 should be removed from the _queue.Count - 1

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Enqueue and Dequeue multiple items with the same priority
        // Expected Result: Item3, Item1, Item2
        Console.WriteLine("Test 3");
        pq = new PriorityQueue();
        pq.Enqueue("Item1", 1);
        pq.Enqueue("Item2", 1);
        pq.Enqueue("Item3", 2);
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());
        Console.WriteLine(pq.Dequeue());

        // Defect(s) Found: Found that I needed to remove the = sign after the > sign in the dequeue function

        Console.WriteLine("---------");

        // Test 4
        // Scenario: Attempt to Dequeue from an empty queue
        // Expected Result: Should display an error message
        Console.WriteLine("Test 4");
        pq = new PriorityQueue();
        Console.WriteLine(pq.Dequeue());

        // Defect(s) Found: No defects were found
    }
}