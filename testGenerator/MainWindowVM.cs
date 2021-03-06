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
        ObservableCollection<object> sequence;
        ObservableCollection<object> visualSequence;
        BackgroundWorker bw = new BackgroundWorker();
        List<Generator> generators = new List<Generator>();
        int maxElementNumber = 4;

       


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
                OnPropertyChanged(nameof(SelectedGenerator));
            }
        }

        public ObservableCollection<object> Sequence
        {
            get { return sequence; }
        }

        public ObservableCollection<object> VisualSequence
        {
            get { return visualSequence; }
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
            
            sequence = new ObservableCollection<object>();
            visualSequence = new ObservableCollection<object>();
            generators.Add(new Generator("Линейный Конгруэнтный",new LinearGenerator.LinearGeneratorView()));
            generators.Add(new Generator("Стандартный генератор C#", new StandartC_SharpGenerator.StandartGeneratorView()));
            generators.Add(new Generator("Аддитивный генератор Фибоначчи",new FibAddGenerator.FibAddView()));
            //generators.Add(new Generator("Матричный линейно конгруэнтный генератор", new LinearMatrixGenerator.LinearMatrixView()));
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
            selectedGenerator.GeneratorVM.Reset();
            for(int i = 0; i < MaxElementNumber; i++)
            {
                if(i == 0) { Console.WriteLine(selectedGenerator.GeneratorVM.CurrentItem); }
                sequence.Add(selectedGenerator.GeneratorVM.CurrentItem);
                selectedGenerator.GeneratorVM.Next();
            }


            visualSequence.Clear();
            selectedGenerator.GeneratorVM.Reset();
            for (int i = 0; i < MaxElementNumber; i++)
            {
                if (i == 0) { Console.WriteLine(selectedGenerator.GeneratorVM.VisualCurrentItem); }
                visualSequence.Add(selectedGenerator.GeneratorVM.VisualCurrentItem);
                selectedGenerator.GeneratorVM.Next();
            }

            OnPropertyChanged(nameof(Sequence));
            OnPropertyChanged(nameof(VisualSequence));


        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
