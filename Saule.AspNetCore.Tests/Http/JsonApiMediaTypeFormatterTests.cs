﻿using System.Linq;
using Saule.Http.Formatters;
using Xunit;

namespace Saule.AspNetCore.Tests.Http
{
    public class JsonApiMediaTypeFormatterTests
    {
        [Fact(DisplayName = "Input formatter must support Json Api media type")]
        public void TestMethod1()
        {
            var formatter = new JsonApiInputFormatter();
            Assert.Equal(1, formatter.SupportedMediaTypes.Count);
            Assert.Equal(Constants.MediaType, formatter.SupportedMediaTypes.First());
        }

        [Fact(DisplayName = "Output formatter must support Json Api media type")]
        public void TestMethod2()
        {
            var formatter = new JsonApiOutputFormatter();
            Assert.Equal(1, formatter.SupportedMediaTypes.Count);
            Assert.Equal(Constants.MediaType, formatter.SupportedMediaTypes.First());
        }
    }
}