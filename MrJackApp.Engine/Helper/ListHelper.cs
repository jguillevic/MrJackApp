using System;
using System.Collections;
using System.Collections.Generic;

namespace MrJackApp.Engine.Helper
{
    public static class ListHelper
    {
        public static void Swap(IList list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static void Shuffle(IList list)
        {
            Random r = new Random();
            int n = list.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = r.Next(i);

                Swap(list, i, j);
            }
        }

        public static List<T> Draw<T>(IList<T> list, int count)
        {
            var result = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var item = list[0];

                list.RemoveAt(0);

                result.Add(item);
            }

            return result;
        }
    }
}
