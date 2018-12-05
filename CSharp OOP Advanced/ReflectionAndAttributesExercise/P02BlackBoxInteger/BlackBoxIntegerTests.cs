namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var box = (BlackBoxInteger)Activator.CreateInstance(type, true);

            string input = Console.ReadLine();

            while (input != "END")
            {
                var command = input.Split("_")[0];
                var value = int.Parse(input.Split("_")[1]);

                MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(m => m.Name == command);

                method.Invoke(box, new object[] { value });

                var result = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.Name == "innerValue")
                    .GetValue(box);

                Console.WriteLine(result);

                input = Console.ReadLine();
            }
        }
    }
}
