using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace DynamicPropertySerializer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new DynamicPropertyJsonConverter());

            var json = @"
            {
                '1CR': {'available':'0.0000','onOrders':'0.0000','btcValue':'0.0000'},
                'ABY': {'available':'1.0000','onOrders':'1.0000','btcValue':'1.0000'}
            }";

            var result = JsonConvert.DeserializeObject<IEnumerable<BalanceJson>>(json, settings);

            Assert.IsInstanceOfType(result, typeof(IEnumerable<BalanceJson>));

            Assert.AreEqual(2, result.Count());

            Assert.AreEqual("1CR", result.First().currencyCode);
            Assert.AreEqual("0.0000", result.First().available);

            Assert.AreEqual("ABY", result.Skip(1).First().currencyCode);
            Assert.AreEqual("1.0000", result.Skip(1).First().available);
        }
    }
}
