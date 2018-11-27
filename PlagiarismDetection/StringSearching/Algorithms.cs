using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearching
{
    public class Algorithms
    {
        public static List<int> KMP_Search(string s, string w)
        {
            if (w == String.Empty)
                return new List<int>();

            int j = 0;
            int k = 0;
            var t = new int[w.Length + 1];
            KMP_Table(w, ref t);
            var p = new List<int>();

            while (j < s.Length)
            {
                if (w[k] == s[j])
                {
                    j++;
                    k++;
                    if (k == w.Length)
                    {
                        p.Add(j - k);
                        k = t[k];
                    }
                }
                else
                {
                    k = t[k];
                    if (k < 0)
                    {
                        j++;
                        k++;
                    }
                }
            }

            return p;
        }

        /// <summary>
        /// Rabin-Karp string searching algoritm.
        /// </summary>
        /// <param name="s">Main text string to search.</param>
        /// <param name="p">Pattern to search for.</param>
        /// <returns>A boolean representing whether p was found in s.</returns>
        public static bool RabinKarp(string s, string p)
        {
            int patternHash = p.GetHashCode();
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                // Need to implement rolling hash to make subsequent hash lookups constant
                int stringHash = s.Substring(i, p.Length).GetHashCode();
                if (stringHash == patternHash)
                    if (s.Substring(i, p.Length) == p)
                        return true;
            }

            
            return false;
        }

        private static void KMP_Table(string w, ref int[] t)
        {
            int pos = 1;
            int cnd = 0;

            t[0] = -1;
            while (pos < w.Length)
            {
                if (w[pos] == w[cnd])
                {
                    t[pos] = t[cnd];
                    pos++;
                    cnd++;
                }
                else
                {
                    t[pos] = cnd;
                    cnd = t[cnd];

                    while (cnd >= 0 && w[pos] != w[cnd])
                    {
                        cnd = t[cnd];
                    }

                    pos++;
                    cnd++;
                }
            }

            t[pos] = cnd;

        }
        public static void Lcs(string test, string solu, int x, int y)
        {
            char[] testA = test.ToCharArray();
            char[] soluA = solu.ToCharArray();

            int[,] numA = new int[x + 1, y + 1];

            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        numA[i, j] = 0;
                    }
                    else if (testA[i - 1] == soluA[j - 1])
                    {
                        numA[i, j] = numA[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        numA[i, j] = Math.Max(numA[i - 1, j], numA[i, j - 1]);
                    }
                }
            }
            Console.WriteLine($"Longest Common Sub-sequence: {((float)numA[x, y]/x)*100}% chance of plagiarism.");
        }
    }
}
