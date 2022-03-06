using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp 
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calc(7, 8));
        }

        public static int Calc(byte n, byte m)
        {
            if(n <= 2 || m <= 2)
            {
                return 0;
            }
            int result = 0;
            int stepHightCount = 0;
            int stepRightCount = 0;

            //сначала посчитать m % 2..
            //если m % 2 == 0, то stepHightCount = m / 2; stepRightCount = 0;
            //если m % 2 == 1, то stepHightCount = Round(m / 2); stepRightCount = 1;
            if(m % 2 == 0)
            {
                stepHightCount = m / 2 - 1;
                stepRightCount = 1;
                
            }
            else
            {
                stepHightCount = m / 2; //округляет в меньшую сторону
            }
            while (true)
            {
                int tempResult = Steps(stepHightCount, stepRightCount, n, m);
                if (tempResult == 0)
                {
                    return result;
                }
                else
                {
                    result += tempResult;
                    stepHightCount--;
                    stepRightCount++;
                }
            }
 
        }

        public static int Steps(int stepHightCount, int stepRightCount, byte n, byte m)
        {
            int result = 0;
            var currentStep = (1, 1);
            for (int i = 0; i < stepHightCount; i++)
            {
                currentStep = StepHight(currentStep);
            }
            for(int i = 0; i < stepRightCount; i++)
            {
                currentStep = StepRight(currentStep);
            }
            if (currentStep.Item2 == m && currentStep.Item1 <= n)
            {
                result = C(stepRightCount + stepHightCount, stepHightCount);
            }


            return result;
        } 

        public static (int,int) StepHight((int, int) step)
        {
            step.Item1 = step.Item1 + 1;
            step.Item2 = step.Item2 + 2;
            return step;
        }

        public static (int, int) StepRight((int, int) step)
        {
            step.Item1 = step.Item1 + 2;
            step.Item2 = step.Item2 + 1;
            return step;
        }



        //кол-во сочетаний из n по k
        public static int C(int n, int k)
        {
            if (k == 0 || k == n)
                return 1;
            else
                return C(n - 1, k - 1) + C(n - 1, k);
        }
    }
}