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
        public void ValidResource_declared__Should_exists()
        {
            // Assert
            BlockInfo.ResourceTypes.Should().Contain(typeof(ValidResource));
        }

        [Fact]
        public void ValidResource_declared__Should_have_controller()
        {
            // Assert
            Block.Controllers.Should().Contain(t => t.GetGenericArguments().Single() == typeof(ValidResource));
        }

        [Fact]
        public void InvalidResource_declared__Should_throw_exception()
        {

            // Act 
            Action runAction = () => Block.Run(new string[] { });

            // Assert
            runAction.Should().Throw<NoStorageException>();
        }
    }
}
