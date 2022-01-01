using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenerator.LinearGenerator
{
    class LinearGeneratorVM:GeneratorVM
    {
        ulong a, b, x0,mod;
        
      
        public ulong A
        {
            get { return a; }
            set {
                currentItem = x0%mod;
                a = value;
                OnPropertyChanged(nameof(A));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        public ulong B
        {
            get { return b; }
            set {
                currentItem = x0%mod;
                b = value;
                OnPropertyChanged(nameof(B));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        public ulong X0
        {
            get { return x0; }
            set {
                x0 = value;
                currentItem = x0%mod;
                OnPropertyChanged(nameof(x0));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        public ulong Mod
        {
            get { return mod; }
            set {

                currentItem = x0%mod;
                mod = value;
                OnPropertyChanged(nameof(Mod));
                OnPropertyChanged(nameof(CurrentItem));
            }
        }

        public LinearGeneratorVM(ulong a,ulong b,ulong x0,ulong mod)
        {
            this.a = a;
            this.b = b;
            this.mod = mod;
            this.x0 = x0%mod;
            currentItem = x0;
        }

        public LinearGeneratorVM() {
            mod = 2;
            currentItem = x0%mod;            
        }
       
        public override void Next()
        {
            currentItem = (a * currentItem + b)%mod;          
            OnPropertyChanged(nameof(currentItem));
        }

        public override void Reset()
        {
            currentItem = X0%mod;
        }

    }
}
