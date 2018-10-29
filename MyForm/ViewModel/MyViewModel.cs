using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using MyForm.Annotations;
using MyForm.Model;

namespace MyForm.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MyViewModel: INotifyPropertyChanged

    {
        public MyViewModel()
        {
            _status = new Status();
            _settings = new Settings(_status);

            _statusContent = new ObservableCollection<Tuple<string, string>>();
            _settingsContent = new ObservableCollection<Tuple<string, string, bool>>();

            PropertyInfo[] statusProperties = typeof(Status).GetProperties();
            foreach (PropertyInfo property in statusProperties)
            {
                string name = property.Name;
                string val = property.GetValue(_status).ToString();
                _statusContent.Add(new Tuple<string, string>(name, val));
            }

            PropertyInfo[] settingsProperties = typeof(Settings).GetProperties();
            foreach (PropertyInfo property in settingsProperties)
            {
                string name = property.Name;
                string val = property.GetValue(_settings).ToString();
                bool hasButton = _settings.HastButton(property);
                _settingsContent.Add(new Tuple<string, string, bool>(name, val, hasButton));
            }


        }
        
        public Status Status
        {
            get => _status;
            set
            {
                if (Equals(value, _status)) return;
                _status = value;
                OnPropertyChanged();
            }
        }

        public Settings Settings
        {
            get => _settings;
            set
            {
                if (Equals(value, _settings)) return;
                _settings = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Tuple<string, string>> StatusContent
        {
            get => _statusContent;
            set
            {
                if (Equals(value, _statusContent)) return;
                _statusContent = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Tuple<string, string, bool>> SettingsContent
        {
            get => _settingsContent;
            set
            {
                if (Equals(value, _settingsContent)) return;
                _settingsContent = value;
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
        private Status _status;
        private Settings _settings;
        private ObservableCollection<Tuple<string, string>> _statusContent;
        private ObservableCollection<Tuple<string, string, bool>> _settingsContent;
        #endregion
    }
}
