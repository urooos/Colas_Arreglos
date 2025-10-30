public class CircularQueue
{
    private int capacity; // Capacidad máxima de la cola
    private int[] queue;  // Arreglo que representa la cola
    private int front;    // Índice del primer elemento
    private int rear;     // Índice del último elemento

    public CircularQueue(int capacity)
    {
        this.capacity = capacity; // Asignamos la capacidad máxima
        queue = new int[capacity]; // Creamos el arreglo fijo
        front = -1; // En la circular front es -1 para difereniciar de cuando esta vacia o llena
        rear = -1;
    }

    public bool IsEmpty()
    {
        return front == -1; // Verdadero si la cola está vacía
    }

    public bool IsFull()
    {
        // Si al avanzar rear una posición (de forma circular) es igual a front, la cola está llena
        return (rear + 1) % capacity == front;
    }

    public void Enqueue(int data)
    {
        if (IsFull())
            throw new Exception("La cola está llena");

        // Si está vacía, el primer elemento se inserta en la posición 0
        if (IsEmpty())
            front = 0;

        // Avanzamos rear una posición circular
        rear = (rear + 1) % capacity;

        // Insertamos el dato en la posición rear
        queue[rear] = data;
    }

    public int Dequeue()
    {
        if (IsEmpty())
            throw new Exception("La cola está vacía");

        // Guardamos el valor que está al frente
        int dato = queue[front];

        // Si solo había un elemento, reiniciamos la cola
        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else
        {
            // Avanzamos front una posición circular
            front = (front + 1) % capacity;
        }

        return dato; // Devolvemos el valor eliminado
    }

    public int Peek()
    {
        if (IsEmpty())
            throw new Exception("La cola está vacía");

        return queue[front]; // Retorna el primer elemento sin eliminarlo
    }

    public void Show()
    {
        if (IsEmpty())
        {
            Console.WriteLine("La cola está vacía");
            return;
        }

        int i = front; // Apuntador auxiliar que inicia en front
        while (true)
        {
            Console.Write(queue[i] + ", ");
            if (i == rear)
                break;
            i = (i + 1) % capacity; // Avanzamos de forma circular
        }

        Console.WriteLine();
    }

}

public class Program
{
    public static void Main()
    {
        CircularQueue myQueue = new CircularQueue(5); // Creamos una cola de capacidad 5

        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);
        myQueue.Show();

        Console.WriteLine("Primer elemento: " + myQueue.Peek());
        Console.WriteLine("Elemento eliminado: " + myQueue.Dequeue());

        myQueue.Show();
        Console.WriteLine("Nuevo primer elemento: " + myQueue.Peek());
        Console.WriteLine("Agregamos dos elementos...");

        myQueue.Enqueue(4);
        myQueue.Enqueue(5);
        myQueue.Enqueue(6);

        myQueue.Show();
        Console.WriteLine("Primer elemento: " + myQueue.Peek());
    }
}