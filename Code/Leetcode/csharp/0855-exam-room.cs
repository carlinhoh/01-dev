/*
https://leetcode.com/problems/exam-room/submissions/1211324222/

Time:
    Seat - O(n)
    leave - O(n)
Space: O(n)
*/
public class ExamRoom {
    private List<int> occupiedSeats;
    private int totalSeats;

    public ExamRoom(int n) {
        occupiedSeats = new List<int>();
        totalSeats = n;
    }

    public int Seat() {
        if (occupiedSeats.Count == 0) {
            occupiedSeats.Add(0);
            return 0;
        }

        int maxDistance = occupiedSeats[0]; 
        int seatToOccupy = 0;
        for (int i = 0; i < occupiedSeats.Count - 1; i++) {
            int currentDistance = (occupiedSeats[i + 1] - occupiedSeats[i]) / 2;
            if (currentDistance > maxDistance) {
                maxDistance = currentDistance;
                seatToOccupy = occupiedSeats[i] + currentDistance;
            }
        }

        if (totalSeats - 1 - occupiedSeats[occupiedSeats.Count - 1] > maxDistance) {
            seatToOccupy = totalSeats - 1;
        }

        var index = occupiedSeats.BinarySearch(seatToOccupy);
        if (index < 0) index = ~index;
        occupiedSeats.Insert(index, seatToOccupy);

        return seatToOccupy;
    }

    public void Leave(int p) {
        occupiedSeats.Remove(p);
    }
}
