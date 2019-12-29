using ClubTennis.Models;
using ClubTennis.ViewModels;
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
    /// Logique d'interaction pour MemberListUserControl.xaml
    /// </summary>
    public partial class MemberListUserControl : UserControl
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
      
        public MemberListUserControl(List<People> peoples)
        {
            InitializeComponent();
            this._checkBoxes = new List<CustomCheckBox<People>>();
            InitializeList(peoples);
        }
        private void InitializeList(List<People> peoples)
        {
            foreach(People people in peoples)
            {
                Grid grid = GetMainGrid(people);
                ContentStackPanel.Children.Add(grid);
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
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(2, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(3, GridUnitType.Star)},
                    }
            };
            CustomCheckBox<People> checkBox = new CustomCheckBox<People>(people)
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = defaultMargin,
                Background = new SolidColorBrush(Colors.Transparent)
            };
            this._checkBoxes.Add(checkBox);

            TextBlock name = GetTextBlock(people.LastName, defaultMargin);

            TextBlock phone = GetTextBlock(people.PhoneNumber, defaultMargin);

            TextBlock adress = GetTextBlock(people.Adress, defaultMargin);

            TextBlock statut = GetTextBlock(((Member)people).HasPaid.ToString(), defaultMargin);//TODO CONVERTER

            TextBlock gender = GetTextBlock(people.Gender.ToString(), defaultMargin);

            TextBlock classement = GetTextBlock(((Member)people).Classement, defaultMargin);

            Grid menu = GetGrid();

            grid.Children.Add(checkBox);
            grid.Children.Add(name);
            grid.Children.Add(phone);
            grid.Children.Add(adress);
            grid.Children.Add(statut);
            grid.Children.Add(gender);
            grid.Children.Add(classement);
            grid.Children.Add(menu);

            Grid.SetColumn(checkBox, 0);
            Grid.SetColumn(name, 1);
            Grid.SetColumn(phone, 2);
            Grid.SetColumn(adress, 3);
            Grid.SetColumn(statut, 4);
            Grid.SetColumn(gender, 5);
            Grid.SetColumn(classement, 6);
            Grid.SetColumn(menu, 7);

            return grid;
        }

        private Grid GetGrid()
        {
            Grid grid = new Grid()
            {
                Margin = new Thickness(50,1,50,1),
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
                Margin = new Thickness(5)
            };

            Button delet = new Button()
            {
                Background = new SolidColorBrush(Colors.Red),
                BorderThickness = new Thickness(0),
                Margin = new Thickness(5)
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
            foreach(CustomCheckBox<People> customCheckBox in this._checkBoxes)
            {
                customCheckBox.IsChecked = AllCheckBoxes.IsChecked;
            }
        }
    }
}
