using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace CinemaBooking
{
    public class DynamicClass : DynamicObject, INotifyPropertyChanged
    {
        private readonly IDictionary<string, object> data;

        public DynamicClass()
        {
            data = new Dictionary<string, object>();
        }
        public DynamicClass(IDictionary<string, object> source)
        {
            data = source;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return data.Keys;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this[binder.Name] = value;
            return true;
        }

        public object this[string columnName]
        {
            get
            {
                object result = null;
                if (data.ContainsKey(columnName)) result = data[columnName];
                return result;
            }
            set
            {
                if (!data.ContainsKey(columnName))
                {
                    data.Add(columnName, value);

                    OnPropertyChanged(columnName);
                }
                else
                {
                    if (data[columnName] != value)
                    {
                        data[columnName] = value;

                        OnPropertyChanged(columnName);
                    }
                }
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
