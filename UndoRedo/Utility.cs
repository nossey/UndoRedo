using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoiRedo
{
    static class Utility
    {

        /// <summary>
        /// TODO:to be templated
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInRange(int min, int max, int value)
        {
            return min <= value && value <= max;
        }

        /// <summary>
        /// TODO:to be templated
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Clamp(int min, int max, int value)
        {
            if (min > value)
                return min;
            if (max < value)
                return max;

            return value;
        }
    }
}
