using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class QuizResultViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public QuizResultViewModel(RootViewModel vm, TestViewModel testvm) : base(vm)
        {
            TestViewModel = testvm;
        }

        public TestViewModel TestViewModel { get; set; }

        private int _testResult;
        public int TestResult
        {
            get
            {
                return TestViewModel.TestResult;
            }
        }

        public int TestTotal
        {
            get
            {
                return TestViewModel.Test.PointsTotal;
            }
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
