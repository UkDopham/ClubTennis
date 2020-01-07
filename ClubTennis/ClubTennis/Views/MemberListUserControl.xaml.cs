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
    /// Logique d'interaction pour MemberListUserControl.xaml
    /// </summary>
    public partial class MemberListUserControl : UserControl, ISave
    {
        private Thickness MARGINENUMCOLOR = new Thickness(15, 5, 15, 5);
        private Save _save;
        private List<People> _peoples;

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


        public MemberListUserControl(List<People> peoples, Save save)
        {
            this._save = save;
            InitializeComponent();
            InitializeList(peoples);
        }
        private void InitializeList(List<People> peoples)
        {
            ContentStackPanel.Children.Clear(); //on clear toutes les infos qu'il y a dans le stackpanel
            foreach(People people in peoples) //pour chaque membre et employés 
            {
                if (people.GetType() == PostEnum.Member) 
                {
                    Grid grid = GetMainGrid(people); //une ligne pour un membre
                    ContentStackPanel.Children.Add(grid); //on l'ajoute 
                }
            }
            this._peoples = peoples;
        }

        private Grid GetMainGrid(People people)
        {
            Thickness defaultMargin = new Thickness(1, 0, 1, 0);
            Grid grid = new Grid()
            {
                MinHeight = 30, //hauteur minimum
                ColumnDefinitions =
                    { // on crée la grille d'affichage des membres
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

            //On crée chaque grid contenant chaque attribut de membre
            Grid name = GetGridText(people.LastName, defaultMargin);

            Grid phone = GetGridText(people.PhoneNumber, defaultMargin);

            Grid age = GetGridText((DateTime.Now.Year - people.Birthdate.Year).ToString(), defaultMargin);

            Grid statut = GetGridText(((Member)people).HasPaid.ToString(), defaultMargin);//TODO CONVERTER

            Grid gender = GetGenderGridText(EnumHelper.GetDescription(people.Gender), people.Gender);

            Grid classement = GetGridText(EnumHelper.GetDescription(((Member)people).Classement), defaultMargin);

            Grid menu = GetGrid(people);

            //les données sont affichées mais au meme endroit seulement
            grid.Children.Add(name);
            grid.Children.Add(phone);
            grid.Children.Add(age);
            grid.Children.Add(statut);
            grid.Children.Add(gender);
            grid.Children.Add(classement);
            grid.Children.Add(menu);

            //on les met dans chaque colonne attribuée ici
            Grid.SetColumn(name, 0);
            Grid.SetColumn(phone, 1);
            Grid.SetColumn(age, 2);
            Grid.SetColumn(statut, 3);
            Grid.SetColumn(gender, 4);
            Grid.SetColumn(classement, 5);
            Grid.SetColumn(menu, 6);

            return grid;
        }

        private Grid GetGrid(People people)
        {
            Grid grid = new Grid()
            {
                Margin = new Thickness(0.5, 1, 0.5, 1),
                Background = new SolidColorBrush(Colors.White),
                ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                        new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                    }
            };

            Button change = new Button()
            {
                Background = SolidColorBrushHelper.LightGreen(),
                BorderThickness = new Thickness(0),
                Margin = MARGINENUMCOLOR,
                Content = GetTextBlock("Modifier", new Thickness(0)),
                Foreground = new SolidColorBrush(Colors.White),
            };

            change.Click += (s, e) =>
            {
                CreationWindows newWindows = new CreationWindows(this._save, people, true)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                newWindows.ShowDialog();
                //Save = newWindows.CreationVM.Save;

                InitializeList(this._save.Peoples);
            };

            Button delet = new Button()
            {
                Background = SolidColorBrushHelper.Red(),
                BorderThickness = new Thickness(0),
                Margin = MARGINENUMCOLOR,
                Content = GetTextBlock("Supprimer", new Thickness(0)),
                Foreground = new SolidColorBrush(Colors.White),
            };

            delet.Click += (s, e) =>
            {
                Data data = new Data();
                data.Load();
                this._save.Peoples.Remove(people);
                data.AddSave(this._save);

                //Save = this._save;
                data.Write();
                InitializeList(this._save.Peoples);
            };

            grid.Children.Add(change);
            grid.Children.Add(delet);

            Grid.SetColumn(change, 0);
            Grid.SetColumn(delet, 1);

            return grid;
        }
        private Grid GetGridText(string text, Thickness margin)
        {
            return new Grid()
            {
                Background = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0.5,1,0.5,1),
                Children =
                {
                    GetTextBlock(text, margin)
                }
            };
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

        private Grid GetGenderGridText(string text, GenderEnum genderEnum)
        {
            return new Grid()
            {
                Background = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0.5, 1, 0.5, 1),
                Children =
                {
                    GetGenderGrid(text, genderEnum)
                }
            };
        }
        private Grid GetGenderGrid(string text, GenderEnum genderEnum)
        {
            return new Grid()
            {
                Background = GenderBackGround(genderEnum),
                Margin = MARGINENUMCOLOR,
                Children =
                {
                    GetGenderTextBlock(text, genderEnum)
                }
            };
        }
        private TextBlock GetGenderTextBlock(string text, GenderEnum genderEnum)
        {
            return new TextBlock()
            {
                Text = text,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 15,
            };
        }

        private SolidColorBrush GenderBackGround(GenderEnum genderEnum)
        {
            SolidColorBrush solidColor = new SolidColorBrush();

            switch(genderEnum)
            {
                case GenderEnum.man:
                    solidColor = SolidColorBrushHelper.Blue();
                    break;

                case GenderEnum.woman:
                    solidColor = SolidColorBrushHelper.Red();
                    break;

                case GenderEnum.other:
                    solidColor = SolidColorBrushHelper.LightGreen();
                    break;
            }
            return solidColor;
        }
        private void CheckBoxClick(object sender, RoutedEventArgs e)
        {
            //foreach(CustomCheckBox<People> customCheckBox in this._checkBoxes)
            //{
            //    customCheckBox.IsChecked = AllCheckBoxes.IsChecked;
            //}
        }
    }
}
