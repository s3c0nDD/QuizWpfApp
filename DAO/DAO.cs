using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO : IDAO
    {
        private List<ITest> _tests;
        private List<IQuestion> _questions;
        private List<IAnswer> _answers;

        public DAO()
        {
            makeMocks();
        }

        public IEnumerable<ITest> GetAllTests()
        {
            return _tests;
        }

        public IEnumerable<IQuestion> GetAllQuestions()
        {
            return _questions;
        }

        public IEnumerable<IQuestion> GetQuestions(int testID)
        {
            IEnumerable<IQuestion> selected;
            selected = (from question in _questions
                           where question.TestID == testID
                           select question);
            return selected;
        }

        public IEnumerable<IAnswer> GetAllAnswers()
        {
            return _answers;
        }

        public IEnumerable<IAnswer> GetAnswers(int questionID)
        {
            IEnumerable<IAnswer> selected;
            selected = (from answer in _answers
                        where answer.QuestionID == questionID
                        select answer);
            return selected;
        }

        private void makeMocks()
        {
            _tests = new List<ITest>()
            {
                new DO.Test(0, "test0", 5),
                new DO.Test(1, "test1", 5)
            };

            _questions = new List<IQuestion>()
            {
                new DO.Question(0, 0, "Jak nazywa się przedmiot?", 1),
                new DO.Question(1, 1, "Czy Ziemia jest okrągła?", 1)
            };

            _answers = new List<IAnswer>()
            {
                new DO.Answer(0, 0, "Programowanie Wizualne", true),
                new DO.Answer(1, 0, "Metody Probabilistyczne", false),
                new DO.Answer(2, 0, "Matematyka Dyskretna", false),
                new DO.Answer(3, 1, "Tak", true),
                new DO.Answer(4, 1, "Nie", false)
            };
        }
    }
}
