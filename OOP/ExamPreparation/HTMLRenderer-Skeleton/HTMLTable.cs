namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HTMLTable : HTMLElement, ITable
    {
        private const string InitialHTMLTableName = "table";

        private const string OpenRowTag = "<tr>";
        private const string OpenColTag = "<td>";

        private const string CloseRowTag = "</tr>";
        private const string CloseColTag = "</td>";

        private int rows;
        private int cols;
        private IElement[,] tableElements;

        public HTMLTable(int rows, int cols)
            : base(InitialHTMLTableName)
        {
            this.Rows = rows;
            this.Cols = cols;

            this.tableElements = new IElement[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("HTML table number of rows cannot be less or equal to zero!");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("HTML table number of cols cannot be less or equal to zero!");
                }
                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.Rows || col < 0 || col >= this.Cols)
                {
                    throw new ArgumentOutOfRangeException("Row or col value is out of range!");
                }

                return this.tableElements[row, col];
            }
            set
            {
                if (row < 0 || row >= this.Rows || col < 0 || col >= this.Cols)
                {
                    throw new ArgumentOutOfRangeException("Row or col value is out of range!");
                }

                if (value == null)
                {
                    throw new ArgumentNullException("HTML element to be added to table cannot be null!");
                }

                this.tableElements[row, col] = value;
            }
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new ArgumentException("HTML table does not have any child elements!");
            }
        }

        public override void AddElement(IElement element)
        {
            throw new ArgumentException("HTML table does not support AddElement operation!");
        }

        public override string TextContent
        {
            get
            {
                throw new ArgumentException("HTML table does not have text content!");
            }
            set
            {
                throw new ArgumentException("HTML table does not have text content!");
            }
        }

        public override string Name
        {
            get
            {
                return InitialHTMLTableName;
            }
        }

        public override void Render(StringBuilder output)
        {
            output.Append(string.Format("<{0}>", InitialHTMLTableName));

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(OpenRowTag);

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(OpenColTag);
                    this.tableElements[row, col].Render(output);
                    output.Append(CloseColTag);
                }

                output.Append(CloseRowTag);
            }
            output.Append(string.Format("</{0}>", InitialHTMLTableName));
        }
    }
}
