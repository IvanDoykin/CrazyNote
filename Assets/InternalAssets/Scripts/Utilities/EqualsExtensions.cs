using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public static class EqualsExtensions
    {
        public static bool BoolLess(bool[] a, bool[] b)
        {
            int aLength = 0;
            int bLength = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i])
                {
                    aLength++;
                }

                if (b[i])
                {
                    bLength++;
                }
            }
            return aLength < bLength;
        }
    }
}