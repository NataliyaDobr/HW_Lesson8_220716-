// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
int Prompt(string message)
{
    System.Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,] GenerateArray(int rows, int columns, int min, int max)
{
    int[,] answer = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            answer[i, j] = rnd.Next(min, max + 1);
        }
    }
    return answer;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        System.Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");
        }
    }
    System.Console.WriteLine();
}

int[] SumRowElement(int[,] array)
{
    int[] SumRow = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        SumRow[i] = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            SumRow[i] = SumRow[i] + array[i, j];
        }
    }
    return SumRow;
}

void PrintArrayOne(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.Write($"{array[i]}; ");
    }
    System.Console.WriteLine();
}

void MinArrayElem(int[] array)
{
    int minElem = array[0];
    int k = 0;
    for (int i = 1; i < array.Length; i++)
    {
     if (array[i]<minElem) {minElem = array[i]; k = i;}
    }
    System.Console.WriteLine($"Номер строки с наименьшей суммой элементов - {k+1}");
}


int columns = Prompt("введите количество столбцов > ");
int rows = Prompt("Введите количество строк (больше чем столбцов) > ");
if (rows>columns) {
int[,] myArray = GenerateArray(rows, columns, 0, 10);
PrintArray(myArray);
int[] ArraySum = SumRowElement(myArray);
PrintArrayOne(ArraySum);
MinArrayElem(ArraySum);
}
else {System.Console.WriteLine("Строк должно быть больше, чем столбцов");}