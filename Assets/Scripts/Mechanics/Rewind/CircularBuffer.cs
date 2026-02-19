using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;

public class CircularBuffer<T> //Generic Circular Buffer
{
    //Collection Itself
    private List<T> buffer;
    //capacity
    
    private int capacity;
    //Constructor - Allow me to create CircularBuffer within a given capacity
   
    public CircularBuffer(int capacity)
    {
        buffer = new List<T>(capacity);
        this.capacity = capacity;
    }

    //Public Property
    public int Count => buffer.Count;
    
    //Buffer Operations
    //================
    // 1. Push - (adding new information to the buffer)
    public void Push(T item)
    {
        if(buffer.Count >= capacity)
        {
            buffer.RemoveAt(0); //Removes the oldest Data
        }

        buffer.Add(item);
    }

    // 2. Pop -  (removing the next piece of information)
    public T Pop()
    {
        if (buffer.Count == 0) return default(T);
        
        int lastIndex = buffer.Count - 1;
        T item = buffer[lastIndex]; 
        buffer.RemoveAt(lastIndex);
        
        return item;
    }
}
