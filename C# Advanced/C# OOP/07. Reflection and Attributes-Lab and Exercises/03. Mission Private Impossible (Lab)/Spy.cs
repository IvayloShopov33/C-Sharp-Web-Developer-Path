using System.Text;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfTheInvestigatedClass, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            Type typeOfTheInvestigatedClass = Type.GetType(nameOfTheInvestigatedClass);
            FieldInfo[] classFields = typeOfTheInvestigatedClass.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            var instance = Activator.CreateInstance(typeOfTheInvestigatedClass);

            sb.AppendLine($"Class under investigation: {typeOfTheInvestigatedClass.FullName}");
            List<string> requestedFields = fields.ToList();

            foreach (FieldInfo field in classFields.Where(x => requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type typeOfTheInvestigatedClass = Type.GetType("Stealer." + className);

            FieldInfo[] fields = typeOfTheInvestigatedClass.GetFields(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = typeOfTheInvestigatedClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] publicMethods = typeOfTheInvestigatedClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo nonPublicMethod in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
            }

            foreach (MethodInfo publicMethod in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethod.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type typeOfInvestigatedClass = Type.GetType(className);
            MethodInfo[] privateMethods = typeOfInvestigatedClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {typeOfInvestigatedClass.FullName}");
            sb.AppendLine($"Base Class: {typeOfInvestigatedClass.BaseType.Name}");

            foreach (MethodInfo privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
