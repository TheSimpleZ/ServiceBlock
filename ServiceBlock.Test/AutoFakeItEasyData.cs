using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;
using ServiceBlock.Interface.Resource;
using ServiceBlock.Storage;
using ServiceBlock.Interface.Storage;
using Microsoft.Extensions.Logging;

namespace ServiceBlock.Test
{
    public class AutoFakeItEasyDataAttribute : AutoDataAttribute
    {
        public AutoFakeItEasyDataAttribute()
            : base(() => GetFixture())
        {
        }

        private static IFixture GetFixture()
        {
            var fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization());

            fixture.Register<ILogger<MemoryStorage<ValidResource>>, Storage<ValidResource>>((logger) => new MemoryStorage<ValidResource>(logger));


            return fixture;
        }
    }
}