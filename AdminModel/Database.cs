using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AdminModel
{
    [Serializable]
    public class Database : INotifyPropertyChanged, ICloneable
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                object cloneObj;
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Position = 0;
                cloneObj = bf.Deserialize(ms);
                ms.Close();
                return cloneObj;
            }
        }
    }
}
