namespace BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // 05.Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.
    // When we use ulong as a field in our class, I implement IEnumerable<ulong>, not IEnumerable<int>

    public class Bit64Array : IEnumerable<ulong>
    {
        private ulong bits;

        public Bit64Array(ulong bits = 0)
        {
            this.bits = bits;
        }
        public ulong this[int index]
        {
            get
            {
                if (index < 0 || index >= 64)
                {
                    throw new IndexOutOfRangeException("The index must be in range between 0 - 63.");
                }

                return (bits >> index) & 1;
            }
            set
            {
                if (index < 0 || index >= 64)
                {
                    throw new IndexOutOfRangeException("The index must be in range between 0 - 63.");
                }

                if (value == 0)
                {
                    this.bits &= ~(1ul << index);
                }
                else if (value == 1)
                {
                    this.bits |= (1ul << index);
                }
                else
                {
                    throw new ArgumentException("Value must be 0 or 1.");
                }
            }
        }

        public IEnumerator<ulong> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return ((this.bits >> i) & 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 63; i >= 0; i--)
            {
                result.Append((this.bits >> i) & 1);
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            var otherBitArray = obj as Bit64Array;

            if (otherBitArray != null)
            {
                for (int i = 0; i < 64; i++)
                {
                    if (this[i] != otherBitArray[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Split the bits in two parts, both of them containing exactly 32 bits
        /// then XOR the two parts and the result is the hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // bits from 0 to 31
            int first32Bits = (int) (this.bits & (ulong) (0xFFFFFFFF)); // 0xFFFFFFFF == 4294967295 , in binary : 1111 1111 1111 1111 1111 1111 1111 1111
            // bits from 32 to 63
            int second32Bits = (int) (this.bits >> 32);

            return first32Bits ^ second32Bits;
        }

        public static bool operator ==(Bit64Array first, Bit64Array second)
        {
            return Bit64Array.Equals(first, second);
        }

        public static bool operator !=(Bit64Array first, Bit64Array second)
        {
            return !Bit64Array.Equals(first, second);
        }
    }
}
