using System;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {

            TestCase testSimplicity1 = new TestCase()
            {
                N = 11,
                ExpectedString = "Простое",
                ExpectedException = null
            };

            TestCase testSimplicity2 = new TestCase()
            {
                N = 10,
                ExpectedString = "Не простое",
                ExpectedException = null
            };
            TestCase testSimplicity3 = new TestCase()
            {
                N = 977,
                ExpectedString = "Простое",
                ExpectedException = null
            };
            TestCase testSimplicity4 = new TestCase()
            {
                N = -11,
                ExpectedString = "Не простое",
                ExpectedException = null
            };
            TestCase testSimplicity5 = new TestCase()
            {
                N = 0,
                ExpectedString = "Не простое",
                ExpectedException = null
            };

            TestSimplicity(testSimplicity1);
            TestSimplicity(testSimplicity2);
            TestSimplicity(testSimplicity3);
            TestSimplicity(testSimplicity4);
            TestSimplicity(testSimplicity5);



            TestCase testFib1 = new TestCase()
            {
                N = 0,
                ExpectedFib = 0 ,
                ExpectedException = null
            };
            TestCase testFib2 = new TestCase()
            {
                N = 1,
                ExpectedFib = 1,
                ExpectedException = null
            };
            TestCase testFib3 = new TestCase()
            {
                N = 2,
                ExpectedFib = 1,
                ExpectedException = null
            };
            TestCase testFib4 = new TestCase()
            {
                N = -5,
                ExpectedFib = 5,
            };
            TestCase testFib5 = new TestCase()
            {
                N = -3,
                ExpectedFib = 2,
                ExpectedException = null
            };

            bool isRecursive = false; //проверка рекурсивного метода или нет
            TestFib(testFib1, isRecursive);
            TestFib(testFib2, isRecursive);
            TestFib(testFib3, isRecursive);
            TestFib(testFib4, isRecursive);
            TestFib(testFib5, isRecursive);

        }



        static string CheckSimplicity(int n)
        {
            string result;

            int d = 0;
            int i = 2;

            for(;i<n;i++)
            {
                if (n % i == 0)
                {
                    d++;
                }
            }

            if(d==0)
            {
                result = "Простое";
            } else
            {
                result = "Не простое";
            }

            return result;
        }

        static void TestSimplicity(TestCase testCase)
        {
            try
            {
                var actual = CheckSimplicity(testCase.N);

                if (actual == testCase.ExpectedString)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST WITH EXCEPTION");
                }
                else
                {
                    Console.WriteLine("INVALID TEST WITH EXCEPTION");
                }
            }
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; 
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;
           // асимптотическая сложность O(n*n*n) 
        }





        static int RecursiveFib(int n)
        {
            if(n<0)
            {
                return -1;
            }
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return RecursiveFib(n - 2) + RecursiveFib(n - 1) ;
            }
        }

        static int NonRecursiveFib(int n)
        {

            int prev = 0;
            int curr = 1;
            int result = 0;

            if (n == 1)
            {
                return 1;
            }

            for (int i = 1; i < n;i++)
            {
                result = prev+curr;
                prev = curr;
                curr = result;
            }
            return result;
        }

        static void TestFib(TestCase testCase, bool recursive)
        {
            try
            {
                int actual;
                if (recursive)
                {
                    actual = RecursiveFib(testCase.N);
                }
                else
                {
                    actual = NonRecursiveFib(testCase.N);
                }


                if (actual == testCase.ExpectedFib)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST WITH EXCEPTION");
                }
                else
                {
                    Console.WriteLine("INVALID TEST WITH EXCEPTION");
                }
            }
        }


    }
}
