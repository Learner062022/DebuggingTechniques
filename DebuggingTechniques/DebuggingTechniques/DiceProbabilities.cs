using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingTechniques
{
    class DiceProbabilities
    {
        public static Dictionary<int, Double> calculateProbabilitiesForNumberOfDice(int n)
        {
            Dictionary<int, int> rc = new Dictionary<int, int>();
            int mn = n;
            int mx = n * 6;
            for (int i = mn; i <= mx; i++)
            {
                rc[i] = 0;
            }

            int[] d = new int[n];

            for (int i = 0; i < n; i++)
            {
                d[i] = 1;
            }

            bool finished1 = false;

            while (!finished1)
            {
                int total = 0;
                foreach (int r in d)
                {
                    total += r;
                }

                rc[total] += 1;

                int i = 0;
                bool finished2 = false;

                while (!finished2)
                {
                    d[i] += 1;
                    if (d[i] <= 6)
                    {
                        finished2 = true;
                    }
                    else
                    {
                        if (i == n - 1)
                        {
                            finished1 = true;
                            finished2 = true;
                        }
                        else
                        {
                            d[i] = 1;
                        }
                    }
                    i++;
                }
            }
            Dictionary<int, Double> rp = new Dictionary<int, double>();
            Double total2 = Math.Pow(6.0, (Double)n);
            for (int i = mn; i <= mx; i++)
            {
                rp[i] = (Double)rc[i] / total2;
            }
            return rp;
        }
    }
}
