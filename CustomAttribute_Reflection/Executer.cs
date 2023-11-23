
using MyAttribute;
using System.Diagnostics;
using System.Reflection;

namespace CustomAttribute_Reflection
{
    public class Execute
    {
        public static void Main(string[] args)
        {
            Assembly? assembly;
            string assemblyName = "MyLibrary.dll";
            AssemblyNameControl(assemblyName);

            try
            {
                assembly = Assembly.LoadFrom($@"C:\Users\Kyura\source\repos\CustomAttribute_Reflection\MyLibrary\bin\Debug\net7.0\{assemblyName}");
            }
            catch (Exception e)
            {
                switch (e.HResult)
                {
                    case -2147024893:
                        throw new FileNotFoundException($"File not found", e.Message);

                    case -2147024891:
                        throw new FileLoadException($"Loading error", e.Message);
                }
                throw;
            }

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass) continue;

                foreach (var methodInfo in type.GetMethods())
                {
                    try
                    {
                        foreach (var target in methodInfo.GetCustomAttributes<ExecuteMe>())
                        {
                            MethodParamCtrl(methodInfo.GetParameters(), target.Arguments);
                            methodInfo.Invoke(Activator.CreateInstance(type), target.Arguments);
                        }
                    }
                    catch (MissingMethodException mme)
                    {
                        Console.WriteLine(
                            $"Instance '{type.FullName}' won't be considered. {mme.Message}");
                    }
                }
            }
            Console.ReadLine();
        }

        private static void MethodParamCtrl(ParameterInfo[] paramsInfos, object[]? actualParamsInfos)
        {
            if (actualParamsInfos == null) return;

            if (actualParamsInfos.Length != paramsInfos.Length)
                throw new TargetParameterCountException($"Custom Attribute of name '{nameof(ExecuteMe)}' permit {actualParamsInfos.Length} arguments " +
                                                        $"while method require {paramsInfos.Length}");

            for (var i = 0; i < actualParamsInfos.Length; i++)
            {
                if (actualParamsInfos[i].GetType() != paramsInfos[i].ParameterType)
                    throw new ArgumentException(
                        $"Cannot match '{actualParamsInfos[i].GetType()}' with '{paramsInfos[i].ParameterType}'");
            }
        }

        private static void AssemblyNameControl(string? assemblyName)
        {
            if (null == assemblyName)
                throw new ArgumentNullException($"{nameof(assemblyName)} cannot be {assemblyName}");

            if (String.Empty == assemblyName)
                throw new ArgumentException($"{nameof(assemblyName)} cannot be {nameof(String.Empty)}");
        }

    }
}

