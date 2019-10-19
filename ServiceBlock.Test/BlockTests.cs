using System;
using Xunit;
using ServiceBlock.Core;
using System.Linq;
using FluentAssertions;

namespace ServiceBlock.Test
{
    public class BlockTests
    {
        [Fact]
        public void TestResource_declared__Recognized_as_resource()
        {
            // Arrange
            // TestResource is declared

            // Act 
            var resourceTypes = Block.ResourceTypes;

            // Assert
            resourceTypes.Should().Contain(typeof(TestResource));
        }

        [Fact]
        public void TestResource_declared__Controller_exists()
        {
            // Arrange
            // TestResource is declared

            // Act 
            var controllers = Block.Controllers;

            // Assert
            controllers.Should().Contain(t => t.GetGenericArguments().Single() == typeof(TestResource));
        }
    }
}
