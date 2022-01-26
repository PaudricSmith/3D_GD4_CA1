using System.Collections.Generic;
using UnityEngine;


public abstract class ListVariableSO<T> : NumberVariable<T>
{
    [SerializeField]
    private List<T> list;

    public void Add(T obj)
    {
        list.Add(obj);
    }

    public void Remove(T obj)
    {
        list.Remove(obj);
    }

    public int Count()
    {
        return list.Count;
    }

    public void Clear()
    {
        list.Clear();
    }

    //Sort(comparable), Remove(predicate)
}