using System.Collections.Generic;
using UnityEngine;


public abstract class ListVariableSO<T> : NumberVariable<T>
{
    [SerializeField]
    private List<T> list;

    public List<T> List { get => list; set => list = value; }

    public void Add(T obj)
    {
        List.Add(obj);
    }

    public void Remove(T obj)
    {
        List.Remove(obj);
    }

    public int Count()
    {
        return List.Count;
    }

    public void Clear()
    {
        List.Clear();
    }

    //Sort(comparable), Remove(predicate)
}