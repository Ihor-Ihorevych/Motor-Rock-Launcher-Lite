using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MR_Launcher_Lite.Models
{
    public class ModsService : INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<Mod> _mods;
        #endregion
        #region Properties
        public ObservableCollection<Mod> Mods
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
        public ModsService()
        {
            _mods = new();  
        }
        #endregion
        #region Methods
        public async Task<bool> Scan_Folders(string location)
        {
            try
            {
                location = location.Substring(0, location.Length - 6);
                var mods_location = $"{location}/Launcher_Data/Mods/";
                string? all_mods_inner = await System.IO.File.ReadAllTextAsync(mods_location + "all_mods.txt");
                string[] mods_paths = all_mods_inner.Split(';');
                if(mods_paths.Length > 0)
                {
                    foreach (var mod_path in mods_paths)
                    {
                        string mod_location = mods_location + mod_path;
                        async Task<string[]> getDataFromTextFile(string file)
                        {
                            var inner = await System.IO.File.ReadAllTextAsync(mod_location + $"/{file}");
                            return inner.Split(';');
                        }

                        // Read mod description
                        string[] mod_info = getDataFromTextFile("desc.txt").Result;
                        var (mod_name, mod_desc) = (mod_info[0], mod_info[1]);
                        Mod mod = new(mod_name, mod_desc, mod_path);

                        // Read mod's audiopacks
                        string[] mp3_info = getDataFromTextFile("mp3.txt").Result;
                        if(mp3_info.Any() && mp3_info[0] != "")
                        {
                            mod.AudioPacks.Clear();
                            foreach(var mp3_track in mp3_info)
                            {
                                mod.AudioPacks.Add(mp3_track);
                            }
                        }

                        // Read mod's gameplay configs
                        string[] config_info = getDataFromTextFile("gamemodes.txt").Result;                        
                        if(config_info.Any() && config_info[0] != "")
                        {
                            mod.GameModes.Clear();
                            foreach(var config in config_info)
                            {
                                mod.GameModes.Add(config);
                            }
                        }
                        Mods.Add(mod);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
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
