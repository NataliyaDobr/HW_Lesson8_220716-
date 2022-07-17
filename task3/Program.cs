// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, заданы 2 массива:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// и
// 1 5 8 5
// 4 9 4 2
// 7 2 2 6
// 2 3 4 7
//Их произведение будет равно следующему массиву:
// 1 20 56 10
// 20 81 8 6
// 56 8 4 24
// 10 6 24 49
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

int[,] MultArray(int[,] arrayF, int[,] arrayS)
{
    int[,] SumRow = new int[arrayF.GetLength(0), arrayS.GetLength(1)];
    for (int i = 0; i < arrayF.GetLength(0); i++)
    {
        for (int j = 0; j < arrayS.GetLength(1); j++)
        {
            SumRow[i, j] = 0;
            for (int k = 0; k < arrayF.GetLength(1); k++)
            {
                SumRow[i, j] = SumRow[i, j] + arrayF[i, k] * arrayS[k, j];
            }
        }
    }
    return SumRow;
}

int columnsFirst = Prompt("введите количество столбцов первой матрицы > ");
int rowsFirst = Prompt("Введите количество строк первой матрицы > ");
int[,] FirstArray = GenerateArray(rowsFirst, columnsFirst, 0, 10);

int columnsSecond = Prompt("введите количество столбцов второй матрицы > ");
int rowsSecond = Prompt("Введите количество строк второй матрицы = количеству столбцов первой> ");
int[,] SecondArray = GenerateArray(rowsSecond, columnsSecond, 0, 10);

if (columnsFirst == rowsSecond)
{
    PrintArray(FirstArray);
    PrintArray(SecondArray);
    int[,] resultMultArray = MultArray(FirstArray, SecondArray);
    PrintArray(resultMultArray);
}
else System.Console.WriteLine("такие матрицы перемножить невозможно");
