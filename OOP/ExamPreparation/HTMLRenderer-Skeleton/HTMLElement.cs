namespace HTMLRenderer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HTMLElement : IElement
    {
        private const char lessThanSymbol = '<';
        private const char greaterThanSymbol = '>';
        private const char ampersandSymbol = '&';

        private const string lessThanSymbolEscaping = "&lt;";
        private const string greaterThanSymbolEscaping = "&gt;";
        private const string ampersandSymbolEscaping = "&amp;";

        private IList<IElement> childElements;

        public HTMLElement(string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public HTMLElement(string name, string content)
            :this(name)
        {
            this.TextContent = content;
        }

        public virtual string Name { get; private set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements
        {
            get 
            {
                return new List<IElement>(this.childElements);
            }
        }

        public virtual void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Element to be added cannot be null!");
            }

            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append(string.Format("<{0}>", this.Name));
            }

            if (this.TextContent != null)
            {
                output.Append(RenderTextContent(this.TextContent));
            }

            foreach (var child in this.ChildElements)
            {
                child.Render(output);
            }

            if (this.Name != null)
            {
                output.Append(string.Format("</{0}>", this.Name));
            }
        }

        protected string RenderTextContent(string content)
        {
            StringBuilder renderedContent = new StringBuilder();

            foreach (var symbol in content)
            {
                if (symbol == lessThanSymbol)
                {
                    renderedContent.Append(lessThanSymbolEscaping);
                }
                else if (symbol == greaterThanSymbol)
                {
                    renderedContent.Append(greaterThanSymbolEscaping);
                }
                else if (symbol == ampersandSymbol)
                {
                    renderedContent.Append(ampersandSymbolEscaping);
                }
                else
                {
                    renderedContent.Append(symbol);
                }
            }

            return renderedContent.ToString();
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Render(result);

            return result.ToString();
        }
    }
}
