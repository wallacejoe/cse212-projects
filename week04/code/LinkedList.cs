using System.Collections;

public class LinkedList : IEnumerable<int> {
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value) {
        // Create new node
        Node newNode = new Node(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value) {
        // Much like InsertHead, you start by creating a new node.
        // Then if the list is empty, you point both head and tail
        // to the new node. If the list is not empty, then only the
        // tail will be affected.

        Node newNode = new Node(value);
        if (_head is null) {
            _head = newNode;
            _tail = newNode;
        }
        else {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead() {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail() {
        // Again, as with the RemoveHead function, we first check
        // if the list has only one item. If only one item is present
        // we set both the head and tail to null. As stated above,
        // this will also cover an empty list, which is a helpful bit
        // of information I didn't know previously. If the list has
        // more than one item in it, then only the tail will be
        // affected.

        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        else if (_head is not null) {
            _tail.Prev!.Next = null;
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue) {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null) {
            if (curr.Data == value) {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail) {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value) {
        // Again, as with the RemoveHead function, we first check
        // if the list has only one item. If only one item is present
        // we set both the head and tail to null. If the list has
        // more then one item, we will iterate through the list until
        // we find the specified value. We then remove that value by
        // setting the prev and next of the adjacent right and left
        // nodes respectively, to the value of the other.
        // (i.e. right.Prev = left, left.Next = right)
        // Must ensure the prev/next nodes exist, or not replace them.
        if (_head == _tail) {
            _head = null;
            _tail = null;
        }
        else if (_head is not null) {
            var current = _head;
            while (current != null && current.Data != value) {
                current = current.Next;
            }
            if (current != null && current.Data == value) {
                if (current.Next != null && current.Prev != null) {
                    current.Next.Prev = current.Prev;
                    current.Prev.Next = current.Next;
                } else if (current.Next != null && current.Prev == null) {
                    _head.Next!.Prev = null;
                    _head = _head.Next;
                } else if (current.Next == null && current.Prev != null) {
                    _tail.Prev!.Next = null;
                    _tail = _tail.Prev;
                }
            }
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue) {
        // This problem is fairly straight forward, iterate through
        // the list, set all instances of the old value to the new
        // value.
        if (_head is not null) {
            var current = _head;
            while (current != null) {
                if (current.Data == oldValue) {
                    current.Data = newValue;
                }

                current = current.Next;
            }
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse() {
        // Running the reverse of the list is objectively easy.
        // You simply iterate through the list starting with the
        // last node, rather then the first, and continue to the
        // previous node, instead of the next node.

        var curr = _tail; // Start at the end since this is a reverse iteration.
        while (curr != null) {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Prev; // Go backward in the linked list
        }
    }

    public override string ToString() {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull() {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull() {
        return _head is not null && _tail is not null;
    }
}