/* Задайте две матрицы. Напишите программу, 
которая будет находить произведение двух матриц. */

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

bool IsMatrixMultiplicationPossible(int[,] matrix1, int[,] matrix2)
{
    if (matrix1.GetLength(1) == matrix2.GetLength(0)) return true;
    else return false;
}

int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int NewElement = 0;
    int[,] NewMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < NewMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < NewMatrix.GetLength(1); j++)
        {
            NewElement = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                NewElement += matrix1[i, k] * matrix2[k, j];
            }
            NewMatrix[i, j] = NewElement;
        }
    }
    return NewMatrix;
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

int m = InputInt("Введите количество строк первой матрицы");
int n = InputInt("Введите количество столбцов первой матрицы");
int[,] matrix1 = CreateMatrix(m, n);
m = InputInt("Введите количество строк второй матрицы");
n = InputInt("Введите количество столбцов второй матрицы");
int[,] matrix2 = CreateMatrix(m, n);
Console.WriteLine("Первая матрица:");
PrintMatrix(matrix1);
Console.WriteLine("Вторая матрица:");
PrintMatrix(matrix2);
if (IsMatrixMultiplicationPossible(matrix1, matrix2))
{
    int[,] NewMatrix = MatrixMultiplication(matrix1, matrix2);
    Console.WriteLine("Результат умножения эти матриц:");
    PrintMatrix(NewMatrix);
}
else
{
    Console.WriteLine("Эти матрицы нельзя умножить");
}
