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
using BE;
using SearchFiles;

namespace CRUD_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GatewayFacade dg = new GatewayFacade();
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void createBtn_Click(object sender, RoutedEventArgs e)
        {
            int mgrssn;
            try
            {
                mgrssn = Convert.ToInt32(MgrSSNTxtBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a ManagerSSN!");
                return;
            }

            string name;

            if (NameTxtBox.Text != "")
            {
                name = NameTxtBox.Text;
                Department dep = new Department(name, -1, -1);
                dep.MgrSSN = mgrssn;
                try
                {
                    var succesfull = await dg.CreateDepartment(dep);
                    if (!succesfull)
                    {
                        throw new Exception("ManagerSSN already assigned to a department.");
                    }
                    else
                    {
                        GetAll();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please enter a name!");
                return;
            }
        }

        private async void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(SearchTxtbox.Text);
                await dg.DeleteDepartment(id);
                GetAll();
            }
            catch
            {
                MessageBox.Show("Please enter an ID!");
            }            
        }

        private async void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(SearchTxtbox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter an ID!");
                return;
            }

            string name;

            if (NameTxtBox.Text != "")
            {
                name = NameTxtBox.Text;
                Department dep = new Department(name, id, -1);
                await dg.UpdateDepartment(dep);
                GetAll();
            }
            else
            {
                MessageBox.Show("Please enter a name!");
                return;
            }
        }

        private async void getBtn_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(SearchTxtbox.Text);
                Department dep = await dg.GetDepartment(id);
                List<Department> lst = new List<Department>();
                lst.Add(dep);
                setList(lst);
            }
            catch
            {
                GetAll();
            }
        }


        private void ListView_Initialized(object sender, EventArgs e)
        {
            GetAll();
        }

        private void setList(List<Department> lst)
        {
            Mainlst.Items.Clear();

            foreach (Department d in lst)
            {
                Mainlst.Items.Add(d);
            }
        }

        private void GetAll()
        {
            DepartmentServiceGateway dg = new DepartmentServiceGateway();
            List<Department> lst = dg.GetAllDepartments();
            setList(lst);
        }
    }
}
