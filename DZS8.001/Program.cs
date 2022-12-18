// Задача 1: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int ReadNumber()
{
    string input = Console.ReadLine();
    int res = Convert.ToInt32(input);
    return res;
}

int Prompt(string message)
{
    Console.Write($"{message} > ");
    string input = Console.ReadLine();
    return Convert.ToInt32(input);
}

int[,] GenerateMatrix(int n, int m)
{
    int[,] matrix = new int[n, m]; 
    Random rnd = new Random();
    for (int i = 0; i < n; ++i)
    {
        for (int j = 0; j < m; ++j)
        {
            matrix[i, j] = rnd.Next(-100, 100);
        }
    }
    return matrix;
}

void PrintMatrix(int[, ] matrix)
{
    for (int i = 0;i  < matrix.GetLength(0); ++i)
    {
        for (int j = 0;j < matrix.GetLength(1); ++j)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.Write("\n");
    }
}

void Solve(int[,] matrix)
{
    for (int r = 0; r < matrix.GetLength(0); ++r)
    {
        for (int round = 0; round < matrix.GetLength(1); ++round)
        {
            for (int i = 0; i + 1 < matrix.GetLength(1); ++i)
            {
                if (matrix[r, i] < matrix[r, i + 1])
                {
                    int tmp = matrix[r, i + 1];
                    matrix[r, i + 1] = matrix[r, i];
                    matrix[r, i] = tmp;
                }
            }
        }
    }
}

int n = Prompt("Введите высоту таблицы");
int m = Prompt("Введите ширину таблицы");

int[,] matrix = GenerateMatrix(n, m);
PrintMatrix(matrix);

Console.WriteLine("<----------------------------------------------->");

Solve(matrix);

PrintMatrix(matrix);
