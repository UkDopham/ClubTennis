using ClubTennis.Models;
using ClubTennis.Models.Filters;
using ClubTennis.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClubTennis.ViewModels
{
    public class MemberVM : ObservableObject
    {
        private ISave _selectedUserControl;
        private Save _save;
        private List<Filter> _activeFilters;

        public void AddFilter(Filter filter)
        {
            this._activeFilters.Add(filter);
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
                OnPropertyChanged("Save");
            }
        }
        public void RemoveFilter<T>(T filter) where T:Filter
        {
            List<T> tmp = this._activeFilters.OfType<T>().ToList();
            tmp.ForEach(x => this._activeFilters.Remove(x));
        }
        public ISave SelectedUserControl
        {
            get
            {
                return this._selectedUserControl;
            }
            set
            {
                this._selectedUserControl = value;
                OnPropertyChanged("SelectedUserControl");
            }
        }

        public MemberVM(Save save)
        {
            this._save = save;
            this._activeFilters = new List<Filter>();
        }
        public List<People> Sort()
        {
            List<People> peoples = this._save.Peoples;
            foreach (Filter filter in this._activeFilters)
            {
                peoples = filter.Order(peoples);
            }
            return peoples;
        }
    }
}
