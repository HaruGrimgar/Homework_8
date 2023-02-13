/* Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов. */

int InputInt(string message)
{
    Console.Write($"{message} -> ");
    return Convert.ToInt32(Console.ReadLine());
}

int[,] CreateSquareMatrix(int size)
{
    int[,] matrix = new int[size, size];
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            matrix[i, j] = new Random().Next(-50, 51);
        }
    }
    return matrix;
}

int[] SmallestSumArrayInMatrix(int[,] matrix)
{
    int smallestSum = 1000000; // в случае больших чисел, можно посчитать сумму первой строки и присвоить этой переменной
    int smallestRowIndex = 0;
    int size = matrix.GetLength(0);
    for (int i = 0; i < size; i++)
    {
        int sum = 0;
        for (int j = 0; j < size; j++)
        {
            sum += matrix[i, j];
        }
        Console.Write($"{sum} \t");
        if (sum < smallestSum)
        {
            smallestSum = sum;
            smallestRowIndex = i;
        }
    }
    Console.WriteLine();
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = matrix[smallestRowIndex, i];
    }
    return array;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]}\t");
        }
        Console.WriteLine();
    }
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"{array[i]}\t");
        }
    Console.WriteLine();
}

int size = InputInt("Введите количество строк массива");
int[,] matrix = CreateSquareMatrix(size);
Console.WriteLine("Матрица:");
PrintMatrix(matrix);
Console.WriteLine("Сумма рядов :"); // для проверки
int[] array = SmallestSumArrayInMatrix(matrix);
Console.WriteLine("Строка матрицы с наименьшой суммой элементов :");
PrintArray(array);