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
        protected object currentItem;
        public object CurrentItem { get { return currentItem; } }

        protected object visualCurrentItem;
        public object VisualCurrentItem { get { CurrentItemToVisualCurrentItem(); return visualCurrentItem; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(prop));
        }

        public abstract void Next();
        public abstract void Reset();
        protected abstract void CurrentItemToVisualCurrentItem();
    }
}
