﻿using System.Linq;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlParserTests
    {
        [Fact]
        public void CanReadCAP12Example()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);
            Assert.NotNull(alert.Info.ElementAt(0).Areas.ElementAt(0).Polygon);
        }
    }
}
