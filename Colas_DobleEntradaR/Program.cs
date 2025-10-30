public class InputRestrictedDeque
{
    private int capacity;
    private int[] deque; // Arreglo que representa la deque
    private int front;
    private int rear;

    public InputRestrictedDeque(int capacity)
    {
        this.capacity = capacity;
        deque = new int[capacity]; // Definimos el tamaño del arreglo
        front = -1; // Los índices empiezan en -1
        rear = -1;
    }

    public bool IsEmpty()
    {
        return front == -1; // Si el índice del frente es -1, la deque está vacía
    }

    public bool IsFull()
    {
        return (rear + 1) % capacity == front; // Si el siguiente índice del rear es igual al front, la deque está llena
    }

    public void InsertRear(int data)
    {
        if (IsFull())
            throw new Exception("Deque is full");

        if (IsEmpty())
            front = 0;

        rear = (rear + 1) % capacity; // Incrementamos el índice del rear circularmente
        deque[rear] = data; // Asignamos el valor en la posición del rear
    }

    public int DeleteFront()
    {
        if (IsEmpty())
            throw new Exception("Deque is empty");

        int data = deque[front]; // Guardamos el valor que vamos a eliminar

        if (front == rear)
        {
            front = -1;
            rear = -1;
        }
        else
        {
            front = (front + 1) % capacity;
        }

        return data; // Devolvemos el valor eliminado
    }

    public int DeleteRear()
    {
        if (IsEmpty())
            throw new Exception("Deque is empty");

        int data = deque[rear]; // Guardamos el valor que vamos a eliminar

        if (front == rear) // Si solo hay un elemento
        {
            front = -1;
            rear = -1;
        }
        else
        {
            rear = (rear - 1 + capacity) % capacity; // Decrementamos el índice del rear circularmente
        }

        return data; // Devolvemos el valor eliminado
    }

    public int PeekFront()
    {
        if (IsEmpty())
            throw new Exception("Deque is empty");

        return deque[front]; // Devolvemos el valor en la posición del front sin eliminarlo
    }

    public int PeekRear()
    {
        if (IsEmpty())
            throw new Exception("Deque is empty");

        return deque[rear]; // Devolvemos el valor en la posición del rear sin eliminarlo
    }

    public void Show()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Deque is empty");
            return;
        }

        int i = front;
        while (true)
        {
            Console.Write(deque[i] + ", ");
            if (i == rear)
                break;
            i = (i + 1) % capacity;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Solo podemos insertar por el rear pero eliminar por ambos extremos");
        InputRestrictedDeque myDeque = new InputRestrictedDeque(3); // Creamos una instancia de la deque con capacidad 5

        myDeque.InsertRear(10);
        myDeque.InsertRear(20);
        myDeque.Show(); // Mostramos los elementos

        myDeque.InsertRear(30);
        Console.WriteLine("Insertado desde rear: 30");
        myDeque.Show();

        Console.WriteLine("Primer elemento: " + myDeque.PeekFront()); // Mostramos el front
        Console.WriteLine("Último elemento: " + myDeque.PeekRear()); // Mostramos el rear

        Console.WriteLine("Eliminamos desde Front: " + myDeque.DeleteFront()); // Eliminamos del front
        myDeque.Show();

        Console.WriteLine("Eliminamos desde Rear: " + myDeque.DeleteRear()); // Eliminamos del rear
        myDeque.Show();
    }

}