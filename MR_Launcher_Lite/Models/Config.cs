using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace MR_Launcher_Lite.Models
{
    public class Config : INotifyPropertyChanged
    {
        #region Fields
        private string _gameLocation;
        private ObservableCollection<string> _mods;
        #endregion
        #region Properties
        public string GameLocation
        {
            get => _gameLocation;
            set
            {
                _gameLocation = value;
                OnPropertyChanged(nameof(GameLocation));
            }
        }
        public ObservableCollection<string> Mods
        {
            get => _mods;
            set
            {
                _mods = value;
                OnPropertyChanged(nameof(Mods));
            }
        }
        #endregion
        #region Init
        public Config()
        {
            _gameLocation = string.Empty;
            _mods = new() { "a", "b", "c"};
        }
        #endregion
        #region Methods
        public async void Save()
        {
            var serializedObject = JsonSerializer.Serialize(this);
            await File.WriteAllTextAsync("config.json", serializedObject);
        }
        public async Task<bool> Load()
        {
            try
            {
                string json = await File.ReadAllTextAsync("config.json");
                var deserializedObject = JsonSerializer.Deserialize<Config>(json);
                GameLocation = deserializedObject.GameLocation;
                Mods = deserializedObject.Mods;
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
