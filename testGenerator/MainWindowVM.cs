using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using OxyPlot;
namespace testGenerator
{
    class MainWindowVM : INotifyPropertyChanged
    {
        Generator selectedGenerator;
        ObservableCollection<ulong> sequence;
        BackgroundWorker bw = new BackgroundWorker();
        List<Generator> generators = new List<Generator>();
        int maxElementNumber = 10;

       


        int progress = 0;

        public int Progress { get { return progress; } }

        public Generator SelectedGenerator
        {
            get
            {
                return selectedGenerator;
            }
            set
            {
                selectedGenerator = value;
            }
        }

        public ObservableCollection<ulong> Sequence
        {
            get { return sequence; }
        }


        public BackgroundWorker BackgroundWorker
        {
            get { return bw; }
        }

        public List<Generator> Generators
        {
            get { return generators; }
        }

        public int MaxElementNumber
        {
            get { return maxElementNumber; }
            set { maxElementNumber = value; }
        }



       
      
        public MainWindowVM()
        {
            
            sequence = new ObservableCollection<ulong>();
            generators.Add(new Generator("Линейный Конгруэнтный",new LinearGenerator.LinearGeneratorView()));

            selectedGenerator = generators[0];



            //bw.WorkerReportsProgress = true;
            //bw.DoWork += Bw_DoWork;
            //bw.ProgressChanged += Bw_ProgressChanged;
            //bw.RunWorkerCompleted += Bw_RunWorkerCompleted;


        }

        //private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{            
        //    progress = 0;
        //    OnPropertyChanged(nameof(Progress));
        //    sequence = new ObservableCollection<ulong>(s);
        //    OnPropertyChanged(nameof(Sequence));
        //}

        //private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    progress = e.ProgressPercentage;
        //    OnPropertyChanged(nameof(Progress));
        //}

       

        public void GenerateSequence()
        {
            //progress = 0;
            //OnPropertyChanged(nameof(Progress));
            ////bw.RunWorkerAsync();

            sequence.Clear();
            for(int i = 0; i < MaxElementNumber; i++)
            {
                sequence.Add(selectedGenerator.GeneratorVM.CurrentItem);
                selectedGenerator.GeneratorVM.Next();
            }
            OnPropertyChanged(nameof(Sequence));
            
          
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
