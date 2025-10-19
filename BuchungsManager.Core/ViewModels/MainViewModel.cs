using BuchungsManager.Lib.Interfaces;
using BuchungsManager.Lib.Modell;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchungsManager.Core.ViewModels
{
    public partial class MainViewModel(IRepository repository) : ObservableObject
    {
        IRepository _repository = repository;

        //Variablen
        [ObservableProperty]
        public string gastName = string.Empty;

        [ObservableProperty]
        public DateTime anreiseDatum = DateTime.Now;

        [ObservableProperty]
        public double preisProNacht = 0;

        [ObservableProperty]
        public bool allInklusiv = false;

        [ObservableProperty]
        Buchungen selectedItem = null;

        [ObservableProperty]
        ObservableCollection<Buchungen> _buch = [];

        //Wenn leer -> kann nicht hinzugefügt werden

        //Methoden
        [RelayCommand] //Kann nciht ausgeführt werden wenn leer
        void Add()
        {
            Buchungen buchung = new Buchungen(this.GastName, this.AnreiseDatum, this.PreisProNacht, this.AllInklusiv);

            var result = _repository.Add(buchung);
            this._buch.Add(buchung);

            if(result)
            {
                this.GastName = string.Empty;
                this.AnreiseDatum = DateTime.Now;
                this.PreisProNacht = 0;
                this.AllInklusiv = false;
            }
        }

        [RelayCommand]
        void GetAll()
        {
            var alleBuchungen = _repository.GetAll();

            foreach(var item in alleBuchungen)
            {
                this._buch.Add(item);
            }
        }

        [RelayCommand]  
        void Delete()
        {
            _repository.Delete(this.SelectedItem);
            this._buch.Remove(this.SelectedItem);
        }

        [RelayCommand]
        void Update()
        {
            _repository.Update(this.SelectedItem);
            int pos = this.Buch.IndexOf(this.SelectedItem);
            
                this.Buch[pos] = this.SelectedItem;
            
        }
    }
}
