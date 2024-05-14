using System;
using System.Diagnostics;
public static class Priority
{
    public static void Test()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        //var priorityQueue = new PriorityQueue();
        //Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: add a few items (which contain both data and priority) to the queue. Each new item should go to the back of the queue.
        // Input: ("sunday", 7);("friday", 5);("monday", 1);

        // Expected Result: [sunday, 7; friday, 5; monday, 1]
        Console.WriteLine("Test 1");
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("sunday", 7);
        priorityQueue.Enqueue("friday", 5);
        priorityQueue.Enqueue("monday", 1);
        Console.WriteLine(priorityQueue);

        // Defect(s) Found: none
        /* Test 1
        [sunday(Pri: 7), friday(Pri: 5), monday(Pri: 1)] */

        Console.WriteLine("---------");

        // Test 2.1
        // Scenario: Enqueue [("monday", 1); ("friday", 5); ("sunday", 7)]. Dequeue all items. See if those with the highest priority are Dequeued first. 
        // Input: ("monday", 1);("friday", 5);("sunday", 7);

        // Expected Result: sunday, friday, monday

        Console.WriteLine("Test 2.1");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("monday", 1);
        priorityQueue.Enqueue("friday", 5);
        priorityQueue.Enqueue("sunday", 7);

        Console.WriteLine(priorityQueue);

        var value = priorityQueue.Dequeue();
        Trace.Assert(value == "sunday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        Trace.Assert(value == "friday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        Trace.Assert(value == "monday");
        Console.WriteLine(value);

        Console.WriteLine(priorityQueue);
        // Defect(s) Found: the Dequeue function doesn't reach the end of the queue
        /*
        Test 2.1 - the first run:
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7)]
        friday
        friday
        friday
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7)]
        --------- 
        Found for loop in the function
        for (int index = 1; index < _queue.Count - 1; index++)
        the loop iterated only till the _queue.Count -1

        ------------
        Fixed the 'for loop' to iterate through all items:
        for (int index = 1; index < _queue.Count; index++)
        
        ----------------
        Test 2.1 - run after the code fix:
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7)]
        sunday
        sunday
        sunday
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7)]
        
        --------------
        Noted that the queue is not cleared. Proceeded to Test 2.2
        */

        Console.WriteLine("---------");

        // Test 2.2
        // Scenario: Enqueue [("monday", 1); ("friday", 5); ("sunday", 7); ("saturday", 6)]. Dequeue all items. 
        // Expected Result:
        // 1) The queue should be empty at the end of the run. 
        // 2) Output: sunday, saturday, friday, monday

        Console.WriteLine("Test 2.2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("monday", 1);
        priorityQueue.Enqueue("friday", 5);
        priorityQueue.Enqueue("sunday", 7);
        priorityQueue.Enqueue("saturday", 6);

        Console.WriteLine(priorityQueue);

        value = priorityQueue.Dequeue();
        Trace.Assert(value == "sunday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        Trace.Assert(value == "saturday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        Trace.Assert(value == "friday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        Trace.Assert(value == "monday");
        Console.WriteLine(value);

        Console.WriteLine(priorityQueue);
        // Defect(s) Found: the queue is not empty at the end of the run. 
        /* 
        Test 2.2 - the first run:
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7), saturday (Pri:6)]
        sunday
        sunday
        sunday
        sunday
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7), saturday (Pri:6)]
        ---------

        The Dequeue function doesn't have code to remove items from the queue
        ---------

        wrote additional line of code:
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // new line
        return value; 
        --------------
        Test 2.2
        [monday (Pri:1), friday (Pri:5), sunday (Pri:7), saturday (Pri:6)]
        sunday
        saturday
        friday
        monday
        []       --- match Expected Results
        */

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: Enqueue more than one item with the same high priority, observe the items to be removed in FIFO order.
        // Input: ("monday", 1);("1sunday", 7);("monday", 1);("1holiday", 7);("saturday", 6);("2holiday", 7);("monday", 1);("2sunday", 7);("friday", 5);

        // Expected Result: 1sunday, 1holiday, 2holiday, 2sunday, saturday, friday, monday, monday, monday  
        Console.WriteLine("Test 3");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("monday", 1);
        priorityQueue.Enqueue("1sunday", 7);
        priorityQueue.Enqueue("monday", 1);
        priorityQueue.Enqueue("1holiday", 7);
        priorityQueue.Enqueue("saturday", 6);
        priorityQueue.Enqueue("2holiday", 7);
        priorityQueue.Enqueue("monday", 1);
        priorityQueue.Enqueue("2sunday", 7);
        priorityQueue.Enqueue("friday", 5);

        Console.WriteLine(priorityQueue);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "sunday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "saturday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "friday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "monday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "monday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "monday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "monday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "monday");
        Console.WriteLine(value);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "monday");
        Console.WriteLine(value);

        Console.WriteLine(priorityQueue);
        // Defect(s) Found: items with the same priority index are removed from the queue in LIFO order

        /*  
        Test 3 - first run:
        [monday (Pri:1), 1sunday (Pri:7), monday (Pri:1), 1holiday (Pri:7), saturday (Pri:6), 2holiday (Pri:7), monday (Pri:1), 2sunday (Pri:7), friday (Pri:5)]
        2sunday
        2holiday
        1holiday
        1sunday
        saturday
        friday
        monday
        monday
        monday
        []
        --------
        Looked at the line of code where index of high priority item is identified 
        // if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)
        programm keeps updating the index/position to be dequeued when sees the same priority level. it brings it to the rare end of the queue.
        ---------
        code fix, remove '=' from comparison: // if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
        -----------------
        Test 3 - run after code fix:
        [monday (Pri:1), 1sunday (Pri:7), monday (Pri:1), 1holiday (Pri:7), saturday (Pri:6), 2holiday (Pri:7), monday (Pri:1), 2sunday (Pri:7), friday (Pri:5)]
        1sunday
        1holiday
        2holiday
        2sunday
        saturday
        friday
        monday
        monday
        monday
        []         --- match expected results.
        ---------

        */

        Console.WriteLine("---------");

        // Test 4
        // Scenario: try to Dequeue an item from an empty queue
        // Expected Result: the error message displayed, "The queue is empty."
        Console.WriteLine("Test 4");
        priorityQueue = new PriorityQueue();

        Console.WriteLine(priorityQueue);

        value = priorityQueue.Dequeue();
        // Trace.Assert(value == "");
        Console.WriteLine(value);

        // Console.WriteLine(priorityQueue);
        // Defect(s) Found: none 
        /* Test 4
            []
            The queue is empty. */

        Console.WriteLine("---------");

    }
}