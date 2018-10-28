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
    public class MyViewModel: PropertyChangedNotifier

    {
        public MyViewModel()
        {
            Title = "Settings";
            Tabs = new ObservableCollection<object> { new Status() };
        }

        public string Title { get; private set; }

        public ObservableCollection<object> Tabs;
    }
}
