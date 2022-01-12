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
    public class UnitOfWork : INotifyPropertyChanged
    {
        #region Fields
        private Config _config;
        private ModsService _modsService;
        #endregion
        #region Properties
        public Config Config
        {
            get => _config;
            set
            {
                _config = value;
                OnPropertyChanged(nameof(Config));
            }
        }
        public ModsService ModsService
        {
            get => _modsService;
            set
            {
                _modsService = value;
                OnPropertyChanged(nameof(ModsService));
            }
        }
        
        #endregion
        #region Init
        public UnitOfWork()
        {
            _config = new();
            _modsService = new();
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
