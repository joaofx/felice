namespace Felice.TestFramework
{
    using NBehave.Spec.NUnit;

    public static class NUnitExtensions
    {
        public static void ShouldDecimalEqual(this decimal actual, decimal expected)
        {
            actual.ShouldApproximatelyEqual(expected, 0.01m);
        }
    }
}
