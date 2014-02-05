using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMProject
{
    public class Display
    {
        private decimal? size;
        private ulong? numberOfColors;

        public Display()
        {
            this.size = null;
            this.numberOfColors = null;
        }

        public Display(decimal size, ulong numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }
        public Display(Display display)
        {
            this.Size = display.Size;
            this.NumberOfColors = display.NumberOfColors;
        }
        public decimal? Size 
        {
            get { return this.size; }
            set
            {
                if (value <= 0M)
                {
                    throw new ArgumentException("The size of the display can't be with zero or negative size!");
                }
                this.size = value;
            }
        }
        public ulong? NumberOfColors 
        {
            get { return this.numberOfColors; }
            set
            {
                if (value <= 0UL)
                {
                    throw new ArgumentException("The number of colors can't be negative or zero!");
                }
                this.numberOfColors = value;
            }
        }
    }
}
