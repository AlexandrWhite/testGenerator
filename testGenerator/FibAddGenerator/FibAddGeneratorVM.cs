using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenerator.FibAddGenerator
{
    class FibAddGeneratorVM : GeneratorVM
    {
        int x0, x1, mod;
        ulong lastItem;

        public int X0
        {
            get { return x0; }
            set { x0 = value; }
        }

        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public int Mod
        {
            get { return mod; }
            set { mod = value; }
        }


        public override void Next()
        {
            ulong t = currentItem;
            currentItem = (ulong)(((int)currentItem - (int)lastItem) % mod);
            lastItem = t;
        }

        public FibAddGeneratorVM()
        {
            mod = 2;
            currentItem = (ulong)(x0 % mod);
        }

        public override void Reset()
        {
            currentItem = (ulong)X0;
        }
    }
}
