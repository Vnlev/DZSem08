// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 1 | 3 4
// 3 2 1 | 3 3
// _ _ _ | 1 1
// Результирующая матрица будет:
// 19 21
// 16 19

using System.Collections.Specialized;
using System.ComponentModel;
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
            matrix[i, j] = rnd.Next(-10, 10);
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

int[,] dot(int[,] mat1, int[,] mat2)
{
    int[,] res = new int[mat1.GetLength(0), mat2.GetLength(1)];
    for (int i = 0; i < mat1.GetLength(0); ++i)
    {
        for (int j = 0; j < mat2.GetLength(1); ++j)
        {
            res[i, j] = 0;
        }
    }

    for (int i = 0; i < mat1.GetLength(0); ++i)
    {
        for (int k = 0; k < mat1.GetLength(1); ++k)
        {
            for (int j = 0; j < mat2.GetLength(1); ++j)
            {
                res[i, j] += mat1[i, k] * mat2[k, j];
            }
        }
    }
    return res;
}

int number = Prompt("Введите высоту 1-ой матрицы");
int mumber = Prompt("Введите ширину 1-ой матрицы");

int pumber = Prompt("Введите высоту 2-ой матрицы");
int qumber = Prompt("Введите ширину 2-ой матрицы");

if (mumber != pumber)
{
    Console.WriteLine("Результат не может быть выведен, произведение матриц посчитать невозможно :(");
}
else
{

    int[,] mat1 = GenerateMatrix(number, mumber);
    int[,] mat2 = GenerateMatrix(pumber, qumber);

    Console.WriteLine("1-ая матрица:");
    PrintMatrix(mat1);
    Console.WriteLine("2-ая матрица:");
    PrintMatrix(mat2);

    int[,] res = dot(mat1, mat2);

    Console.WriteLine("<------------------>");
    PrintMatrix(res);
}

