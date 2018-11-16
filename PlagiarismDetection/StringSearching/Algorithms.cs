using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearching
{
    public static class Algorithms
    {
        public static List<int> KMP_Search(string s, string w)
        {
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
    }
}
