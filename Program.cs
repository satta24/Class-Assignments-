using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DIS_Assignmnet1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is" + ' '+rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */
        private static bool HalvesAreAlike(string s)
        {
            try
            {

                //split the string into two equal halves 
                string first = s.Substring(0, s.Length / 2); //assign the first half to a variable 

                string second = s.Substring(s.Length / 2, s.Length / 2); // assign second half to a different variable

                //use regex function to match each substring to the vowels and if vowel exist in each count them
                int firstTotal = Regex.Matches(first, @"[AEIOUaeiou]").Count; 

                int secondTotal = Regex.Matches(second, @"[AEIOUaeiou]").Count;

                //Compare the vowel count for each substring and if it is the same return true
                if (firstTotal == secondTotal)
                {
                    return true;
                }
            
                return false;
            }

            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
             

                int ar_sum = 0;
                int[] arr = new int[26]; //initilize an array of length 26 since we have 26 characters in the alphabet

                foreach (char c in s) //loop through each character in string and turn into AsCII code equivalent 
                {
                    //Console.WriteLine((int)c);
                    int ind = (int)c;
                    arr[ind - 97] = 1; //add each charcter in alphabet in order to array since first charcter is a, which is equal to 97 we will subtract from 97
                    //if there arent 26 unique characters, elements in the array will have a 0
                }

                foreach (int x in arr)
                {
                    ar_sum += x; // count how many characters are in the array 
                }

                if (ar_sum != 26) // if sum of charcters is not equal to 26 which is number of alphabets return false

                {
                    return false;
                }
                

                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {


                int sum = 0;
                int max = 0;

                for(int i=0;i< accounts.GetLength(0); i++) //get length for rows 
                {
                    for(int j=0; j<accounts.GetLength(1);j++) //get length for columns 
                    {
                        sum += j; // sum each array's elements

                        // the array whose elements has the largest sum grab it 
                        if (sum > max)
                        {
                            max = sum;
                        }

                    }
                }
             

                return max; //return the largest sum 

            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                // write your code here.

                int count = 0;
                int sum = 0;


                //loop through each character in jewels 
                foreach (char c in jewels)
                {

                    if (stones.Contains(c)) //use contains function to see if the string stones contain any of the jewels charcters 

                        count++; // if it does increase the count by 1 
                    sum += count; // keep track of the sum of jewel charcters that appeared in stones 

                }

                return sum; //return the sum of jeweles in stones 
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }



        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                
                int n = s.Length;

                //int[] indices = new int[n];
                //for (int i = 0; i < n; i++)
                //{
                //    indices[i] = int.Parse(Console.ReadLine());
                //}

                char[] output = new char[n]; // create an array to hold the final output to return 


                int f = 0;
                foreach (int element in indices) //loop through integer indicies 
                {
                    output[element] = s[f]; //Add elements to output array using each of the indicies from indicies array and its corresponding character
                    f += 1;
                }


                return new string(output); //return the final output in string format instead of an array 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {

                int n = nums.Length;



                List<int> output = new List<int>(); //Create a list to use insert function since array does not have insert function



                for (int i = 0; i < n; i++) //loop through length of array and insert each new element 
                {
                    output.Insert(index[i], nums[i]); //if element already exists push current element to right 
                }

                int[] arrayOutput = output.ToArray(); //convert list type to array 



                return arrayOutput;//return target array 

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}



