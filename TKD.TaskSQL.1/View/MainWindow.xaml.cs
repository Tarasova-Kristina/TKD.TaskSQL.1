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
using TKD.TaskSQL._1.Model;
using TKD.TaskSQL._1.View;

namespace TKD.TaskSQL._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestOneEntities _db = new TestOneEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(TbLogin.Text) ||
                    string.IsNullOrEmpty(PbPassword.Password) ||
                    string.IsNullOrEmpty(TbPhone.Text))


                {
                    MessageBox.Show($"Не все строки заполнены!");
                }
                else
                {
                    _db.User.Add(new Users()
                    {
                        login = TbLogin.Text,
                        password = PbPassword.Password,
                        phone = TbPhone.Text
                    }); ;
                    _db.SaveChanges();
                    MessageBox.Show($"Успех!");
                    TbLogin.Text = string.Empty;
                    PbPassword.Password = string.Empty;
                    TbPhone.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error 3");
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            new InfoWindow().ShowDialog();
        }
    }
}
