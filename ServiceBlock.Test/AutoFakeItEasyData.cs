using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;

namespace ServiceBlock.Test
{
    public class AutoFakeItEasyDataAttribute : AutoDataAttribute
    {
        public AutoFakeItEasyDataAttribute()
            : base(() => new Fixture()
                .Customize(new AutoFakeItEasyCustomization()))
        {
        }
    }
}