using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGenerator.StandartC_SharpGenerator
{
    class StandartCSharpVM:GeneratorVM
    {
        int maxValue;
        Random rnd = new Random();
        
        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
            }
        }

        public override void Next()
        {
            currentItem = (ulong)rnd.Next(MaxValue);
        }

        public override void Reset()
        {           
            
        }

        protected override void CurrentItemToVisualCurrentItem()
        {
            visualCurrentItem = currentItem;
        }
    }
}
