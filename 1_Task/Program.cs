/* Задайте двумерный массив. Напишите программу, 
которая упорядочивает по убыванию элементы каждой строки двумерного массива.
*/

int InputInt(string message)
{
    Console.Write($"{message} -> ");
    return Convert.ToInt32(Console.ReadLine());
}

int[,] CreateMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = new Random().Next(-15, 16);
        }
    }
    return matrix;
}

int[,] RowsBubbleSorter(int[,] matrix)
{
    int temp = 0;
    for (int row = 0; row < matrix.GetLength(0); row++) // цикл, изменяющий строки
    {   
        for (int repeat = 0; repeat < matrix.GetLength(0); repeat++) // сколько цифр стоят на правильных местах
        {
            for (int column = 0; column < matrix.GetLength(1) - repeat - 1; column++)
            {
                if (matrix[row, column] < matrix[row, column + 1])
                {
                    temp = matrix[row, column];
                    matrix[row, column] = matrix[row, column + 1];
                    matrix[row, column + 1] = temp;
                }
            }
        }
    }
    return matrix;
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

int m = InputInt("Введите количество строк массива");
int n = InputInt("Введите количество столбцов массива");
int[,] matrix = CreateMatrix(m, n);
Console.WriteLine("Первоначальная матрица:");
PrintMatrix(matrix);
Console.WriteLine("Изменённая матрица:");
matrix = RowsBubbleSorter(matrix);
PrintMatrix(matrix);