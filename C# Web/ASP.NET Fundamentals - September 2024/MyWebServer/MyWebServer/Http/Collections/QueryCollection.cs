using System.Collections;

namespace MyWebServer.Http.Collections
{
    public class QueryCollection : IEnumerable<string>
    {
        private readonly Dictionary<string, string> query;

        public QueryCollection()
            => this.query = new(StringComparer.InvariantCultureIgnoreCase);

        public string this[string name]
            => this.query[name];

        public void Add(string name, string value)
            => this.query[name] = value;

        public bool ContainsKey(string name)
            => this.query.ContainsKey(name);

        public string GetValueOrDefault(string key)
             => this.query.GetValueOrDefault(key);

        public IEnumerator<string> GetEnumerator()
            => query.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}