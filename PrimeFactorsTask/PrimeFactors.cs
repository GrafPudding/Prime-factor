using System;
using System.Collections.Generic;

namespace PrimeFactorsTask
{
    public static class PrimeFactors
    {
        /// <summary>
        /// Compute the prime factors of a given natural number.
        /// A prime number is only evenly divisible by itself and 1.
        /// Note that 1 is not a prime number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Prime factors of a given natural number.</returns>
        /// <exception cref="ArgumentException">Thrown when number less or equal 0.</exception>
        /// <example>
        /// 60 => {2, 2, 3, 5}
        /// 8 => {2, 2, 2}
        /// 12 => {2, 2, 3}
        /// 901255 => {5, 17, 23, 461}
        /// 93819012551 => {11, 9539, 894119}.
        /// </example>
        public static int[] GetFactors(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("ghd");
            }

            int[] defolt = { 2 };
            List<int> result = new List<int>();
            int i;
            int j;
            int count = 0;

            for (i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    count = 0;
                    for (j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            count++;
                        }
                    }

                    if (count == 2)
                    {
                        result.Add(i);
                    }
                }
            }

            int[] notResult = result.ToArray();
            int multiply = 1;
            int index = 0;

            for (int k = 0; k < notResult.Length; k++)
            {
                multiply = multiply * notResult[k];
            }

            int multiplyRes = multiply;
            if (multiplyRes == number)
            {
                return notResult;
            }
            else if (multiplyRes != number && notResult.Length == 1)
            {
                while (multiply < number)
                {
                    result.Add(notResult[0]);
                    for (int k = 0; k < notResult.Length; k++)
                    {
                        multiply = multiply * notResult[k];
                    }
                }

                return result.ToArray();
            }
            else if (multiplyRes != number && notResult.Length > 1)
            {
                while (multiply < number)
                {
                    result.Add(notResult[index]);
                    for (int k = 0; k < notResult.Length; k++)
                    {
                        multiply = multiply * notResult[k];
                    }

                    index++;
                }

                int[] fin = result.ToArray();
                Array.Sort(fin);
                return fin;
            }

            return defolt;
        }
    }
}
