using AsyncParctice;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test that whether the MockObject work correctly.
        /// </summary>
        /// <returns> a Task </returns>
        [Test]
        public async Task BasicTest()
        {
            //Arrage
            ICustomReportService service = new MockCustomReportService(100, 10);
            CustomReportRequest request = new CustomReportRequest();
            CustomReportResult excepted = new CustomReportResult { IsCompleted = true, };

            //Act
            CustomReportResult result = await service.GetCustomReport(request);

            //Assert
            Assert.AreEqual(excepted.IsCompleted, result.IsCompleted);
        }

        /// <summary>
        /// Check that whether the AvgResponseTime is close to 100ms.
        /// </summary>
        /// <returns> a Task </returns>
        [Test]
        public async Task AvgResponseTimeTest() 
        {
            //Arrage
            ICustomReportService service = new MockCustomReportService(100, 10);
            Stopwatch s = new Stopwatch();
            s.Start();
            CustomReportRequest request = new CustomReportRequest();
            
            //Act
            for (int time = 0; time < 10; time++)
            {
                CustomReportResult result = await service.GetCustomReport(request);
            }
            s.Stop();
            
            //Assert
            System.Console.WriteLine(s.ElapsedMilliseconds/10);
        }

        /// <summary>
        /// check that whether the RandomCustomReportServiceDistributer distributed requests randomly.
        /// </summary>
        /// <returns> a Task </returns>
        [Test]
        public async Task RandomDistributeTest()
        {
            //Arrage
            List<ICustomReportService> customReportServices = new List<ICustomReportService>();
            customReportServices.Add(new MockCustomReportService(100, 10));
            customReportServices.Add(new MockCustomReportService(200, 10));
            customReportServices.Add(new MockCustomReportService(300, 10));
            customReportServices.Add(new MockCustomReportService(400, 10));
            RandomCustomReportServiceDistributer distributer = new RandomCustomReportServiceDistributer(customReportServices);
            CustomReportRequest request = new CustomReportRequest();
            Stopwatch s = new Stopwatch();
            s.Start();

            //Act
            await distributer.GetCustomReport(request);
            Console.WriteLine(s.ElapsedMilliseconds);
            s.Restart();
            await distributer.GetCustomReport(request);
            Console.WriteLine(s.ElapsedMilliseconds);
            s.Restart();
            await distributer.GetCustomReport(request);
            Console.WriteLine(s.ElapsedMilliseconds);
            s.Restart();
            await distributer.GetCustomReport(request);
            Console.WriteLine(s.ElapsedMilliseconds);
        }

        /// <summary>
        /// Test that whether the mockService throw a Exception when requests is overflow.
        /// </summary>
        [Test]
        public void MaxRequestTest()
        {
            //Arrange
            CustomReportRequest request = new CustomReportRequest();
            ICustomReportService service = new MockCustomReportService(100, 3);
            
            //Act
            for (int i = 0; i < 5; i++)
            {
                service.GetCustomReport(request);
            }

            //Assert
            Assert.ThrowsAsync<CustomReportServiceException>(async () => await service.GetCustomReport(request));
        }

    }
}