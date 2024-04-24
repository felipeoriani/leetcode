# 731. My Calendar II

Problem: https://leetcode.com/problems/my-calendar-ii/

My Solution: https://leetcode.com/problems/my-calendar-ii/submissions/1241183280/

Time Complexity: `O(n)`, for the worst case scenario.

Space Complexity: `O(n)`, for the worst case scenario.

```
//    0 5 10 15 20 25 30 35 40 45 50 55 60 65
// A      --------                              True  (no conflict)
// B                              -------       True  (no conflict)
// C      --------------------                  True  (single conflict with A)
// D    ------                                  False (triple conflict with A and C)
// E    ---                                     True  (no conflict)
// F               -------------------          True  (double conflict but doesn't generate a triple)
```
