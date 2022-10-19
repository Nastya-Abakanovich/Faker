namespace FakerLibrary
{
    public class Faker
    {
        private Random rnd;
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        // Может быть вызван изнутри Faker, из IValueGenerator (см. ниже) или пользователем
        public object Create(Type t)
        {
            if (rnd == null)
            {
                rnd = new Random();
            }
            string stringSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            if (t == typeof(int))
            {
                return rnd.Next(int.MinValue, int.MaxValue);
            }
            else if (t == typeof(long))
            {
                return rnd.NextInt64(long.MinValue, long.MaxValue);
            }
            else if (t == typeof(bool))
            {
                if (rnd.Next(2) == 1)
                    return true;
                else
                    return false;
            }
            else if (t == typeof(double))
            {
                return rnd.NextDouble() + rnd.Next(-1000, 1001);
            }
            else if (t == typeof(float))
            {
                return (float)rnd.NextDouble() + rnd.Next(-1000, 1001);
            }
            else if (t == typeof(DateTime))
            {
                DateTime start = new DateTime(1950, 1, 1);
                return start.AddSeconds(rnd.NextInt64((long)(DateTime.Today - start).TotalSeconds));
            }
            else if (t == typeof(string))
            {
                var length = rnd.Next(5, 31);
                var randomStr = new string(Enumerable.Repeat(stringSymbols, length)
                    .Select(s => s[rnd.Next(s.Length)]).ToArray());
                return randomStr;
            }
            else if (t == typeof(char))
            {
                return stringSymbols[rnd.Next(stringSymbols.Length)];
            }
            else if (t == typeof(byte))
            {
                return (byte) rnd.Next(byte.MaxValue + 1);
            }
            else if (t == typeof(sbyte))
            {
                return (sbyte)rnd.Next(sbyte.MinValue, sbyte.MaxValue + 1);
            }
            else if (t == typeof(short))
            {
                return (short)rnd.Next(short.MinValue, short.MaxValue + 1);
            }
            else if (t == typeof(ushort))
            {
                return (ushort)rnd.Next(ushort.MaxValue + 1);
            }
            else if (t == typeof(uint))
            {
                return (uint)rnd.Next(int.MaxValue);
            }
            else if (t == typeof(ulong))
            {
                return (ulong)rnd.NextInt64(long.MaxValue);
            }
            else
            {
                return null;
            }

            // Процедура создания и инициализации объекта.
        }

        private static object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                // Для типов-значений вызов конструктора по умолчанию даст default(T).
                return Activator.CreateInstance(t);
            else
                // Для ссылочных типов значение по умолчанию всегда null.
                return null;
        }


    }
}