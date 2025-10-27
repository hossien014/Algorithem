# Binary serach 

```
  public static int BinarySerach_N(int[] arr, int target)
    {

        int high = arr.Length;
        int low = 0;
        int midlle_value;
        int midlle_index;

        while (low < high)
        {
            midlle_index = low + (high - low) / 2;
            midlle_value = arr[midlle_index];
            if (target == midlle_value) return midlle_index;

            else if (target > midlle_value)
            {
                low = midlle_index + 1;
            }
            else
            {
                high = midlle_index;
            }
        }

        return -1;
    }
```
## interview questions from leetcode
[Question Link](https://leetcode.com/problems/binary-search/description/)

Given an array of integers nums which is sorted in ascending order,
and an integer target, write a function to search target in nums. If target exists,
then return its index. Otherwise, return -1.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4
Example 2:
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
Constraints:
1 <= nums.length <= 104
-104 < nums[i], target < 104
All the integers in nums are unique.
nums is sorted in ascending order.


## The Search Space Convention

In this implementation, the search space is defined as **[low, high)** - meaning:
- `low` is **inclusive** (the element at `low` is considered)
- `high` is **exclusive** (the element at `high` is NOT considered)

## Why the Difference?

### When `target > middle_value`:
```csharp
low = middle_index + 1;
```
- We know the target is NOT at `middle_index`
- We also know the target is greater than `middle_value`, so it must be in the **right half**
- Since `low` is inclusive, we set it to `middle_index + 1` to exclude the current `middle_index`

### When `target < middle_value`:
```csharp
high = middle_index;
```
- We know the target is NOT at `middle_index`
- We also know the target is less than `middle_value`, so it must be in the **left half**
- Since `high` is exclusive, setting `high = middle_index` naturally excludes `middle_index` from the search space

## Example Search

Let's search for `5` in array: `[1, 3, 5, 7, 9]`

Initial state: `low = 0`, `high = 5` (searching indices 0-4)

**Iteration 1:**
- `middle_index = 2` (value = 5)
- Found! Return index 2

If we were searching for `4`:
**Iteration 1:**
- `middle_index = 2` (value = 5)
- `4 < 5` → `high = 2` (now searching indices 0-1)

**Iteration 2:**
- `middle_index = 1` (value = 3)  
- `4 > 3` → `low = 2` (now searching indices 2-1 → empty)
- Return -1 (not found)

## Alternative Implementation

Some implementations use **inclusive bounds** for both:
```csharp
int high = arr.Length - 1;
while (low <= high) {
    // ...
    if (target > middle_value) {
        low = middle_index + 1;
    } else {
        high = middle_index - 1;  // high gets -1 here
    }
}
```

Both approaches are correct - they just use different boundary conventions. The exclusive `high` approach is often preferred because it avoids off-by-one errors and works well with zero-based indexing.

---
# two Crystal Balls
![Alt text](/media/Gemini_Generated_Image_qgbq3oqgbq3oqgbq.png "Optional title text")

which is a classic algorithmic puzzle often used in programming interviews. It's essentially a variation of the more general **Egg Dropping Problem**.

## What is the Problem?

The "Two Crystal Balls" problem is usually stated as:

"You have a building with **$n$ floors** and **two identical crystal balls**. You want to find the **critical floor $f$**—the lowest floor from which a ball will break when dropped—using the minimum number of drops in the **worst-case scenario**."

Key assumptions are:
* If a ball breaks when dropped from floor $x$, it will also break when dropped from any floor above $x$.
* If a ball doesn't break, it can be used again.
* The critical floor $f$ can be anywhere from 0 (breaks even from the first floor, or the floor is 0) to $n$ (doesn't break from the top floor).

---

## Optimal Solution Strategy

The goal is to minimize the worst-case number of drops.

### 1. The Naive Approach (Linear Search)

* Drop the first ball from floor 1, then floor 2, and so on, until it breaks.
* **Worst-case drops:** $n$ (if the critical floor is $n$ or $n-1$). This only uses one ball, which defeats the purpose of having two.

### 2. Why Binary Search Fails

* Drop the first ball from the middle floor (e.g., floor $n/2$).
* If it breaks, you must use your **last ball** to check the floors below linearly (from floor 1 up to $n/2 - 1$) to find the exact critical floor.
* **Worst-case drops:** $1$ (first drop) $+ (n/2 - 1)$ (linear checks) $\approx O(n/2)$. This is better than $O(n)$, but still too high.

### 3. The Optimal Approach ($\mathbf{O(\sqrt{n})}$)

The most efficient strategy balances the number of jumps with the linear search that follows a break. It involves dropping the first ball in fixed-size steps, where the size of the step is $\approx \sqrt{n}$.

* **Step 1 (First Ball - Jumps):** Drop the first ball from floors $\sqrt{n}$, $2\sqrt{n}$, $3\sqrt{n}$, and so on.
* **Step 2 (Second Ball - Linear Search):** When the first ball breaks (say, at floor $k\sqrt{n}$), you know the critical floor is somewhere between $(k-1)\sqrt{n} + 1$ and $k\sqrt{n}$. You then use your second ball to check these floors linearly, starting from $(k-1)\sqrt{n} + 1$.

If $n=100$, the jump size would be $\sqrt{100} = 10$. You check floors 10, 20, 30, ..., 100.
* **Worst Case:** The critical floor is 99 or 100.
    1.  The first ball is dropped at 10, 20, ..., 90 (survives). (9 drops)
    2.  The first ball is dropped at 100 (breaks).
    3.  The second ball checks 91, 92, ..., 99 (breaks at 99, or survives 99 and breaks at 100). (9 drops)
* **Total worst-case drops:** $10$ (jumps) $+ 9$ (linear checks) $= \mathbf{19}$ drops.

**Generalized Time Complexity:** This strategy gives a worst-case time complexity of $\mathbf{O(\sqrt{n})}$ drops, which is the optimal solution for two balls.

