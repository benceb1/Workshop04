using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Workshop04.Models;

namespace Workshop04
{
    public class JsonWriteRead
    {
        public void JsonWrite(List<Hero> heroes)
        {
            string fileName = "herolist.json";
            string jsonString = JsonSerializer.Serialize(heroes);
            File.WriteAllText(fileName, jsonString);
        }
        public List<Hero> JsonRead()
        {
            string fileName = "herolist.json";
            string jsonString = File.ReadAllText(fileName);
            List<Hero> heroes = JsonSerializer.Deserialize<List<Hero>>(jsonString);
            return heroes;
        }
    }
}
