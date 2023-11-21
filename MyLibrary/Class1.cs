using MyAttribute;

namespace MyLibrary
{
   public class Foo
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("M1()");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a)
        {
            Console.WriteLine($"M2() {nameof(a)}={a}");
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string first, string second)
        {
            Console.WriteLine($"M3() {nameof(first)} = {first}, {nameof(second)} = {second}");
        }
    }
}