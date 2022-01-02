using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenerator.FibAddGenerator
{
    class FibAddGeneratorVM : GeneratorVM
    {
        ulong x0, x1, mod;
        ulong lastItem;

        int count = 0;


        public ulong X0
        {
            get { return x0; }
            set { 
                x0 = value;
            
                currentItem = x0 % mod;
                Console.WriteLine(currentItem);
                OnPropertyChanged(nameof(CurrentItem));
                OnPropertyChanged(nameof(X0));
            }
        }

        public ulong X1
        {
            get { return x1; }
            set { x1 = value; currentItem = x0 % mod; OnPropertyChanged(nameof(CurrentItem)); }
        }

        public ulong Mod
        {
            get { return mod; }
            set { mod = value; currentItem = x0 % mod; OnPropertyChanged(nameof(CurrentItem));}
        }


        public override void Next()
        {
         
            if (count == 0) { 
                currentItem = x1%mod;
                count++;
                lastItem = x0; 
                return;
            }

            ulong t = (ulong)currentItem;
            currentItem = ((ulong)currentItem + lastItem) % mod;
            lastItem = t;
            count++;
        }

        public FibAddGeneratorVM()
        {
            mod = 2;
            currentItem = x0 % mod;
        }

        public override void Reset()
        {
            currentItem = X0%mod;
            count = 0;
        }
    }
}
