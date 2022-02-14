using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;


namespace ASSIGNMENT_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();
        }



        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int min = 0;
                int max = nums.Length - 1;
                int final = -1;
                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (target == nums[mid])   //comparing target with the middle indexed value
                    {
                        final = mid;
                        break; //breaking the loop if it is equal
                    }
                    else if (target < nums[mid])
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }

                }
                if (final == -1)// if target is not found--the value of 'if' is not updated 
                {
                    final = min;//gives the position where to be inserted
                }
                return final;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                string z = "";
                foreach (char a in paragraph)
                {
                    if (a != '!' && a != '?' && a != '\'' && a != ';' && a != ',' && a != '.')
                    {
                        z = z + a;
                    }
                    else
                    {
                        z = z + ' ';
                    }
                }
                string z1 = z.ToLower();
                string[] z2 = z1.Split(" ");
                foreach (string x in z2)//removing empty spaces
                {
                    z2 = z2.Where(y => y != "").ToArray();
                }
                foreach (string x in banned)//removing banned elements
                {
                    z2 = z2.Where(y => y != x.ToLower()).ToArray();
                }
                Dictionary<string, int> final = new Dictionary<string, int>();
                foreach (string a in z2.Distinct())//lookping over the distinct strings 
                {
                    int count = 0;
                    foreach (string b in z2)
                    {
                        if (a == b)
                        {
                            count = count + 1;//incrementing count 
                        }
                    }
                    final.Add(a, count);
                }
                string output = "";
                foreach (KeyValuePair<string, int> x in final)
                {
                    if (x.Value == final.Values.Max())
                    {
                        output = x.Key;
                    }
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }


        

        public static int FindLucky(int[] arr)
        {
            try
            {
                Array.Sort(arr);
                ArrayList result = new ArrayList();//craeting new list array
                int[] x = arr.Distinct().ToArray();
                int[] count = new int[x.Length];
                for (int i = 0; i < count.Length; i++)//for loop to store count array
                {
                    count[i] = arr.Count(s => s == x[i]);
                }
                for (int i = 0; i < count.Length; i++)
                {
                    if (x[i] == count[i])
                    {
                        result.Add(x[i]);
                    }
                }
                int final = -1;//initializing final as -1
                if (result.Count != 0)
                {
                    final = (int)result[result.Count - 1];
                }

                return final;
            }
            catch (Exception)
            {

                throw;
            }

        }

        

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int count = 0;
                int sum = 0;
                string x = "";
                string y = "";
                for (int j = 0; j < guess.Length; j++)
                {
                    if (secret[j] == guess[j])//checking if 'j'th index of secret and guss are equal or not
                    {
                        count = count + 1;
                    }
                    else
                    {
                        x = x + secret[j];//if not equal-- adding into new string
                        y = y + guess[j];
                    }
                }
                foreach (char a in x)//foreach character in 'x' checking with 'y' using forloop 
                {
                    int flag = 0;
                    for (int k = 0; k < y.Length; k++)
                    {
                        if (y[k] == a && flag == 0)
                        {
                            sum = sum + 1;
                            y = y.Remove(k, 1);//removing 'k' at that position
                            flag = 1;
                        }
                    }
                }
                string z = count.ToString() + "A" + sum.ToString() + "B";
                return z;
            }
            catch (Exception)
            {

                throw;
            }
        }




        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int len = s.Length;
                List<int> z = new List<int>();//creating a list 'z'
                int[] x = new int[26];//integer array of length 26
                for (int i = len - 1; i >= 0; i--)
                {
                    if (x[s[i] - 97] == 0)
                    {
                        x[s[i] - 97] = i;
                    }
                }
                int y = 0;
                while (y < len)
                {
                    int a = y;
                    int b = x[s[y] - 97];
                    int c = b - a + 1;
                    for (int t = a; t <= b; t++)
                    {
                        if (x[s[t] - 97] > b)
                        {
                            b = x[s[t] - 97];
                            c = b - a + 1;
                        }
                    }
                    z.Add(c);//adding to the list
                    y = b + 1;
                }
                return z;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int sum = 0;
                int x1 = 0;
                int count = 1;

                for (int i = 0; i < s.Length; i++)//
                {
                    x1 = widths[s[i] - 97];//s[i] == ascii value of 'i'th element in string 's'
                    sum = sum + x1;
                    if (sum > 100)
                    {
                        sum = x1;//if sum>100....sum=x1 so that next line starts
                        count = count + 1;//count will be 1 when the next line starts
                    }
                }
                List<int> final = new List<int>();
                final.Add(count);
                final.Add(sum);
                return final;
            }
            catch (Exception)
            {
                throw;
            }

        }



        public static bool IsValid(string bulls_string10)
        {
            try
            {
                int len = bulls_string10.Length;
                ArrayList x = new ArrayList();
                Dictionary<string, string> z = new Dictionary<string, string>();
                z.Add("}", "{");
                z.Add("]", "[");
                z.Add(")", "(");
                int count = -1;
                for (int i = 0; i < len; i++)
                {
                    string a = bulls_string10[i].ToString();
                    if (z.ContainsValue(a))
                    {
                        x.Add(a);
                        count = count + 1;//to get size of arraylist
                    }
                    else if (z.ContainsKey(a) & count != -1)
                    {
                        if (z[a] == x[count].ToString())
                        {
                            x.RemoveAt(count);
                            count = count - 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (count == -1)
                    {
                        return false;
                    }
                }
                if (count != -1)
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


        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] a = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                int l = words.Length;
                string[] final = new string[l];//declaring new string
                for (int i = 0; i < l; i++)
                {
                    string x = words[i];//looping and adding from words to "x"
                    int h = x.Length;
                    string b = "";
                    for (int j = 0; j < h; j++)
                    {
                        int y = x[j] - 97;
                        b = b + a[y];
                    }
                    final[i] = b;
                }
                int count = final.Distinct().Count();//count of distinct elements in final
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}