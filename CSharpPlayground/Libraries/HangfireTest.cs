using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hangfire;
using Hangfire.MemoryStorage;

namespace CSharpPlayground.Libraries
{
    public class HangfireTest
    {

        public void Driver()
        {
            TestHangfire();
        }

        public void TestHangfire()
        {
            GlobalConfiguration.Configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseColouredConsoleLogProvider()
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseMemoryStorage(new MemoryStorageOptions
                    {

                        //CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        //SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        //QueuePollInterval = TimeSpan.Zero,
                        //UseRecommendedIsolationLevel = true
                    });

            BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));

            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }
        }
    }
}
