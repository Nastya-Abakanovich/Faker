namespace Test
{
    public class TestGenerators
    {
        private Faker _faker;

        [OneTimeSetUp]
        public void Setup()
        {
            _faker = new Faker();
        }

        [Test]
        public void BoolGenerator_Value_ReturnsRandomValue()
        {
            int counter = 0;
            for (int i = 0; i < 50; i++)
            {
                if(_faker.Create<bool>() != false)
                    counter++;
            }

            Assert.NotZero(counter, "BoolGenerator doesn't work.");
            Assert.AreNotEqual(counter, 50, "BoolGenerator doesn't work.");
        }

        [Test]
        public void ByteGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<byte>(), _faker.Create<byte>(), "ByteGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<byte>(), _faker.Create<byte>(), "ByteGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<byte>(), _faker.Create<byte>(), "ByteGenerator doesn't work. Test 3.");
        }

        [Test]
        public void CharGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<char>(), _faker.Create<char>(), "CharGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<char>(), _faker.Create<char>(), "CharGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<char>(), _faker.Create<char>(), "CharGenerator doesn't work. Test 3.");
        }

        [Test]
        public void DateTimeGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<DateTime>(), _faker.Create<DateTime>(), "DateTimeGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<DateTime>(), _faker.Create<DateTime>(), "DateTimeGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<DateTime>(), _faker.Create<DateTime>(), "DateTimeGenerator doesn't work. Test 3.");
        }

        [Test]
        public void DoubleGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<double>(), _faker.Create<double>(), "DoubleGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<double>(), _faker.Create<double>(), "DoubleGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<double>(), _faker.Create<double>(), "DoubleGenerator doesn't work. Test 3.");
        }

        [Test]
        public void FloatGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<float>(), _faker.Create<float>(), "FloatGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<float>(), _faker.Create<float>(), "FloatGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<float>(), _faker.Create<float>(), "FloatGenerator doesn't work. Test 3.");
        }

        [Test]
        public void IntGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<int>(), _faker.Create<int>(), "IntGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<int>(), _faker.Create<int>(), "IntGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<int>(), _faker.Create<int>(), "IntGenerator doesn't work. Test 3.");
        }

        [Test]
        public void LongGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<long>(), _faker.Create<long>(), "LongGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<long>(), _faker.Create<long>(), "LongGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<long>(), _faker.Create<long>(), "LongGenerator doesn't work. Test 3.");
        }
        [Test]
        public void SbyteGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<sbyte>(), _faker.Create<sbyte>(), "SbyteGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<sbyte>(), _faker.Create<sbyte>(), "SbyteGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<sbyte>(), _faker.Create<sbyte>(), "SbyteGenerator doesn't work. Test 3.");
        }

        [Test]
        public void ShortGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<short>(), _faker.Create<short>(), "ShortGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<short>(), _faker.Create<short>(), "ShortGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<short>(), _faker.Create<short>(), "ShortGenerator doesn't work. Test 3.");
        }

        [Test]
        public void UintGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<uint>(), _faker.Create<uint>(), "UintGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<uint>(), _faker.Create<uint>(), "UintGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<uint>(), _faker.Create<uint>(), "UintGenerator doesn't work. Test 3.");
        }

        [Test]
        public void UlongGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<ulong>(), _faker.Create<ulong>(), "UlongGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<ulong>(), _faker.Create<ulong>(), "UlongGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<ulong>(), _faker.Create<ulong>(), "UlongGenerator doesn't work. Test 3.");
        }

        [Test]
        public void UshortGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<ushort>(), _faker.Create<ushort>(), "UshortGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<ushort>(), _faker.Create<ushort>(), "UshortGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<ushort>(), _faker.Create<ushort>(), "UshortGenerator doesn't work. Test 3.");
        }

        [Test]
        public void StringGenerator_Value_ReturnsRandomValue()
        {
            Assert.AreNotEqual(_faker.Create<string>(), _faker.Create<string>(), "StringGenerator doesn't work. Test 1.");
            Assert.AreNotEqual(_faker.Create<string>(), _faker.Create<string>(), "StringGenerator doesn't work. Test 2.");
            Assert.AreNotEqual(_faker.Create<string>(), _faker.Create<string>(), "StringGenerator doesn't work. Test 3.");
        }

        [Test]
        public void ListGenerator_Value_ReturnsRandomValue()
        {
            List<int> listInt = _faker.Create<List<int>>();
            List<List<int>> listListInt = _faker.Create<List<List<int>>>();

            Assert.NotZero(listInt.Count, "ListGenerator doesn't work. ListInt.Count = 0.");
            Assert.NotZero(listListInt.Count, "ListGenerator doesn't work. ListListInt.Count = 0.");
            Assert.NotZero(listListInt[0].Count, "ListGenerator doesn't work. ListListInt[0].Count = 0.");

            Assert.AreNotEqual(listInt[0], listInt[1], "ListGenerator doesn't work. ListInt[0] == ListInt[1].");
            Assert.AreNotEqual(listListInt[0], listListInt[1], "ListGenerator doesn't work. ListListInt[0] == ListListInt[1].");
            Assert.AreNotEqual(listListInt[0][0], listListInt[0][1], "ListGenerator doesn't work. ListListInt[0][0] == ListListInt[0][1].");
        }

    }
}