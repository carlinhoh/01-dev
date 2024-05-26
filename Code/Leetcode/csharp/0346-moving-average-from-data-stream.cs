/*
Queue https://leetcode.com/problems/moving-average-from-data-stream/submissions/1268786184/
Time: O(1) 
Space: O(n)

int[] https://leetcode.com/problems/moving-average-from-data-stream/submissions/1268794620/
Time: O(1)
Space: O(n)
*/
public class MovingAverage {
    Queue<int> window;
    int size;
    double count;
    public MovingAverage(int size) {
        this.window = new Queue<int>(size);
        this.size = size;
        this.count = 0;
    }
    
    public double Next(int val) {
        if(window.Count < size){
            count += val;
            window.Enqueue(val);
        }
        else{
            count -= window.Dequeue();

            count += val;

            window.Enqueue(val);
        }

        return count/window.Count;
    }
}

public class MovingAverage {
    private double sum = 0;
    private int size;
    private int count = 0;
    private int head = 0;
    private int[] window;

    public MovingAverage(int size) {
        this.size = size;
        this.window = new int[size];
    }
    
    public double Next(int val) {
        // Increment count to keep track of total number of elements seen
        count++;
        
        // Calculate the tail position that will be replaced in the circular array
        int tail = (head + 1) % size;
        
        // Update the sum by removing the oldest value and adding the new value
        sum = sum - window[tail] + val;
        
        // Move the head to the next position
        head = tail;
        
        // Place the new value in the current head position
        window[head] = val;
        
        // Calculate and return the moving average
        return sum / Math.Min(size, count);
    }
}
