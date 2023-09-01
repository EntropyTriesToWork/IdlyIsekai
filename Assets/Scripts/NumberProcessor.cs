using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.IdlyIsekai.Numbers
{
    public class NumberProcessor : MonoBehaviour
    {
        public static string NumberToDisplayString(int num)
        {
            string val = num.ToString();
            int numLength = val.Length;
            if(numLength < 3) { return val; }
            else if(numLength < 6)
            {
                val = (num / 1000f).ToString("f1") + "K";
            }
            return val;
        }
    }
}