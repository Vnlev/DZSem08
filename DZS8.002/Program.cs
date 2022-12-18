// Задача 2: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

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

Console.WriteLine("<---------------->");

int min = 0;
int s = 0;
for (int c = 0; c < m; ++c)
{
    min += matrix[0, c];
}
for (int r = 1; r < n; ++r)
{
    int sum = 0;
    for (int c = 0; c < m; ++c)
    {
        sum += matrix[r, c];
    }
    if (sum < min)
    {
        s = r;
        min = sum;
    }
}

Console.WriteLine($"строка: {s}");
