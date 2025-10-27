// See https://aka.ms/new-console-template for more information
using System.Diagnostics;


var a = Enumerable.Range(1, 11).ToArray();
 

var numbers = new int[] { -1, -2, -3, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var t = 5;
var arrtest = TowCrystalBalls.GetBigTestArr();
var f = TowCrystalBalls.FindBrakingPoint(arrtest);
System.Console.WriteLine();
// var r = Bs(numbers, t); 

// var r1 = BinarySearch.BinarySerach_N(numbers, t);

// System.Console.WriteLine(r1);

// int Bs(int[] arr, int target)
// {
//     int lo = 0;
//     int hi = arr.Length;

//     while (lo < hi)
//     {
//         //find midpoint 
//         int m_index = lo + (hi - lo) / 2;
//         var m_value = arr[m_index];
//         if (m_value == target) return m_index;
//         else if (m_value > target)
//         {
//             hi = m_index;
//         }
//         else
//         {
//             lo = m_index + 1;
//         }
//     }

//     return 1;
// }



// int Fib(int n)
// {
//     count++;
//     if (n <= 1) return n;
//     int r = Fib(n - 1) + Fib(n - 2);
//     return r;

// }
// int Fib_B(int n)
// {
//     count++;
//     if (n <= 1) return n;
//     if (memo.ContainsKey(n))
//     {
//         return memo[n];
//     }
//     int r = Fib_B(n - 1) + Fib_B(n - 2);
//     memo.Add(n, r);
//     return r;

// }