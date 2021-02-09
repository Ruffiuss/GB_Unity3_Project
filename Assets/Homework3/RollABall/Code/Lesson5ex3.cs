using System.Collections.Generic;
using UnityEngine;
using System;


namespace RollABall
{
    internal sealed class Lesson5ex3 : MonoBehaviour
    {
        #region Fields

        private List<int> list;
        private System.Random size;

        #endregion


        #region Methods

        private void Awake()
        {
            size = new System.Random();
            list = new List<int>(size.Next(1, 1000));
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(size.Next(0,9)); //0-9 (0x0030, 0x0039); 0-Z (0x030, 0x005A);
            }


            //Debug
            ShowElements(list);

            CheckIntegerDuplicates(list);
        }

        private void ShowElements(List<int> integers)
        {
            string all = "";
            foreach (var item in integers)
            {
                all += item.ToString()+'|';
            }
            Debug.Log($"All elems of list: {all}\n");
        }

        private void CheckIntegerDuplicates(List<int> integers)
        {
            Dictionary<int, int> duplicates = new Dictionary<int, int>();
            for (int i = 0; i < integers.Count; i++)
            {
                int key = integers[i];
                if (!duplicates.ContainsKey(key))
                {
                    duplicates.Add(key, 1);
                }
                else
                {
                    duplicates[key] += 1;
                }                
            }

            foreach (var key in duplicates.Keys)
            {
                Debug.Log($"Key: {key}| Value: {duplicates[key]}\n");
            }
        }

        #endregion
    }
}