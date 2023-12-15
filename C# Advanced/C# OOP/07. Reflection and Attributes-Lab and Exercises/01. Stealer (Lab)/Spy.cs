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
    }
}
