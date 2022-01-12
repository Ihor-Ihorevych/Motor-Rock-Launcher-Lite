using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace MR_Launcher_Lite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Fields
        private Models.UnitOfWork _unitOfWork;
        private Models.Mod _selectedMod;
        #endregion
        #region Properties
        public Models.UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
            set
            {
                _unitOfWork = value;
                OnPropertyChanged(nameof(UnitOfWork));
            }
        }
        public Models.Mod SelectedMod
        {
            get => _selectedMod;
            set
            {
                _selectedMod = value;
                OnPropertyChanged(nameof(SelectedMod));
            }
        }
        #endregion
        #region Window init
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private async void Init()
        {
            // Setting context
            DataContext = this;

            // Setting fields
            UnitOfWork = new();

            // Trying to load config
            var isLoaded = await UnitOfWork.Config.Load();
            if (!isLoaded)
            {
                MessageBox.Show("Error while reading config, overwriting");
                UnitOfWork.Config.Save();
            }
        }
        #endregion
        #region Controls clicks
        private void Locate_Game_Folder_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Motor Rock executable|*.exe",
                Title = "Choose Motor Rock executable file"
            };
            if (fileDialog.ShowDialog() == true)
            {
                if(fileDialog.SafeFileName.ToLower() == "mr.exe")
                {
                    UnitOfWork.Config.GameLocation = fileDialog.FileName;
                    UnitOfWork.Config.Save();
                }
                else
                {
                    MessageBox.Show("Wrong file!");
                }
            }
        }
        private void Install_Selected_Mod_Click(object sender, EventArgs e)
        {
            if(SelectedMod == null)
            {
                MessageBox.Show("Choose mod version first");
            }
        }
        private async void Scan_Mods_Click(object sender, EventArgs e)
        {
            var gameLocation = UnitOfWork.Config.GameLocation;
            var anyMods = await UnitOfWork.ModsService.Scan_Folders(gameLocation);
            if(!anyMods)
            {
                MessageBox.Show("Problem with loading mods");
            }
            else
            {
                SelectedMod = UnitOfWork.ModsService.Mods[0];
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
