class Queue
{
    private int[] queue;   // Arreglo que contiene los elementos de la cola
    private int capacity;      // Tamaño máximo de la cola
    private int front;     // Índice del primer elemento
    private int rear;      // Índice del último elemento

    public Queue(int capacity)
    {
        this.capacity = capacity;
        queue = new int[capacity];
        front = 0;  // Comenzamos con el frente en 0
        rear = -1;  // Rear en -1 porque aún no hay elementos
    }

    public bool isEmpty()
    {
        return rear < front; // Si rear es menor que front, la cola está vacía
    }

    public bool isFull()
    {
        return rear == capacity - 1; // Si rear alcanza la capacidad máxima, la cola está llena
    }
    // Agrega un elemento al final de la cola
    public void Enqueue(int item)
    {
        if (isFull())
        {
            throw new Exception("La cola está llena, no se puede agregar el elemento.");
        }
        rear++;             // Movemos el índice rear al siguiente lugar
        queue[rear] = item; // Insertamos el elemento
    }

    // Quita un elemento del frente de la cola
    public int Dequeue()
    {
        if (isEmpty())
        {
            throw new Exception("La cola está vacía, no se puede eliminar ningún elemento.");
        }
        int frontItem = queue[front]; // Guardamos el primer elemento
        front++;                       // Avanzamos el frente
        return frontItem;
    }

    // Ve el primer elemento sin eliminarlo
    public int Peek()
    {
        if (isEmpty())
        {
            throw new Exception("La cola está vacía.");
        }
        return queue[front];
    }

    // Muestra todos los elementos actuales de la cola
    public void Show()
    {
        if (isEmpty())
        {
            throw new Exception("La cola está vacía.");

        }

        Console.Write("Elementos en la cola: ");
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

        Console.WriteLine("Elemento al frente que borraremos: " + myQueue.Peek());

        myQueue.Dequeue();
        myQueue.Show();
        Console.WriteLine("Se agregaran dos elementos...");
        myQueue.Enqueue(40);
        myQueue.Enqueue(50);
        myQueue.Show();
    }
}