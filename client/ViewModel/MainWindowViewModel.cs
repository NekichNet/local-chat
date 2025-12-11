using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using client.View;
using MaterialIcon = MahApps.Metro.IconPacks.PackIconMaterial;
using MaterialKind = MahApps.Metro.IconPacks.PackIconMaterialKind;

namespace client.ViewModel
{
    public class MainWindowViewModel 
    {
        public MainWindow View { get; set; }

        private List<Tuple<string, MaterialKind>> _themes = new List<Tuple<string, MaterialKind>> {
            new Tuple<string, MaterialKind>("Dark", MaterialKind.MoonWaxingCrescent),
            new Tuple<string, MaterialKind>("Light", MaterialKind.LightbulbOn)
        };
        private int _themeIndex = -1;

        public MainWindowViewModel(MainWindow mainWindow)
        {
            View = mainWindow;
        }

        public MaterialIcon ChangeTheme()
        {
            _themeIndex = _themes.Count - 1 == _themeIndex ? 0 : _themeIndex + 1;
            var baseUri = new Uri("View/Themes/Base.xaml", UriKind.RelativeOrAbsolute);
            var uri = new Uri("View/Themes/" + _themes[_themeIndex].Item1 + ".xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(baseUri) as ResourceDictionary);
            Application.Current.Resources.MergedDictionaries.Add(Application.LoadComponent(uri) as ResourceDictionary);
            return new MaterialIcon() { Kind = _themes[_themes.Count - 1 == _themeIndex ? 0 : _themeIndex + 1].Item2 };
        }
    }
}
