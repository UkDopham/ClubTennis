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

namespace ClubTennis.Views
{
    /// <summary>
    /// Logique d'interaction pour CreationEmployeeUserControl.xaml
    /// </summary>
    public partial class CreationEmployeeUserControl : UserControl
    {
        private ComboBox _trainerComboBox;
        private Grid _mainGrid;
        private bool _isTrainer;
        private bool _isStarted;
        private Employee _employee;
        private Guid _guid;

        public Guid Guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
            }
        }

        public Employee Employee
        {
            get
            {
                return this._employee;
            }
        }
        public bool IsTrainer
        {
            get
            {
                return this._isTrainer;
            }
        }
        public CreationEmployeeUserControl()
        {
            this._isStarted = false;
            InitializeComponent();
            this._mainGrid = MainGrid;
            this._isTrainer = false;
        }

        public CreationEmployeeUserControl(Employee employee)
        {
            this._guid = employee.Guid;
            this._employee = employee;
            this._isStarted = false;
            InitializeComponent();
            this._mainGrid = MainGrid;
            PrenomTextBox.Text = employee.FirstName;
            NomTextBox.Text = employee.LastName;
            PhoneTextBox.Text = employee.PhoneNumber;
            GenreComboBox.SelectedIndex = Convert.ToInt32(employee.Gender) - 1;
            AdressTextBox.Text = employee.Adress;
            SalaryTextBox.Text = employee.Salary.ToString();
            IBANTextBox.Text = employee.BankDetails.Iban;
            RIBTextBox.Text = employee.BankDetails.Rib;
            EntryDatePicker.SelectedDate = employee.EntryDate;
            this._isTrainer = employee.GetType() == PostEnum.Trainer;

            if (this._isTrainer)
            {
                JobComboBox.SelectedIndex = 0;
                this._trainerComboBox.SelectedIndex = Convert.ToInt32(((Trainer)employee).Position);
                CreateNewGrid();
            }
            else
            {
                JobComboBox.SelectedIndex = 1;
            }
        }

        public bool IsAllFill()
        {
            return !string.IsNullOrEmpty(PrenomTextBox.Text) &&
                !string.IsNullOrEmpty(NomTextBox.Text) &&
                !string.IsNullOrEmpty(PhoneTextBox.Text) &&
                !string.IsNullOrEmpty(AdressTextBox.Text) &&
                !string.IsNullOrEmpty(SalaryTextBox.Text) &&
                !string.IsNullOrEmpty(IBANTextBox.Text) &&
                !string.IsNullOrEmpty(RIBTextBox.Text) &&
                EntryDatePicker.SelectedDate != null;
        }
        public Employee GetEmployee()
        {
            if (Guid.Equals(this._guid, Guid.Empty))
            {
                if (this._isTrainer)
                {
                    return new Trainer(
                    PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                    (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                    AdressTextBox.Text,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate,
                    (TrainerPositionEnum)this._trainerComboBox.SelectedIndex);
                }
                else
                {
                    return new Administration(
                    PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                    (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                    AdressTextBox.Text,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate);
                }
            }
            else
            {
                if (this._isTrainer)
                {
                    return new Trainer(
                    PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                    (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                    AdressTextBox.Text,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate,
                    (TrainerPositionEnum)this._trainerComboBox.SelectedIndex,
                    this._guid);
                }
                else
                {
                    return new Administration(
                    PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                    (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                    AdressTextBox.Text,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate,
                    this._guid);
                }
            }
        }
        private void CreateNewGrid()
        {
            this._isTrainer = true;
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            Grid grid = new Grid()
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                    }
            };

            TextBlock text = new TextBlock()
            {
                Text = "Statut",
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            ComboBox comboBox = new ComboBox()
            {
                Margin = new Thickness(10),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                ItemsSource = new List<string>() { "Indépendant", "Salarié" },
                SelectedIndex = 0
            };

            this._trainerComboBox = comboBox;

            grid.Children.Add(text);
            grid.Children.Add(comboBox);

            Grid.SetColumn(text, 0);
            Grid.SetColumn(comboBox, 1);

            MainGrid.Children.Add(grid);
            Grid.SetRow(grid, 9);
        }
        private void JobComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 0 trainer /1 administration
            if (JobComboBox.SelectedIndex == 0)
            {
                CreateNewGrid();
            }
            else
            {
                this._isTrainer = false;
                if (this._isStarted) //Pour eviter le null exception lors de l'initialisation
                {
                    MainGrid = this._mainGrid;
                }
                else
                {
                    this._isStarted = true;
                }
            }
        }
    }
}
