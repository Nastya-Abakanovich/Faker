using FakerLibrary;

namespace ExampleOfUse
{
    internal class Program
    {
        static void Main()
        {
            var faker = new Faker();
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("sbyte: {0}", faker.Create<sbyte>());
                Console.WriteLine("byte: {0}", faker.Create<byte>());
                Console.WriteLine("int: {0}", faker.Create<int>());
                Console.WriteLine("uint: {0}", faker.Create<uint>());
                Console.WriteLine("long: {0}", faker.Create<long>());
                Console.WriteLine("ulong: {0}", faker.Create<ulong>());
                Console.WriteLine("short: {0}", faker.Create<short>());
                Console.WriteLine("ushort: {0}", faker.Create<ushort>());
                Console.WriteLine("double: {0}", faker.Create<double>());
                Console.WriteLine("float: {0}", faker.Create<float>());
                Console.WriteLine("DateTime: {0}", faker.Create<DateTime>().ToString());
                Console.WriteLine("string: {0}", faker.Create<string>());
                Console.WriteLine("char: {0}", faker.Create<char>());
                Console.WriteLine("bool: {0}", faker.Create<bool>());
                Console.WriteLine();
            }
        }
    }
}