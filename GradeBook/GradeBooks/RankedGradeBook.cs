using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentsAmount = Students.Count;
            if (studentsAmount < 5)
                throw new InvalidOperationException();

            int threshold = (int)Math.Ceiling(studentsAmount * 0.2);
            List<double> orderedGrades = (from stu in Students orderby stu.AverageGrade descending select stu.AverageGrade).ToList();

            if (orderedGrades[threshold - 1] <= averageGrade)
                return 'A';
            else if (orderedGrades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (orderedGrades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (orderedGrades[(threshold * 4) - 1] <= averageGrade)
                return 'D';

            return 'F';
        }
    }
}
