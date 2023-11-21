namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMe : Attribute
    {
        public object[] Arguments { get; set; }

        public ExecuteMe(params object[] args)
        {
            Arguments = args;
        }

        public void PrintArguments()
        {
            foreach (var argument in Arguments)
            {
                Console.Write(argument + " ");
            }
        }
    }
}