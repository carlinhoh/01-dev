/*
https://leetcode.com/problems/robot-room-cleaner/submissions/1266307949/

Time: O(N - M), where N is the number of cells and M the number of obstacles
Space: O(N - M)
*/
class Solution {
        // Define the directions in the order: up, right, down, left
    int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };
    // Track visited positions
    HashSet<(int x, int y)> pathHistory = new();
    Robot robot;

    // Entry point for cleaning the room
    public void CleanRoom(Robot robot) {
        this.robot = robot;
        BacktrackPaths(0, 0, 0);
    }

    // Backtracking function to explore and clean the room
    public void BacktrackPaths(int x, int y, int nextDirection){
        // Clean the current cell
        robot.Clean();
        // Mark the current cell as visited
        pathHistory.Add((x, y));

        // Explore all 4 directions
        for (int i = 0; i < 4; i++) {
            int newDirection = (nextDirection + i) % 4;
            int newX = x + directions[newDirection][0];
            int newY = y + directions[newDirection][1];

            // Move to the new cell if it hasn't been visited and is accessible
            if (!pathHistory.Contains((newX, newY)) && robot.Move()) {
                BacktrackPaths(newX, newY, newDirection);
                goBack();
            }
            // Turn to the next direction
            robot.TurnRight();
        }
    }

    public void goBack() {
        robot.TurnRight();
        robot.TurnRight();
        //Look back 
        robot.Move();
        robot.TurnRight();
        robot.TurnRight();
        //Look back to where it was
    }
}