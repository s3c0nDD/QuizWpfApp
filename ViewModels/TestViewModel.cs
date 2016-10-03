using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public TestViewModel(ITest test)
        {
            _test = test;

            _questions = new ObservableCollection<QuestionViewModel>();
            foreach (var question in test.Questions)
            {
                _questions.Add(new QuestionViewModel(question));
            }
        }

        public int TestResult { get; set; }

        private ITest _test;
        public ITest Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
            }
        }

        private int _time;
        public int Time
        {
            get
            {
                return _test.Time;
            }
        }

        private ObservableCollection<QuestionViewModel> _questions;
        public ObservableCollection<QuestionViewModel> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                RaisePropertyChanged("Questions");
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
