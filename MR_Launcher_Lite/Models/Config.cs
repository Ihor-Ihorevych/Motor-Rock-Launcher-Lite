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
        #endregion
        #region Init
        public Config()
        {
            _gameLocation = string.Empty;
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
