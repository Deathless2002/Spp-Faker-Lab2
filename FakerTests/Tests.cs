using FakerLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
namespace FakerTests
{
    public class Tests
    {
        private readonly IFaker _faker;

        public Tests()
        {
            _faker=new Faker();
            try
            {
                var asm1 = Assembly.LoadFrom("../../../../Plugins/DateTimeGenerator.dll");
                var type1 = asm1.GetType("FakerLib.Generators.DateTimeGenerator");
                var asm2 = Assembly.LoadFrom("../../../../Plugins/ListGenerator.dll");
                var type2 = asm2.GetType("FakerLib.Generators.ListGenerator");
                if (type1 != null)
                {
                    var generator = (IGenerator?)Activator.CreateInstance(type1);
                    _faker.AddGenerator(new KeyValuePair<Type, IGenerator>(typeof(DateTime), generator));
                }
                if (type2 != null)
                {
                    var generator = (IGenerator?)Activator.CreateInstance(type2);
                    _faker.AddGenerator(new KeyValuePair<Type, IGenerator>(typeof(List<>), generator));
                }
            }
            catch
            {
                Environment.Exit(1);
            }
        }

        [Fact]
        public void DefaultTypeTests()
        {
            Assert.True(_faker.Create<bool>());
            Assert.NotEqual(default(byte), _faker.Create<byte>());
            Assert.NotEqual(default(char), _faker.Create<char>());
            Assert.NotEqual(default(DateTime), _faker.Create<DateTime>());
            Assert.NotEqual(default(decimal), _faker.Create<decimal>());
            Assert.NotEqual(default(double), _faker.Create<double>());
            Assert.NotEqual(default(float), _faker.Create<float>());
            Assert.NotEqual(default(int), _faker.Create<int>());
            Assert.NotEqual(default(long), _faker.Create<long>());
            Assert.NotEqual(default(short), _faker.Create<short>());
            Assert.NotEqual(default(string), _faker.Create<string>());
            Assert.NotEqual(default(List<string>), _faker.Create<List<string>>());
        }

        [Fact]
        public void ListTest()
        {
            var list = _faker.Create<List<List<List<int>>>>();
            Assert.InRange(list.Count, 1, 10);
            foreach (var item in list)
            {
                Assert.InRange(item.Count, 1, 10);
                foreach (var item2 in item)
                {
                    Assert.InRange(item2.Count, 1, 10);
                    foreach (var item3 in item2)
                        Assert.NotEqual(default(int), item3);
                }
            }
            Assert.NotEqual(default, list[0][0][0]);
        }

        [Fact]
        public void DateTimeTest()
        {
            DateTime dateTime = _faker.Create<DateTime>();
            Assert.InRange(dateTime.Year, 1, 2100);
            Assert.InRange(dateTime.Month, 1, 13);
            Assert.InRange(dateTime.Day, 1, 29);
            Assert.InRange(dateTime.Hour, 0, 24);
            Assert.InRange(dateTime.Minute, 0, 60);
            Assert.InRange(dateTime.Second, 0, 60);
            Assert.InRange(dateTime.Millisecond, 0, 1000);
        }

        [Fact]
        public void SimpleClassTest()
        {
            SimpleUserClass simpleObject = _faker.Create<SimpleUserClass>();
            Assert.NotEqual(ObjectCreator.GetDefaultValue(simpleObject.nullField.GetType()), simpleObject.nullField);
            Assert.Equal(-1, simpleObject.field);
            Assert.NotEqual(ObjectCreator.GetDefaultValue(simpleObject.nullProperty.GetType()), simpleObject.nullProperty);
            Assert.Equal(-2, simpleObject.property);
        }

        [Fact]
        public void ConstructorTest()
        {
            SeveralConstructorClass multiObj = _faker.Create<SeveralConstructorClass>();
            List<int> sums = multiObj.GetSum();
            Assert.Equal(default, sums[0]);
            Assert.Equal(default, sums[1]);
            Assert.Equal(default, sums[2]);
            Assert.NotEqual(default, sums[3]);
            Assert.Equal(default, sums[4]);
        }

        [Fact]
        public void RecursiveClassTest()
        {
            RecursiveClass recursive = _faker.Create<RecursiveClass>();
            Assert.NotNull(recursive);
            Assert.NotNull(recursive.recursive);
            Assert.NotEqual(default, recursive.number);
            if (recursive.recursive != null)
            {
                Assert.Null(recursive.recursive.recursive);
                Assert.NotEqual(default(int), recursive.recursive.number);
            }
        }

        [Fact]
        public void NoConstructorTest()
        {
            var ex = Assert.Throws<FakerException>(() => _faker.Create<PrivateClass>());
        }

        [Fact]
        public void ÑodependencyTest()
        {
            Ñodependency a = _faker.Create<Ñodependency>();
            if (a != null && a.b != null && a.b.a != null)
            {
                Assert.NotNull(a.b.a.b);
                if (a.b.a.b != null) Assert.Null(a.b.a.b.a);
            }
            else Assert.Equal(1, 2);
        }

        [Fact]
        public void NotDTO()
        {
            Ñodependency a = _faker.Create<Ñodependency>();
            if (a != null && a.b != null && a.b.a != null)
            {
                Assert.NotNull(a.b.a.b);
                if (a.b.a.b != null) Assert.Null(a.b.a.b.a);
            }
            else Assert.Equal(1, 2);
        }
    }
}