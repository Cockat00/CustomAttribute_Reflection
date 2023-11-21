
using MyAttribute;
using System.Reflection;

namespace CustomAttribute_Reflection
{
    public class Execute
    {
        public static void Main(string[] args)
        {
            var attrAssembly = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in attrAssembly.GetTypes())
            {
                if (type.IsClass)
                {
                    foreach (var methodInfo in type.GetMethods())
                    {
                        var targets = methodInfo.GetCustomAttributes<ExecuteMe>();
                        foreach (var target in targets)
                        {
                            methodInfo.Invoke(Activator.CreateInstance(type), target.Arguments);
                        }
                    }
                }
            }
            Console.ReadLine();
        }

        public static string PrintParamType(ParameterInfo[] pars)
        {
            string paramType = "";
            foreach (var par in pars)
            {
                paramType += " " + par.ParameterType;
            }
            return paramType;
        }

    }
}

