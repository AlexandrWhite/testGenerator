using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace testGenerator
{
    abstract class GeneratorVM:INotifyPropertyChanged
    {
        protected ulong currentItem;
        public ulong CurrentItem { get { return currentItem; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop));
        }

        public abstract void Next();
    }
}
