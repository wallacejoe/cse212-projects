public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            // Ends recursion if value already exists in the tree
            else if (Left.Data == value) {}
            else
                Left.Insert(value);
        }
        else {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            // Ends recursion if value already exists in the tree
            else if (Right.Data == value) {}
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        if (value < Data) {
            // Return false if value doesn't exist
            if (Left is null)
                return false;
            // Return true if value exists in the tree
            else if (Left.Data == value)
                return true;
            else
                return Left.Contains(value);
        }
        else {
            // Return false if value doesn't exist
            if (Right is null)
                return false;
            // Return true if value exists in the tree
            else if (Right.Data == value)
                return true;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight(int value = 1) {
        // If both paths null, return current value
        if (Left is null && Right is null) {
            return value;
        }
        // If one path null, continue on other path
        else if (Left is null) {
            return Right.GetHeight(value + 1);
        }
        else if (Right is null) {
            return Left.GetHeight(value + 1);
        }
        // If no null path, compare and return the larger value
        else {
            int right = Right.GetHeight(value + 1);
            int left = Left.GetHeight(value + 1);
            if (right < left) {
                return left;
            } else {
                return right;
            }
        }
    }
}