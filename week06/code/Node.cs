// tasks #1 #2 #4
public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value) // TODO Start Problem 1
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // check for a base case

        if (value == Data)
        {
            return true;
        }

        else if (value < Data)
        {
            // check on the left
            if (Left is null)
                return false;

            else
                return Left.Contains(value);
        }

        else
        {
            // check on the right
            if (Right is null)
                return false;

            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0;
    }
}