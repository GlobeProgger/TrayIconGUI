using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyForm.Annotations;

namespace MyForm.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Settings : INotifyPropertyChanged
    {
        public Settings(Status status)
        {
            ParseInterval = 3;
            LogfilePath = "logfile.log";
            SerialNumber = status.SerialNumber;
            Alias = "AliasName";
            Location = "LocationName";
        }

        public int ParseInterval
        {
            get => _parseInterval;
            set
            {
                if (value == _parseInterval) return;
                _parseInterval = value;
                OnPropertyChanged();
            }
        }

        public string LogfilePath
        {
            get => _logfilePath;
            set
            {
                if (Equals(value, _logfilePath)) return;
                _logfilePath = value;
                OnPropertyChanged();
            }
        }

        public int SerialNumber
        {
            get => _serialNumber;
            set
            {
                if (value == _serialNumber) return;
                _serialNumber = value;
                OnPropertyChanged();
            }
        }

        public string Alias
        {
            get => _alias;
            set
            {
                if (value == _alias) return;
                _alias = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                if (value == _location) return;
                _location = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Implementation
        private int _parseInterval;
        private string _logfilePath;
        private int _serialNumber;
        private string _alias;
        private string _location;
        #endregion

        public bool HastButton(PropertyInfo property)
        {
            return (property.Name == nameof(LogfilePath) ||
                    property.Name == nameof(SerialNumber));
        }
    }
}
