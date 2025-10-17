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