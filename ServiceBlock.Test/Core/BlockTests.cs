using System;
using Xunit;
using ServiceBlock.Core;
using System.Linq;
using FluentAssertions;
using ServiceBlock.Interface;

namespace ServiceBlock.Test.Core
{
    public class BlockTests
    {
        [Fact]
        public void ValidResource_declared__Recognized_as_resource()
        {
            // Arrange
            // ValidResource is declared

            // Act 
            var resourceTypes = BlockInfo.ResourceTypes;

            // Assert
            resourceTypes.Should().Contain(typeof(ValidResource));
        }

        [Fact]
        public void ValidResource_declared__Controller_exists()
        {
            // Arrange
            // ValidResource is declared

            // Act 
            var controllers = Block.Controllers;

            // Assert
            controllers.Should().Contain(t => t.GetGenericArguments().Single() == typeof(ValidResource));
        }

        [Fact]
        public void InvalidResource_declared__Block_throws_exceptions()
        {
            // Arrange
            // InvalidResource is declared

            // Act 
            Action runAction = () => Block.Run(new string[] { });

            // Assert
            runAction.Should().Throw<NoStorageException>();
        }
    }
}
