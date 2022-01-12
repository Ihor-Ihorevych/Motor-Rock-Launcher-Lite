using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MR_Launcher_Lite.Models
{
    public class Mod
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public List<string> AudioPacks { get; set; }
        public List<string> GameModes { get; set; }
        public Mod(string name, string description, string path)
        {
            Name = name;
            Description = description;
            Path = path;
            AudioPacks = new() { "None" };
            GameModes = new() { "None" };
        }
    }
}
