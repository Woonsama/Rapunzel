using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
최근 수정 일 : 2020.09.21
최근 수정 인 : Hotbar
최근 수정 작업 : 

설명 : Object Pooling
*/

public class ObjectPoolingManager
{
    public static void MoveIndex<T>(List<T> list, int oldIndex, int newIndex)
    {
        T temp = list[oldIndex];
        list.RemoveAt(oldIndex);
        list.Insert(newIndex, temp);
    }

    public static void MoveFirstToEnd<T>(List<T> list)
    {
        T temp = list[0];
        list.Add(temp);
        list.RemoveAt(0);
    }
}
