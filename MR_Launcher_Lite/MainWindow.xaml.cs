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
        private Models.Config _config;
        private string _selectedModVersion;
        #endregion
        #region Properties
        public Models.Config Config
        {
            get { return _config; }
            set
            {
                _config = value;
                OnPropertyChanged(nameof(Config));
            }
        }
        public string SelectedModVersion
        {
            get => _selectedModVersion;
            set
            {
                _selectedModVersion = value;
                OnPropertyChanged(nameof(SelectedModVersion));
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
            _config = new();
            _selectedModVersion = string.Empty;

            // Trying to load config
            var isLoaded = await Config.Load();
            if (!isLoaded)
            {
                MessageBox.Show("Error while reading config, overwriting");
                Config.Save();
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
                    Config.GameLocation = fileDialog.FileName;
                    Config.Save();
                }
                else
                {
                    MessageBox.Show("Wrong file!");
                }
            }
        }
        private void Install_Selected_Mod_Click(object sender, EventArgs e)
        {
            if(SelectedModVersion == string.Empty)
            {
                MessageBox.Show("Choose mod version first");
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
