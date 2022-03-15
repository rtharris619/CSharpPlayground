using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpPlayground.Helpers
{
    public class Timing
    {
        TimeSpan startTime;
        TimeSpan duration;

        public Timing()
        {
            startTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }

        public void StartTimer()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }

        public void StopTimer()
        {
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startTime);
        }

        public TimeSpan Result()
        {
            return duration;
        }

        public void DisplayResult()
        {
            Console.WriteLine("\n\nTime (seconds): " + Result().TotalSeconds);
        }
    }

    public class TestTiming
    {
        public void Driver()
        {
            int[] nums = new int[100000];
            BuildArray(nums);
            var timing = new Timing();
            timing.StartTimer();

            DisplayNums(nums);

            timing.StopTimer();
            timing.DisplayResult();
        }

        private void BuildArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        private void DisplayNums(int [] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
