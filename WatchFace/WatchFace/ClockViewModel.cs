using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WatchFace
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        DateTime _time;

        public DateTime Time
        {
            get => _time;
            set
            {
                if (_time == value) return;
                _time = value;
                OnPropertyChanged();

                // Whenever the 'Time' property setter is executed, calculate new value for 'SecondsRotation' based on current second
                // and notify the view about the change by calling 'OnPropertyChanged' method with correct parameter.
                SecondsRotation = _time.Second * 6;
                OnPropertyChanged(nameof(SecondsRotation));
            }
        }

        public int SecondsRotation { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
