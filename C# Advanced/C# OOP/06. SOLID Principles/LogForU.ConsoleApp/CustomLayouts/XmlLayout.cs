using LogForU.Core.Layouts.Interfaces;
using System.Text;

namespace LogForU.ConsoleApp.CustomLayouts
{
    public class XmlLayout : ILayout
    {
        public string Format
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("<log>");
                stringBuilder.AppendLine("  <date>{0}</date>");
                stringBuilder.AppendLine("  <level>{1}</level>");
                stringBuilder.AppendLine("  <message>{2}</message>");
                stringBuilder.AppendLine("</log>");

                return stringBuilder.ToString().TrimEnd();
            }
        }
    }
}
