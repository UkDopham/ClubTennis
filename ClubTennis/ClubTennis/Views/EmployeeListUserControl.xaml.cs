using ClubTennis.Models;
using ClubTennis.ViewModels;
using ClubTennis.Views.Interfaces;
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
    /// Logique d'interaction pour EmployeeListUserControl.xaml
    /// </summary>
    public partial class EmployeeListUserControl : UserControl , ISave
    {
        private Save _save;
        private List<People> _peoples;
        private List<CustomCheckBox<People>> _checkBoxes;

        public List<People> Peoples
        {
            get
            {
                return this._peoples;
            }
            set
            {
                this._peoples = value;
            }
        }
        public List<CustomCheckBox<People>> CheckBoxes
        {
            get
            {
                return this._checkBoxes;
            }
        }

        public Save Save
        {
            get
            {
                return this._save;
            }
            set
            {
                this._save = value;
            }
        }

        public EmployeeListUserControl(List<People> peoples, Save save)
        {
            this._save = save;
            InitializeComponent();
            this._checkBoxes = new List<CustomCheckBox<People>>();
            InitializeList(peoples);
        }
        private void InitializeList(List<People> peoples)
        {
            ContentStackPanel.Children.Clear();
            foreach (People people in peoples)
            {
                if (people.GetType() == PostEnum.Trainer 
                    || people.GetType() == PostEnum.Administration)
                {
                    Grid grid = GetMainGrid(people);
                    ContentStackPanel.Children.Add(grid);
                }
            }
            this._peoples = peoples;
        }

        private Grid GetMainGrid(People people)
        {
            Thickness defaultMargin = new Thickness(1, 0, 1, 0);
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(3, GridUnitType.Star)},
                    }
            };
            //CustomCheckBox<People> checkBox = new CustomCheckBox<People>(people)
            //{
            //    VerticalAlignment = VerticalAlignment.Center,
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //    Margin = defaultMargin,
            //    Background = new SolidColorBrush(Colors.Transparent)
            //};
            //this._checkBoxes.Add(checkBox);


            TextBlock name = GetTextBlock(people.LastName, defaultMargin);

            TextBlock phone = GetTextBlock(people.PhoneNumber, defaultMargin);

            TextBlock age = GetTextBlock((DateTime.Now.Year - people.Birthdate.Year).ToString(), defaultMargin);

            TextBlock post = GetTextBlock(people.GetType().ToString(), defaultMargin);//TODO CONVERTER

            TextBlock gender = GetTextBlock(people.Gender.ToString(), defaultMargin);

            TextBlock salary = GetTextBlock(((IEmployee)people).Salary.ToString(), defaultMargin);

            TextBlock date = GetTextBlock(((IEmployee)people).EntryDate.ToString("d"), defaultMargin);

            TextBlock rib = GetTextBlock(((IEmployee)people).BankDetails?.Rib, defaultMargin);

            TextBlock iban = GetTextBlock(((IEmployee)people).BankDetails?.Iban, defaultMargin);

            Grid menu = GetGrid(people);

            //grid.Children.Add(checkBox);
            grid.Children.Add(name);
            grid.Children.Add(phone);
            grid.Children.Add(age);
            grid.Children.Add(post);
            grid.Children.Add(gender);
            grid.Children.Add(salary);
            grid.Children.Add(date);
            grid.Children.Add(rib);
            grid.Children.Add(iban);
            grid.Children.Add(menu);

            //Grid.SetColumn(checkBox, 0);
            Grid.SetColumn(name, 0);
            Grid.SetColumn(phone, 1);
            Grid.SetColumn(age, 2);
            Grid.SetColumn(post, 3);
            Grid.SetColumn(gender, 4);
            Grid.SetColumn(salary, 5);
            Grid.SetColumn(date, 6);
            Grid.SetColumn(rib, 7);
            Grid.SetColumn(iban, 8);
            Grid.SetColumn(menu, 9);

            return grid;
        }

        private Grid GetGrid(People people)
        {
            Grid grid = new Grid()
            {
                Margin = new Thickness(50, 1, 50, 1),
                ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                    }
            };

            Button change = new Button()
            {
                Background = new SolidColorBrush(Colors.Green),
                BorderThickness = new Thickness(0),
                MaxHeight = 15,
                MaxWidth = 15,
                Margin = new Thickness(5)
            };

            change.Click += (s, e) =>
            {
                CreationWindows newWindows = new CreationWindows(this._save, people, false)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                newWindows.ShowDialog();
                //this._save = newWindows.Save;

                InitializeList(this._save.Peoples);
            };

            Button delet = new Button()
            {
                Background = new SolidColorBrush(Colors.Red),
                BorderThickness = new Thickness(0),
                MaxHeight = 15,
                MaxWidth = 15,
                Margin = new Thickness(5)
            };

            delet.Click += (s, e) =>
            {
                Data data = new Data();
                data.Load();
                this._save.Peoples.Remove(people);
                data.AddSave(this._save);

                data.Write();
                InitializeList(this._save.Peoples);
            };

            grid.Children.Add(change);
            grid.Children.Add(delet);

            Grid.SetColumn(change, 0);
            Grid.SetColumn(delet, 1);

            return grid;
        }
        private TextBlock GetTextBlock(string text, Thickness margin)
        {
            return new TextBlock()
            {
                Text = text,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 15,
                Margin = margin
            };
        }

        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            //foreach (CustomCheckBox<People> customCheckBox in this._checkBoxes)
            //{
            //    customCheckBox.IsChecked = AllCheckBoxes.IsChecked;
            //}
        }

    }
}
