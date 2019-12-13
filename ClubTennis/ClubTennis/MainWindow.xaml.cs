using ClubTennis.Models;
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

namespace ClubTennis
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Member john = new Member(
                "john",
                "Watson",
                "01",
                GenderEnum.man,
                "Washington DC",
                true);

            Employee marta = new Employee(
                "marta",
                "Dayson",
                "02",
                GenderEnum.woman,
                "Paris DC",
                new BankDetails("1", "2"),
                1230,
                DateTime.Now);

            List<People> list = new List<People>();

            list.Add(john);
            list.Add(marta);

            Data data = new Data();
            data.Peoples = list;
            data.WriteData();
        }
    }
}
