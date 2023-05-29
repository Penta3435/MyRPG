using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

public class TestIEnumerable : MonoBehaviour
{
    Vector3 current;
    [SerializeField] float distance;
    private void Start()
    {
        current = transform.position;
        Enumerable enumerable = new Enumerable(3);
        enumerable.AddElement(0, "hola");
        enumerable.AddElement(1, false);
        enumerable.AddElement(2, 19.2f);

        foreach(object o in enumerable)
        {
            print(o);
        }
    }
}

public class Enumerable : IEnumerable
{
    object[] elementos;
    public Enumerable(int numElementos)
    {
        elementos = new object[numElementos];
    }
    public void AddElement(int index, object element)
    {
        elementos[index] = element;
    }

    public IEnumerator GetEnumerator()
    {
        Debug.Log("getenuymeraor");
        return new TestIEnumerablesEnumerator(elementos);
    }
}

public class TestIEnumerablesEnumerator : IEnumerator
{

    object[] array;
    int currentIndex = -1;
    public TestIEnumerablesEnumerator(object[] array)
    {
        this.array = array;
    }

    public object Current { get { Debug.Log("get"); return array[currentIndex]; } }
    public void Reset()
    {
        Debug.Log("reset");
        currentIndex = -1;
    }
    public bool MoveNext()
    {
        Debug.Log("MoveNext");
        if (currentIndex >= array.Length-1)
        {
            return false;
        }
        else 
        {
            currentIndex++;
            return true; 
        }
    }
}
