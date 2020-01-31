namespace NumberToWordConversionRepository
{
    public interface IConvertor
    {
        /// <summary>
        /// Converts the number to Word format
        /// </summary>
        /// <param name="number">110.98</param>
        /// <returns>One Hundred Ten And Nine Eight Cents Only</returns>
        string ConvertNumberToWordFormat(double number);
    }
}
