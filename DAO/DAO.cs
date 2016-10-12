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
            MakeMocks();
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
            var selected = (from question in _questions
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
            var selected = (from answer in _answers
                where answer.QuestionID == questionID
                select answer);
            return selected;
        }

        private void MakeMocks()
        {
            _answers = new List<IAnswer>()
            {
                new DO.Answer(0, 0, "Programowanie Wizualne", true),
                new DO.Answer(1, 0, "Metody Probabilistyczne", false),
                new DO.Answer(2, 0, "Matematyka Dyskretna", false),
                new DO.Answer(3, 1, "Tak", true),
                new DO.Answer(4, 1, "Nie", false),
                new DO.Answer(4, 2, "Tak", true),
                new DO.Answer(5, 2, "Nie", false)
            };

            _questions = new List<IQuestion>()
            {
                new DO.Question(0, 0, "Jak nazywa się przedmiot?", 1),
                new DO.Question(1, 1, "Czy Ziemia jest okrągła?", 1),
                new DO.Question(2, 1, "Czy hymnem UE jest Oda do Radości?", 1)
            };

            _tests = new List<ITest>()
            {
                new DO.Test(0, "test0", 5),
                new DO.Test(1, "test1", 5)
            };

            foreach (var test in _tests)
            {
                foreach (var question in _questions)
                {
                    if (question.TestID == test.ID)
                    {
                        // add question to test
                        test.Questions.Add(question);    
                    }
                }
            }

            foreach (var question in _questions)
            {
                foreach (var answer in _answers)
                {
                    if (answer.QuestionID == question.ID)
                    {
                        // add answer to question
                        question.Answers.Add(answer);
                    }
                }
            }
        }
    }
}
