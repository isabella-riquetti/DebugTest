using Xunit;

namespace Debug.Test
{
    public class Tests
    {

        [Theory]
        [InlineData(24813.40, 35000, 3 * 12, 50000, 1, 1, "Ford")]
        [InlineData(20672.61, 35000, 3 * 12, 150000, 1, 1, "Toyota")]
        [InlineData(19688.20, 35000, 3 * 12, 250000, 1, 1, "Tesla")]
        [InlineData(21094.5, 35000, 3 * 12, 250000, 1, 0, "toyota")]
        [InlineData(21657.02, 35000, 3 * 12, 250000, 0, 1, "Acura")]
        [InlineData(72000, 80000, 8, 10000, 0, 1, null)]
        private static void AssertCarValue(decimal expectValue, decimal purchaseValue,
        int ageInMonths, int numberOfMiles, int numberOfPreviousOwners, int
        numberOfCollisions, string make)
        {
            Assert.Equal(expectValue, 0);
        }
    }
}
