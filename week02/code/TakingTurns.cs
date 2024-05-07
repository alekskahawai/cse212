public static class TakingTurns
{
    public static void Test()
    {
        // TODO Problem 1 - Run test cases and fix the code to match requirements
        // Test Cases

        // Test 1
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
        // run until the queue is empty
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        Console.WriteLine(players);    // This can be un-commented out for debug help
        while (players.Length > 0)
            players.GetNextPerson();
        // Defect(s) Found: 
        /* After running tests, I saw a pattern in tests #1 and #2.
        Players are added to the queue in reverse order. Bob (2), Tim (5), Sue (3) should be in the queue in that order, but we got a list of [(Sue:3), (Tim:5), (Bob:2)].
        My hypothesis is to look into a function that adds players to the list.
        TakingTurns: 
        players.AddPerson("Bob", 2); => 

        TakingTurnsQueue.AddPerson
        _people.Enqueue(person); =>

        PersonQueue.Enqueue
        _queue.Insert(0, person); - this line of code inserts players to the beginning of the list, but it should add to the back of the queue.

        Fix the code and test again:
        _queue.Add(person);

        Test 1
        [(Bob:2), (Tim:5), (Sue:3)]
        Bob
        Tim
        Sue
        Bob
        Tim
        Sue
        Tim
        Sue
        Tim
        Tim

        Now it meets Exepcted Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        */

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
        // After running 5 times, add George with 3 turns.  Run until the queue is empty.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        Console.WriteLine("Test 2");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        for (int i = 0; i < 5; i++)
        {
            players.GetNextPerson();
            Console.WriteLine(players);
        }

        players.AddPerson("George", 3);
        Console.WriteLine(players);
        while (players.Length > 0)
            players.GetNextPerson();

        // Defect(s) Found:
        /* The same as in test #1
        test results after the code fix:
        Bob
        [(Tim:5), (Sue:3), (Bob:1)]
        Tim
        [(Sue:3), (Bob:1), (Tim:4)]
        Sue
        [(Bob:1), (Tim:4), (Sue:2)]
        Bob
        [(Tim:4), (Sue:2)]
        Tim
        [(Sue:2), (Tim:3)]
        [(Sue:2), (Tim:3), (George:3)]
        Sue
        Tim
        George
        Sue
        Tim
        George
        Tim
        George

        Now it meets Exepcted Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
         */

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
        // Run 10 times.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 3");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        Console.WriteLine(players);
        for (int i = 0; i < 10; i++)
        {
            players.GetNextPerson();
            Console.WriteLine(players);
        }
        // Defect(s) Found: 
        /* tests #3 and #4 show a pattern that players with Forever turns, that is the value of 0 or less, are not added back to the queue. 

        My hypothesis is to look into a function that checks number of turns and decides to add players back to the list.

        TakingTurns: 
        players.GetNextPerson(); => 

        TakingTurnsQueue.GetNextPerson()
        Person person = _people.Dequeue();
                    if (person.Turns > 1)
                    {
                        person.Turns -= 1;
                        _people.Enqueue(person);
                    }  - the function should also check if turns value is of 0 or less.

        Fix the code and test again:
        ...
        Person person = _people.Dequeue();
                    if (person.Turns > 1)
                    {
                        person.Turns -= 1;
                        _people.Enqueue(person);
                    }

                    else if (person.Turns <= 0) // Tests 3 & 4, fixed code
                    {
                        _people.Enqueue(person);
                    }
        ...

        Test 3
        [(Bob:2), (Tim:Forever), (Sue:3)]
        Bob
        [(Tim:Forever), (Sue:3), (Bob:1)]
        Tim
        [(Sue:3), (Bob:1), (Tim:Forever)]
        Sue
        [(Bob:1), (Tim:Forever), (Sue:2)]
        Bob
        [(Tim:Forever), (Sue:2)]
        Tim
        [(Sue:2), (Tim:Forever)]
        Sue
        [(Tim:Forever), (Sue:1)]
        Tim
        [(Sue:1), (Tim:Forever)]
        Sue
        [(Tim:Forever)]
        Tim
        [(Tim:Forever)]
        Tim
        [(Tim:Forever)]


        Now it meets Exepcted Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        */

        Console.WriteLine("---------");

        // Test 4
        // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
        // Run 10 times.
        // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.AddPerson("Tim", -3);
        players.AddPerson("Sue", 3);
        Console.WriteLine(players);
        for (int i = 0; i < 10; i++)
        {
            players.GetNextPerson();
            Console.WriteLine(players);
        }
        // Defect(s) Found: 
        /* The same as in test #1

        test results after the code fix:
        [(Tim:Forever), (Sue:3)]
        Tim
        [(Sue:3), (Tim:Forever)]
        Sue
        [(Tim:Forever), (Sue:2)]
        Tim
        [(Sue:2), (Tim:Forever)]
        Sue
        [(Tim:Forever), (Sue:1)]
        Tim
        [(Sue:1), (Tim:Forever)]
        Sue
        [(Tim:Forever)]
        Tim
        [(Tim:Forever)]
        Tim
        [(Tim:Forever)]
        Tim
        [(Tim:Forever)]
        Tim
        [(Tim:Forever)]

        Now it meets Exepcted Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
         */

        Console.WriteLine("---------");

        // Test 5
        // Scenario: Try to get the next person from an empty queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 5");
        players = new TakingTurnsQueue();
        players.GetNextPerson();
        // Defect(s) Found:
        /* defects not found
        Test 5
        No one in the queue.

        Meets Expected Result: Error message should is displayed.
        */
    }
}