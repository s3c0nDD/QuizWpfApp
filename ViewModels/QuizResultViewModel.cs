using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmApp.ViewModels
{
    public class QuizResultViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public QuizResultViewModel(RootViewModel vm, TestViewModel testvm) : base(vm)
        {
            TestViewModel = testvm;

            _endQuizCommand= new RelayCommand((param) => this.EndQuiz());
        }

        public TestViewModel TestViewModel { get; set; }

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

        private RelayCommand _endQuizCommand;
        public ICommand EndQuizCommand
        {
            get
            {
                return _endQuizCommand;
            }
        }

        private void EndQuiz()
        {
            
            Parent.CurrentView = new TestListViewModel(Parent);
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
