using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    
    public class Bits
    {

        #region Addition

        public static int Add(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            //if we do bit wise exclusive or, it will add with unqiue bits (only 1 if only one is 1)
            int result = a ^ b;

            //now we need to perform carry by doing bitwise and and shift one
            int carry = (a & b) << 1;

            //now continue to add result with carry (if carry causes another carry then we need to perform above operation
            return Add(result, carry);
        }

        /// <summary>
        /// Russian Peasant Math
        /// We divide one number by two (right shift) as we multiply the other number by two (left shift)
        /// If divided number has a 1 bit, then we add the multiplied number to total
        /// 
        /// 9 * 8 (ignore)
        /// 18, 4 (ignore)
        /// 36, 2 (ignore)
        /// 72, 1 (add)
        /// 
        /// 8 * 9 (add) 8...this is same as (16 * 4) + 8
        /// 16, 4 (ignore)
        /// 32, 2 (ignore)
        /// 64, 1 (add) 8 + 64
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Multiply(int a, int b)
        {
            int c = 0;
            while (b != 0)
            {
                if ((b & 1) == 1)
                {
                    c += a;
                }
                a = a << 1;
                b = b >> 1;
            }
            return c;
        }

        #endregion

    }

}
