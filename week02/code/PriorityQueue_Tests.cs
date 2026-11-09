using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities: "TaskA" (1), "TaskB" (3), and "TaskC" (5), then dequeue all three.
    // Expected Result: "TaskC", "TaskB", "TaskA"
    // Defect(s) Found: The loop in Dequeue used index < _queue.Count - 1 so it never checked the last item in the queue. Also, Dequeue did not remove the item from the list with RemoveAt.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("TaskA", 1);
        priorityQueue.Enqueue("TaskB", 3);
        priorityQueue.Enqueue("TaskC", 5);

        Assert.AreEqual("TaskC", priorityQueue.Dequeue());
        Assert.AreEqual("TaskB", priorityQueue.Dequeue());
        Assert.AreEqual("TaskA", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items where two items have the same highest priority: "First" (4), "Second" (2), "Third" (4), "Fourth" (1).
    // Expected Result: "First", "Third", "Second", "Fourth"
    // Defect(s) Found: Dequeue used >= when comparing priorities, which caused it to pick the last item with the highest priority ("Third") instead of the first one ("First").
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 4);
        priorityQueue.Enqueue("Second", 2);
        priorityQueue.Enqueue("Third", 4);
        priorityQueue.Enqueue("Fourth", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Fourth", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Call Dequeue on an empty PriorityQueue.
    // Expected Result: Throws InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: No defects found, the exception and message worked properly.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
