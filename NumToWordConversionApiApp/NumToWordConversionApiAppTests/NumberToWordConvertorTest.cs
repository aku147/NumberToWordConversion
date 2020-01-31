using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWordConversionRepository;

namespace NumToWordConversionApiAppTests
{
    [TestClass]
    public class NumberToWordConvertorTest
    {

        [TestMethod]
        public void NegativeZeroNumberTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(-00000);
            Assert.AreEqual("Zero Only", result);
        }

        [TestMethod]
        public void ZeroNumberTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(0000);
            Assert.AreEqual("Zero Only", result);
        }

        [TestMethod]
        public void NegativeSingleDigitNumberTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(-8);
            Assert.AreEqual("Minus Eight Only", result);
        }

        [TestMethod]
        public void NegativeDecimalNumberTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(-8.87);
            Assert.AreEqual("Minus Eight And Eighty Seven Cents Only", result);
        }

        [TestMethod]
        public void TwoDigitNumberTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(12);
            Assert.AreEqual("Twelve Only", result);
        }

        [TestMethod]
        public void TwoDigitNumberWithZeroDecimalValueTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(12.000);
            Assert.AreEqual("Twelve Only", result);
        }

        [TestMethod]
        public void HunderedPlaceTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(120);
            Assert.AreEqual("One Hundred Twenty Only", result);
        }

        [TestMethod]
        public void HunderedPlaceWithDecimalValueTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(120.9876);
            Assert.AreEqual("One Hundred Twenty And Nine Thousand Eight Hundred Seventy Six Cents Only", result);
        }

        [TestMethod]
        public void ThousandPlaceTest1()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(1209);
            Assert.AreEqual("One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void ThousandPlaceTest2()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(61209);
            Assert.AreEqual("Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void ThousandPlaceTest3()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(961209);
            Assert.AreEqual("Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void MillionsPlaceTest1()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(1961209);
            Assert.AreEqual("One Million Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void MillionsPlaceTest2()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(81961209);
            Assert.AreEqual("Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void MillionsPlaceTest3()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(381961209);
            Assert.AreEqual("Three Hundred Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void MillionsPlaceWithDecimalTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(381961209.008);
            Assert.AreEqual("Three Hundred Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine And Eight Cents Only", result);
        }

        [TestMethod]
        public void BillionsPlaceTest1()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(2381961209);
            Assert.AreEqual("Two Billion Three Hundred Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void BillionsPlaceTest2()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(52381961209);
            Assert.AreEqual("Fifty Two Billion Three Hundred Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void BillionsPlaceTest3()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(752381961209);
            Assert.AreEqual("Seven Hundred Fifty Two Billion Three Hundred Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine Only", result);
        }

        [TestMethod]
        public void BillionsPlaceWithDecimalValueTest()
        {
            NumberToWordConvertor numConvertor = new NumberToWordConvertor();
            string result = numConvertor.ConvertNumberToWordFormat(752381961209.12);
            Assert.AreEqual("Seven Hundred Fifty Two Billion Three Hundred Eighty One Million Nine Hundred Sixty One Thousand Two Hundred Nine And Twelve Cents Only", result);
        }
    }
}
