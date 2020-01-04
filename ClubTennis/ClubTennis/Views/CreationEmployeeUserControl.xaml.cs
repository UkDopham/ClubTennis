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
        private ComboBox _statutComboBox;
        private ComboBox _classementComboBox;
        private Grid _mainGrid;
        private bool _isTrainer;
        private bool _isStarted;
        private IEmployee _employee;
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

        public IEmployee Employee
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

        public CreationEmployeeUserControl(IEmployee employee)
        {
            this._guid = ((Member)employee).Guid;
            this._employee = employee;
            this._isStarted = false;
            InitializeComponent();
            this._mainGrid = MainGrid;
            PrenomTextBox.Text = ((Member)employee).FirstName;
            NomTextBox.Text = ((Member)employee).LastName;
            PhoneTextBox.Text = ((Member)employee).PhoneNumber;
            GenreComboBox.SelectedIndex = Convert.ToInt32(((Member)employee).Gender) - 1;
            AdressTextBox.Text = ((Member)employee).Adress;
            SalaryTextBox.Text = employee.Salary.ToString();
            IBANTextBox.Text = employee.BankDetails?.Iban;
            RIBTextBox.Text = employee.BankDetails?.Rib;
            EntryDatePicker.SelectedDate = employee.EntryDate;
            BirthDatePicker.SelectedDate = ((Member)employee).Birthdate;
            this._isTrainer = ((Member)employee).GetType() == PostEnum.Trainer;

            if (this._isTrainer)
            {
                JobComboBox.SelectedIndex = 0;
                this._statutComboBox.SelectedIndex = Convert.ToInt32(((Trainer)employee).Position);
                this._classementComboBox.SelectedIndex = Convert.ToInt32(((Trainer)employee).Classement);
                CreateGrid();
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
                !string.IsNullOrEmpty(AdressTextBox.Text) &&
                BirthDatePicker.SelectedDate != null;
        }
        public IEmployee GetEmployee()
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
                    (DateTime)BirthDatePicker.SelectedDate,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate,
                    (ClassementEnum)this._classementComboBox.SelectedIndex,
                    (TrainerPositionEnum)this._statutComboBox.SelectedIndex);
                }
                else
                {
                    return new Administration(
                    PrenomTextBox.Text,
                    NomTextBox.Text,
                    PhoneTextBox.Text,
                    (GenderEnum)(GenreComboBox.SelectedIndex + 1),
                    AdressTextBox.Text,
                    (DateTime)BirthDatePicker.SelectedDate,
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
                    (DateTime)BirthDatePicker.SelectedDate,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate,
                    (ClassementEnum)this._classementComboBox.SelectedIndex,
                    (TrainerPositionEnum)this._statutComboBox.SelectedIndex,
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
                    (DateTime)BirthDatePicker.SelectedDate,
                    new BankDetails(RIBTextBox.Text, IBANTextBox.Text),
                    Convert.ToInt32(SalaryTextBox.Text),
                    (DateTime)EntryDatePicker.SelectedDate,
                    this._guid);
                }
            }
        }
        private void CreateGrid()
        {
            CreateStatutGrid();
            CreateClassementGrid();
        }
        private void CreateStatutGrid()
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
                ItemsSource = Enum.GetValues(typeof(TrainerPositionEnum)),
                SelectedIndex = 0
            };

            this._statutComboBox = comboBox;

            grid.Children.Add(text);
            grid.Children.Add(comboBox);

            Grid.SetColumn(text, 0);
            Grid.SetColumn(comboBox, 1);

            MainGrid.Children.Add(grid);
            Grid.SetRow(grid, 10);
        }
        private void CreateClassementGrid()
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
                Text = "Classement",
                FontSize = 14,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            ComboBox comboBox = new ComboBox()
            {
                Margin = new Thickness(10),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                ItemsSource = Enum.GetValues(typeof(ClassementEnum)),
                SelectedIndex = 0
            };

            this._classementComboBox = comboBox;

            grid.Children.Add(text);
            grid.Children.Add(comboBox);

            Grid.SetColumn(text, 0);
            Grid.SetColumn(comboBox, 1);

            MainGrid.Children.Add(grid);
            Grid.SetRow(grid, 11);
        }
        private void JobComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 0 trainer /1 administration
            if (JobComboBox.SelectedIndex == 0)
            {
                CreateGrid();
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
