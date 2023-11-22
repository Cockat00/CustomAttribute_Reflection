namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class ExecuteMe : Attribute
    {
        private object[]? Val { get; } = new object[1];
        private object[]? Strings { get; } = new object[2];

        public object[]? Arguments { get; }
        
        public ExecuteMe() { }
        public ExecuteMe(string fst, string snd)
        {
            Strings[0] = fst;
            Strings[1] = snd;

            Arguments = Strings;
        }

        public ExecuteMe(int val)
        {
            Val[0] = val;

            Arguments = Val;
        }

        /*public object[] Arguments { get; set; }
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
        }*/
    }
}