using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface ITest
    {
        int ID { get; set; }
        string Name { get; set; }
        int Time { get; set; }
        int PointsTotal { get; set; }

        int QuestionNr { get; set; }
        List<IQuestion> Questions { get; set; }
    }
}
