using System;
using System.Diagnostics;

namespace EfPerformanceLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalIterations = 1000;

            {
                var stopwatch = new Stopwatch();
                var entitiesContext = new TestDbEntities();

                stopwatch.Start();
                for (int i = 0; i < totalIterations; i++)
                {
                    try
                    {
                        // Creating sample logging object.
                        var sampleRequestLog = new RequestLogging
                        {
                            RequestTime = DateTime.UtcNow,
                            OperationId = 1,
                            IpAddress = "127.0.0.1",
                            UserId = 1,
                            RequestStatus = "S"
                        };

                        entitiesContext.AddRequestLog(
                            sampleRequestLog.RequestTime
                            , sampleRequestLog.OperationId
                            , sampleRequestLog.IpAddress
                            , sampleRequestLog.UserId
                            , sampleRequestLog.RequestStatus);
                    }
                    catch (Exception e)
                    {
                    }
                }

                stopwatch.Stop();

                Console.WriteLine("Total time using Stored Procedure with EF: {0}", stopwatch.Elapsed);
            }

            {
                var stopwatch = new Stopwatch();
                var entitiesContext = new TestDbEntities();

                stopwatch.Start();
                for (int i = 0; i < totalIterations; i++)
                {
                    try
                    {
                        // Creating sample logging object.
                        var sampleRequestLog = new RequestLogging
                        {
                            RequestTime = DateTime.UtcNow,
                            OperationId = 1,
                            IpAddress = "127.0.0.1",
                            UserId = 1,
                            RequestStatus = "S"
                        };

                        entitiesContext.RequestLoggings.Add(sampleRequestLog);

                        // Calling save changes after every object to demonstrate the
                        // real-time scenario where context will be created for each request.
                        entitiesContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                    }
                }

                stopwatch.Stop();

                Console.WriteLine("Total time using EF regular way: {0}", stopwatch.Elapsed);
            }

            Console.ReadLine();
        }
    }

}
