using System;

class Queue
{
    private int[] queue;     
    private int capacity;   
    private int front;      
    private int rear;        

    public Queue(int capacity)
    {
        this.capacity = capacity;
        queue = new int[capacity];
        front = -1; 
        rear = -1; 
    }

   
    public bool IsEmpty()
    {
        return front == -1; 
    }

    
    public bool IsFull()
    {
        return rear == capacity - 1;
    }

    
    public void Enqueue(int item)
    {
        if (IsFull())
        {
            throw new Exception("La cola está llena.");
        }

        // Si la cola está vacía, movemos front a 0
        if (IsEmpty())
        {
            front = 0;
        }

        rear++;
        queue[rear] = item;

    }

   
    public int Dequeue()
    {
        if (IsEmpty())
        {
            throw new Exception("La cola está vacía.");
        }

        int removed = queue[front]; 

        // Desplazamos todos los elementos una posición hacia adelante
        for (int i = 0; i < rear; i++)
        {
            queue[i] = queue[i + 1];
        }

        rear--; // Disminuye el índice del último elemento

        // Si la cola quedó vacía después de eliminar, reiniciamos los índices
        if (rear < 0)
        {
            front = -1;
            rear = -1;
        }
        return removed;
    }

    
    public void Show()
    {
        if (IsEmpty())
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        Console.Write("Cola actual: ");
        for (int i = front; i <= rear; i++)
        {
            Console.Write(queue[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queue myQueue = new Queue(5);

        myQueue.Enqueue(10);
        myQueue.Enqueue(20);
        myQueue.Enqueue(30);
        myQueue.Show();

        Console.WriteLine("Eliminamos un elemento");
        myQueue.Dequeue();
        myQueue.Show();

        Console.WriteLine("Eliminamos dos elementos");
        myQueue.Dequeue();
        myQueue.Dequeue();
        myQueue.Show();

        Console.WriteLine("Agregamos un elemento");
        myQueue.Enqueue(40);
        myQueue.Show();
    }
}
