using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (value == string.Empty || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("First name can not be empty, null or whitespace!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (value == string.Empty || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Last name can not be empty, null or whitespace!");
            }
            this.lastName = value;
        }
    }

    public IList<Exam> Exams { get; set; }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(string.Format("There are no exams for student {0} {1}!", this.FirstName, this.LastName));
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentOutOfRangeException(string.Format("There are no exams for student {0} {1}!", this.FirstName, this.LastName));
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(string.Format("There are no exams for student {0} {1} to calculate average.", this.FirstName, this.LastName));
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentOutOfRangeException(string.Format("There are no exams for student {0} {1} to calculate average.", this.FirstName, this.LastName));
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                          ((double) examResults[i].Grade - examResults[i].MinGrade) /
                          (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}