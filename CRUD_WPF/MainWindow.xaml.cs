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
using System.Xml.Xsl;
using ClassLibrary1;
using SearchFiles;

namespace CRUD_WPF
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


        private void createBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void getBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ListView_Initialized(object sender, EventArgs e)
        {
            DepartmentServiceGateway dg = new DepartmentServiceGateway();
            List<Department> lst = dg.GetAllDepartments();
            foreach (Department d in lst)
            {
                Mainlst.Items.Add(d);
            }
        }
    }
}
