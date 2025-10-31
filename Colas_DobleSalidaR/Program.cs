public class OutputRestrictedDeque
{
    private int capacity;
    private int[] deque; // Arreglo que representa la deque
    private int front;
    private int rear;

    public OutputRestrictedDeque(int capacity)
    {
        this.capacity = capacity;
        deque = new int[capacity]; // Inicializamos el arreglo con el tamaño dado
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

    public void InsertFront(int data)
    {
        if (IsFull())
            throw new Exception("Deque is full");

        if (IsEmpty())
        {
            front = 0;
            rear = 0;
        }
        else
        {
            front = (front - 1 + capacity) % capacity;
        }

        deque[front] = data;
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

        if (front == rear) // Si solo hay un elemento
        {
            front = -1;
            rear = -1;
        }
        else
        {
            front = (front + 1) % capacity; // Incrementamos el índice del front circularmente
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

        int h = front;
        while (true)
        {
            Console.Write(deque[h] + ", ");
            if (h == rear) // Rompe el ciclo cuando llegue al rear
                break;
            h = (h + 1) % capacity; // Movemos i al siguiente índice de forma circular
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podemos insertar por ambos lados pero eliminar solo por el frente");
        OutputRestrictedDeque myDeque = new OutputRestrictedDeque(3); // Creamos una instancia con capacidad 3

        myDeque.InsertRear(1);
        myDeque.Show(); // Mostramos la deque

        myDeque.InsertRear(2);
        Console.WriteLine("Agregamos por rear: 2");
        myDeque.Show();

        myDeque.InsertFront(3);
        Console.WriteLine("Agregamos por front: 3");
        myDeque.Show();

        Console.WriteLine("Primer elemento: " + myDeque.PeekFront()); // Mostramos front
        Console.WriteLine("Último elemento: " + myDeque.PeekRear()); // Mostramos rear

        Console.WriteLine("Elemento eliminado por Front: " + myDeque.DeleteFront()); // Eliminamos del front
        myDeque.Show();
    }
}
