using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace PhoneApp85
{
    public class ViewModel : INotifyPropertyChanged
    {
        // Fields...
        private InputScopeNameValue _SelectedInputScopeNameValue;
        private ObservableCollection<InputScopeNameValue> _InputScopeList;

        public ObservableCollection<InputScopeNameValue> InputScopeList
        {
            get { return _InputScopeList; }
            set
            {
                if (_InputScopeList == value)
                    return;
                _InputScopeList = value;
                RaisePropertyChanged("InputScopeList");
            }
        }

        public InputScopeNameValue SelectedInputScopeNameValue
        {
            get { return _SelectedInputScopeNameValue; }
            set
            {
                _SelectedInputScopeNameValue = value;
                RaisePropertyChanged("SelectedInputScopeNameValue");
                RaisePropertyChanged("SelectedInputScope");
            }
        }

        public InputScope SelectedInputScope
        {
            get
            {
                InputScope keyboard = new InputScope();
                InputScopeName name = new InputScopeName();

                try
                {
                    name.NameValue = SelectedInputScopeNameValue;
                    keyboard.Names.Add(name);
                    return keyboard;
                }
                catch (Exception ex)
                {
                    name.NameValue = InputScopeNameValue.Default;
                    keyboard.Names.Add(name);
                    return keyboard;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ViewModel class.
        /// </summary>
        public ViewModel()
        {
            var data = InputScopeNameValue.AddressCity.GetValues<InputScopeNameValue>().ToList();
            InputScopeList = new ObservableCollection<InputScopeNameValue>(data);
        }

        #region INPC

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INPC
    }
}