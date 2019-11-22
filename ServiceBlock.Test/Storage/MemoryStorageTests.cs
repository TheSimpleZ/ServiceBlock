using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using ServiceBlock.Interface.Storage;
using ServiceBlock.Storage;

namespace ServiceBlock.Test.Storage
{
    public class MemoryStorageTests
    {
        [Theory, AutoFakeItEasyData]
        public async Task ValidResource_created__Should_exist(Storage<ValidResource> memStorage, ValidResource resource)
        {
            // Act 
            await memStorage.Create(resource);
            var createdResource = await memStorage.Read(resource.Id);

            // Assert
            createdResource.Should().Be(resource);
        }

        [Theory, AutoFakeItEasyData]
        public async Task ValidResource_updated__Should_be_updated(Storage<ValidResource> memStorage, ValidResource resource)
        {
            // Arrange
            var before = resource.TestProp;
            await memStorage.Create(resource);

            resource.TestProp++;


            var updated = await memStorage.Update(resource);

            // Assert
            updated.Should().BeAssignableTo<ValidResource>().Which.TestProp.Should().Be(before + 1);
            updated.Should().BeAssignableTo<ValidResource>().Which.Id.Should().Be(resource.Id);

        }

        [Theory, AutoFakeItEasyData]
        public async Task ValidResource_deleted__Should_be_deleted(Storage<ValidResource> memStorage, ValidResource resource)
        {
            // Arrange
            var before = resource.TestProp;
            await memStorage.Create(resource);

            await memStorage.Delete(resource.Id);

            // Assert
            memStorage.Invoking(ms => ms.Read(resource.Id)).Should().Throw<NotFoundException>();
        }


        [Theory, AutoFakeItEasyData]
        public async Task ValidResource_created__Should_not_raise_event(Storage<ValidResource> memStorage, ValidResource resource)
        {
            // Act 
            using (var monitor = memStorage.Monitor())
            {
                await memStorage.Create(resource);

                // Assert
                monitor.Should().NotRaise(nameof(Storage<ValidResource>.OnCreate));
            }
        }

        [Theory, AutoFakeItEasyData]
        public async Task ValidResource_updated__Should_not_raise_event(Storage<ValidResource> memStorage, ValidResource resource)
        {
            // Arrange
            var before = resource.TestProp;
            await memStorage.Create(resource);

            resource.TestProp++;

            // Act 
            using (var monitor = memStorage.Monitor())
            {

                var updated = await memStorage.Update(resource);

                // Assert
                monitor.Should().NotRaise(nameof(Storage<ValidResource>.OnUpdate));
            }
        }

        [Theory, AutoFakeItEasyData]
        public async Task ValidResource_deleted__Should_not_raise_event(Storage<ValidResource> memStorage, ValidResource resource)
        {
            // Arrange
            var before = resource.TestProp;
            await memStorage.Create(resource);

            // Act 
            using (var monitor = memStorage.Monitor())
            {

                await memStorage.Delete(resource.Id);

                // Assert
                monitor.Should().NotRaise(nameof(Storage<ValidResource>.OnDelete));
            }
        }

        [Theory, AutoFakeItEasyData]
        public async Task EmitEventsResource_created__Should_raise_event(Storage<EmitEventsResource> memStorage, EmitEventsResource resource)
        {
            // Act 
            using (var monitor = memStorage.Monitor())
            {
                await memStorage.Create(resource);

                // Assert
                monitor.Should().Raise(nameof(Storage<EmitEventsResource>.OnCreate));
            }
        }

        [Theory, AutoFakeItEasyData]
        public async Task EmitEventsResource_updated__Should_raise_event(Storage<EmitEventsResource> memStorage, EmitEventsResource resource)
        {
            // Arrange
            var before = resource.TestProp;
            await memStorage.Create(resource);

            resource.TestProp++;

            // Act 
            using (var monitor = memStorage.Monitor())
            {

                var updated = await memStorage.Update(resource);

                // Assert
                monitor.Should().Raise(nameof(Storage<EmitEventsResource>.OnUpdate));
            }
        }

        [Theory, AutoFakeItEasyData]
        public async Task EmitEventsResource_deleted__Should_raise_event(Storage<EmitEventsResource> memStorage, EmitEventsResource resource)
        {
            // Arrange
            var before = resource.TestProp;
            await memStorage.Create(resource);

            // Act 
            using (var monitor = memStorage.Monitor())
            {

                await memStorage.Delete(resource.Id);

                // Assert
                monitor.Should().Raise(nameof(Storage<EmitEventsResource>.OnDelete));
            }
        }


    }
}
