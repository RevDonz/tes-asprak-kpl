
using Newtonsoft.Json;

namespace TesAsprak
{
    public class Book
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public int Page { get; set; }

        public Book(string name,  int page, string writer)
        {
            Name = name;
            Page = page;
            Writer = writer;
        }

        static public dynamic ReadData()
        {
            String path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            String jsonString = File.ReadAllText(path + "\\Tes Asprak\\KPL\\TesAsprak\\data.json");
            dynamic data = JsonConvert.DeserializeObject<List<Book>>(jsonString);

            return data;
        }
    }
}
