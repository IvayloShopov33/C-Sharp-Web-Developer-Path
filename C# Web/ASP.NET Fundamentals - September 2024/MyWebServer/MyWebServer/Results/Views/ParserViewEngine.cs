using System.Collections;
using System.Text;

using MyWebServer.Results.Views.Contracts;

namespace MyWebServer.Results.Views
{
    public class ParserViewEngine : IViewEngine
    {
        public string RenderHtml(string viewContent, object model, string user)
        {
            var result = new StringBuilder();

            if (model is not IEnumerable)
            {
                result.AppendLine(PopulateModelProperties(viewContent, "Model", model));
            }

            var lines = viewContent
                .Split(Environment.NewLine)
                .Select(l => l.Trim());

            var inLoop = false;
            var loopModelName = string.Empty;
            StringBuilder loopContent = null;

            foreach (var line in lines)
            {
                if (line.StartsWith("@foreach"))
                {
                    if (model is not IEnumerable)
                    {
                        throw new InvalidOperationException("Model is not a collection.");
                    }

                    inLoop = true;
                    loopModelName = line
                        .Split()
                        .SkipWhile(l => l.Contains("var"))
                        .Skip(2)
                        .FirstOrDefault();

                    if (loopModelName == null)
                    {
                        throw new InvalidOperationException("The foreach statement is not a collection.");
                    }

                    continue;
                }

                if (inLoop)
                {
                    if (line.StartsWith("{"))
                    {
                        loopContent = new StringBuilder();
                    }
                    else if (line.StartsWith("}"))
                    {
                        var loopTemplate = loopContent.ToString();
                        foreach (var item in (IEnumerable)model)
                        {
                            var loopResult = PopulateModelProperties(loopTemplate, loopModelName, item);

                            result.AppendLine(loopResult);
                        }

                        inLoop = false;
                    }
                    else
                    {
                        loopContent.AppendLine(line);
                    }

                    continue;
                }

                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }

        private static string PopulateModelProperties(string viewContent, string modelName, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new
                {
                    Name = pr.Name,
                    Value = pr.GetValue(model)
                });

            foreach (var entry in data)
            {
                viewContent = viewContent.Replace($"@{modelName}.{entry.Name}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}