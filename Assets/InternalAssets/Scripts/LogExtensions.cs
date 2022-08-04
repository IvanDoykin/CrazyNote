using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class LogExtensions
{
    public static void Log<T>(this T[] loggingMassive)
    {
        Debug.Log("Massive [" + (typeof(T)).Name + "] with " + loggingMassive.Length + " elements...");

        if (loggingMassive.Length < 10)
        {
            StringBuilder elements = new StringBuilder("");
            foreach (T element in loggingMassive)
            {
                if (element != null)
                {
                    elements.Append("[" + element.ToString() + "] ");
                }
                else
                {
                    elements.Append("[NULL]");
                }
            }
            Debug.Log(elements);
        }

        else
        {
            foreach (T element in loggingMassive)
            {
                if (element != null)
                {
                    Debug.Log("[" + element.ToString() + "]");
                }
                else
                {
                    Debug.Log("[NULL ELEMENT]");
                }
            }
        }
    }
}
