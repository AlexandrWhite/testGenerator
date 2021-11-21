using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace testGenerator
{
    class Generator
    {
        string name;
        GeneratorVM genViewModel;
        UserControl generatorView;

        public UserControl GeneratorView
        {
            get { return generatorView; }
        }

        public string Name
        {
            get { return name; }
        }

        public GeneratorVM GeneratorVM
        {
            get { return genViewModel; }
        }

        public Generator(string name, UserControl generatorView)
        {
            this.name = name;
            this.generatorView = generatorView;
            this.genViewModel = generatorView.DataContext as GeneratorVM;
        }

    }
}
