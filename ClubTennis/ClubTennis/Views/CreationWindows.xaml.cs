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
using System.Windows.Shapes;

namespace ClubTennis.Views
{
    /// <summary>
    /// Logique d'interaction pour CreationWindows.xaml
    /// </summary>
    public partial class CreationWindows : Window
    {
        private CreationVM _creationVM;

        private bool _isMember;
        private bool _isNew;

        public CreationWindows(Save save)
        {
            this._isNew = true;
            this._creationVM = new CreationVM(save);
            this._creationVM.CreationUserControl = new CreationMemberUserControl();
            DataContext = this._creationVM;
            this._isMember = true;
            InitializeComponent();
        }
        public CreationWindows(Save save, People people, bool isMember)
        {
            this._isNew = false;
            this._creationVM = new CreationVM(save);
            InitializeComponent();
            if (isMember)
            {
                Member member = people as Member;
                this._creationVM.CreationUserControl = new CreationMemberUserControl(member);
                TitleButton.Content = "Membre";
            }
            else
            {
                IEmployee employee = people as IEmployee;
                this._creationVM.CreationUserControl = new CreationEmployeeUserControl(employee);
                TitleButton.Content = "Salarié";
            }
            DataContext = this._creationVM;
            this._isMember = isMember;
            TitleButton.IsEnabled = false;
        }
        private void BorderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.DragMove();
        }

        private void TitleButton_Click(object sender, RoutedEventArgs e)
        {
            this._isMember = !this._isMember;

            TitleButton.Content = this._isMember ? "Membre" : "Salarié";
            TitleButton.Background = this._isMember ? SolidColorBrushHelper.LightRedOchre() : SolidColorBrushHelper.Desire();
            if (this._isMember)
            {
                this._creationVM.CreationUserControl = new CreationMemberUserControl();
            }
            else
            {
                this._creationVM.CreationUserControl = new CreationEmployeeUserControl();
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._isNew)
            {
                if (this._isMember)
                {
                    CreationMemberUserControl creationMemberUserControl = (CreationMemberUserControl)this._creationVM.CreationUserControl;
                    if (creationMemberUserControl.IsAllFill())
                    {
                        Member member = creationMemberUserControl.GetMember();
                        Data data = new Data();
                        data.Load();
                        this._creationVM.Save.Peoples.Add(member);
                        data.Saves.Add(this._creationVM.Save);
                        data.Write();
                        CloseWindows();
                    }
                }
                else
                {
                    CreationEmployeeUserControl creationEmployeeUserControl = (CreationEmployeeUserControl)this._creationVM.CreationUserControl;
                    if (creationEmployeeUserControl.IsAllFill())
                    {
                        if (creationEmployeeUserControl.IsTrainer)
                        {
                            Trainer trainer = creationEmployeeUserControl.GetEmployee() as Trainer;
                            Data data = new Data();
                            data.Load();
                            this._creationVM.Save.Peoples.Add(trainer);
                            data.Saves.Add(this._creationVM.Save);
                            data.Write();
                        }
                        else
                        {
                            Administration administration = creationEmployeeUserControl.GetEmployee() as Administration;
                            Data data = new Data();
                            data.Load();
                            this._creationVM.Save.Peoples.Add(administration);
                            data.Saves.Add(this._creationVM.Save);
                            data.Write();
                        }
                        CloseWindows();
                    }
                }
            }
            else
            {
                if (this._isMember)
                {
                    CreationMemberUserControl creationMemberUserControl = (CreationMemberUserControl)this._creationVM.CreationUserControl;
                    if (creationMemberUserControl.IsAllFill())
                    {
                        Member member = creationMemberUserControl.GetMember();
                        Data data = new Data();
                        data.Load();
                        this._creationVM.Save.Peoples = this._creationVM.Save.Peoples.Where(x => !Guid.Equals(x.Guid, member.Guid)).ToList();
                        this._creationVM.Save.Peoples.Add(member);
                        data.Saves.Add(this._creationVM.Save);
                        data.Write();
                        CloseWindows();
                    }
                }
                else
                {
                    CreationEmployeeUserControl creationMemberUserControl = (CreationEmployeeUserControl)this._creationVM.CreationUserControl;
                    if (creationMemberUserControl.IsAllFill())
                    {
                        IEmployee employee = creationMemberUserControl.GetEmployee();
                        Data data = new Data();
                        data.Load();
                        this._creationVM.Save.Peoples = this._creationVM.Save.Peoples.Where(x => !Guid.Equals(x.Guid, ((People)employee).Guid)).ToList();
                        this._creationVM.Save.Peoples.Add((People)employee);
                        data.Saves.Add(this._creationVM.Save);
                        data.Write();
                        CloseWindows();
                    }
                }
            }
        }

        private void CloseWindows()
        {
            Window fenetre = Window.GetWindow(this);
            fenetre.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindows();
        }
    }
}
