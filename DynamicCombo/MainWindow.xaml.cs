using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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

namespace DynamicCombo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ComboViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button Clicked {ComboViewModel._profileName}");
        }

        private void Load_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button Clicked {ComboViewModel._selectedName}");
        }
        private void Remove_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button Clicked {ComboViewModel._selectedName}");
        }
        private void Rename_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button Clicked {ComboViewModel._selectedName}");
        }

        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button Clicked Refresh");
            List<Person> pl = new List<Person>();
            pl.Add(new Person(5, "E"));
            pl.Add(new Person(6, "So"));
            pl.Add(new Person(7, "Md"));
            pl.Add(new Person(8, "Af"));

            ComboViewModel cvm = this.DataContext as ComboViewModel;
            
            cvm.People = new ObservableCollection<Person>(pl);
            
        }

        private void GenerateControl_Clicked(object sender, RoutedEventArgs e)
        {
            MainStacPanel.Children.Add(prepareControls());
        }

        private Grid prepareControls()
        {

            Grid grid = new Grid();
            grid.Margin = new Thickness(10, 5, 10, 5);
            ColumnDefinition cd0 = new ColumnDefinition();
            cd0.Width = new GridLength(1, GridUnitType.Star);

            ColumnDefinition cd1 = new ColumnDefinition();
            cd1.Width = new GridLength(1, GridUnitType.Star);

            grid.ColumnDefinitions.Add(cd0);
            grid.ColumnDefinitions.Add(cd1);

            
            ComboBox comboBox = new ComboBox();
            comboBox.Margin = new Thickness(0, 0, 5, 0) ;
            Grid.SetColumn(comboBox, 0);

            ComboBoxItem comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = "hello";


            comboBox.Items.Add(comboBoxItem);
            comboBox.Name = "combo";

            TextBox tb = new TextBox();
            tb.Margin = new Thickness(5, 0, 0, 0);
            Grid.SetColumn(tb, 1);

            grid.Children.Add(comboBox);
            grid.Children.Add(tb);

            return grid;
        }
    }
}
