using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException("The maximum grade must be greater than the minimum grade.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The grade can not be negative.");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The minimum grade can not be negative.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The maximum grade can not be negative.");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The comments can not be null or empty.");
            }

            this.comments = value;
        }
    }
}