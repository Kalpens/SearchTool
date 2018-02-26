using ClassLibrary1;
using System;
using System.Collections.Generic;
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

namespace SearchFiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var stackLayout = new StackPanel();
            stackLayout.Orientation = Orientation.Vertical;
            var dataSearch = new DataSearch();
            var crawler = new Crawler();
            List<Word> list;
            if (chbxIsAsync.IsChecked != null && chbxIsAsync.IsChecked.Value)
            {
                list = await dataSearch.GetListOfInts();
            }
            else
            {
                list = dataSearch.GetListOfIntsSync();
            }
            foreach (var item in list)
            {
                stackLayout.Children.Add(new TextBlock() { Text = item.Value });
            }
            ScrlViewDisplayResults.Content = stackLayout;
        }

        private void btnCrawl_Click(object sender, RoutedEventArgs e)
        {
            var dataSearch = new DataSearch();
            dataSearch.AddCrawledToDb();
        }
    }
}
