using System.Text;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public static class LogExtensions
    {
        public static void Log<T>(this T[] loggingMassive)
        {
            Debug.Log("Massive [" + typeof(T).Name + "] with " + loggingMassive.Length + " elements...");

            if (loggingMassive.Length < 10)
            {
                var elements = new StringBuilder("");
                foreach (var element in loggingMassive)
                {
                    if (element != null)
                    {
                        elements.Append("[" + element + "] ");
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
                foreach (var element in loggingMassive)
                {
                    if (element != null)
                    {
                        Debug.Log("[" + element + "]");
                    }
                    else
                    {
                        Debug.Log("[NULL ELEMENT]");
                    }
                }
            }
        }
    }
}