using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin101part6.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            EraseCommand = new Command(() => { TheNote = ""; });
            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = "";
            });
        }

        public ObservableCollection<string> AllNotes { get; set; } = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string note;
        public Command EraseCommand { get; }
        public Command SaveCommand { get; }

        public string TheNote
        {
            get => note;
            set
            {
                note = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}