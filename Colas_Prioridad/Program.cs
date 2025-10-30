public class PriorityQueue
{
    private int capacity;
    private Tuple<string, int>[] queue; // Arreglo para almacenar los elementos de la cola como tuplas (dato, prioridad)
    //Tupla: Puede almacenar múltiples valores de diferentes tipos en una sola estructuras, las listas y diccionarios no pueden (Diferente a python que si pueden)
    private int size;

    public PriorityQueue(int capacity)
    {
        this.capacity = capacity;
        queue = new Tuple<string, int>[capacity];
        size = 0;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public bool IsFull()
    {
        return size == capacity;
    }

    public void Enqueue(string data, int priority)
    {
        if (IsFull())
            throw new Exception("La cola está llena");

        // Creamos un nuevo elemento como tupla (dato, prioridad)
        var newElement = Tuple.Create(data, priority);

        if (IsEmpty())
        {
            queue[0] = newElement;
        }
        else
        {
            // Comenzamos desde el final del arreglo usado (último elemento insertado)
            int i = size - 1;

            // Recorremos hacia atrás mientras encontremos elementos con mayor prioridad numérica
            // (recordando que en esta implementación: menor número = mayor prioridad)
            while (i >= 0 && queue[i].Item2 > priority)
            {
                // Desplazamos el elemento actual una posición hacia adelante para hacer espacio
                queue[i + 1] = queue[i];
                i--; // Avanzamos hacia atrás
            }

            // Cuando salimos del bucle, 'i + 1' es la posición correcta para insertar el nuevo elemento
            queue[i + 1] = newElement;
        }
        size++;
    }

    public string Dequeue()
    {
        if (IsEmpty())
            throw new Exception("La cola está vacía");

        // Guardamos el dato del primer elemento (el de mayor prioridad)
        string data = queue[0].Item1;

        // Desplazamos todos los elementos una posición hacia adelante
        // para llenar el hueco que deja el primer elemento
        for (int i = 1; i < size; i++)
        {
            queue[i - 1] = queue[i];
        }

        // La última posición ahora ya no contiene un dato válido, así que la ponemos en null
        queue[size - 1] = null;
        size--;
        return data;
    }

    // Método para ver el primer elemento de la cola sin eliminarlo
    public string Peek()
    {
        // Si la cola está vacía, no hay nada que mostrar
        if (IsEmpty())
            throw new Exception("La cola está vacía");

        // Devolvemos solo el dato, no la prioridad
        return queue[0].Item1;
    }

    public void Mostrar()
    {
        if (IsEmpty())
        {
            Console.WriteLine("La cola está vacía");
            return;
        }

        for (int i = 0; i < size; i++)
        {
            Console.Write($"({queue[i].Item1}, prioridad: {queue[i].Item2}) -> ");
        }
        Console.WriteLine("");
    }
}


public class Program
{
    public static void Main()
    {
        PriorityQueue myQueue = new PriorityQueue(5);

        myQueue.Enqueue("Tarea 1", 2); // prioridad intermedia
        myQueue.Enqueue("Tarea 2", 1); // mayor prioridad (menor número)
        myQueue.Enqueue("Tarea 3", 3); // menor prioridad (mayor número)

        myQueue.Mostrar();

        // Eliminamos el elemento de mayor prioridad (menor número de prioridad)
        Console.WriteLine("Elemento desencolado por prioridad: " + myQueue.Dequeue());
        myQueue.Mostrar();

        Console.WriteLine("Segundo elemento desencolado por prioridad: " + myQueue.Dequeue());
        myQueue.Mostrar();
    }
}

