using System;
using System.Globalization;

namespace ProjectEuler
{
    class Program
    {
        static void Main()
        {
            DateTime startTime = DateTime.Now;
            var answer = Problem7();
            TimeSpan executionTime = DateTime.Now - startTime;
            Console.WriteLine("Answer: " + answer);
            Console.Write("In: " + executionTime.TotalMilliseconds);

            Console.ReadKey();
        }

        private static int Problem1()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum;
        }

        private static long Problem2()
        {
            long sum = 0;
            int n1 = 1;
            int n2 = 2;

            const int maxNumber = 4000000;
            while (n1 < maxNumber)
            {
                if(n1 % 2 == 0)
                    sum += n1;

                int nextN2 = n1 + n2;
                n1 = n2;
                n2 = nextN2;
            }
            return sum;
        }

        private static long Problem3()
        {
            const long num = 600851475143;

            for (long i = (long)Math.Sqrt(num); i > 1; i--)
            {
                if (num % i == 0)
                {
                    bool isPrime = true;
                    for (long j = 2; j * j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        private static long Problem4()
        {
            long largestPalidrome = 0;
            for (int i = 100; i < 999; i++)
            {
                for (int j = i; j > 99; j--)
                {
                    var mult = i*j;
                    if (mult < largestPalidrome)
                        break;
                    char[] number = mult.ToString().ToCharArray();
                    Array.Reverse(number);
                    if (mult.ToString() == new String(number) && mult > largestPalidrome)
                    {
                        largestPalidrome = mult;
                    }
                }
            }
            return largestPalidrome;
        }

        private static long Problem5()
        {
            long num = 20;
            while (num%2 != 0 || num%3 != 0 || num%4 != 0 || num%5 != 0 || num%6 != 0 || num%7 != 0 || num%8 != 0
                   || num%9 != 0 || num%10 != 0 || num%11 != 0 || num%12 != 0 || num%13 != 0 || num%14 != 0
                   || num%15 != 0 || num%16 != 0 || num%17 != 0 || num%18 != 0 || num%19 != 0 || num%20 != 0)
            {
                num+=20;
            }
            return num;
        }

        private static long Problem6()
        {
            long squareSum = 0, sumSquare = 0;
            for (int i = 1; i <= 100; i++)
            {
                squareSum += i*i;
                sumSquare += i;
            }
            return sumSquare*sumSquare - squareSum;
        }

        private static long Problem7()
        {
            int itsPrime = 1;
            long count = 3;
            while (itsPrime < 10001)
            {
                bool isPrime = BestWayToCheckForPrime(count);

                if (isPrime)
                    itsPrime++;

                count += 2;
            }

            return count -= 2;
        }

        private static bool BestWayToCheckForPrime(long num)
        {
            if (num == 1)
                return false;
            if (num < 4)
                return true;
            if (num%2 == 0)
                return false;
            if (num < 9)
                return true;
            if (num%3 == 0)
                return false;

            long sqrt = (long) Math.Sqrt(num);
            long count = 5;
            while (count <= sqrt)
            {
                if (num%count == 0)
                    return false;
                if (num%(count + 2) == 0)
                    return false;
                count += 6;
            }
            return true;

        }
    }
}
