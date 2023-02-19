HWGBSeminar7();
void HWGBSeminar7()
{
    while (true)
    {
        Console.WriteLine("Введите  номера задачи 47 ,50, 52 , 62 или exit для выхода ");
        string task = Console.ReadLine();
        switch (task)
        {
            case "47":
                Console.Clear(); Console.WriteLine("Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
                Task47(); break;
            case "50":
                Console.Clear(); Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
                Task50(); break;
            case "52":
                Console.Clear(); Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
                Task52(); break;
            case "62":
                Console.Clear(); Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");
                Task62(); break;
            case "exit": return;
            default: Console.Clear(); Console.WriteLine("Неверное значение"); break;
        }
    }
}



// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.

// 0,5 7 -2 -0,2

// 1 -3,3 8 -9,9

// 8 7,8 -7,1 9
void Task47()
{
    TaskNum(47);
    int numberM = SetNumberInt("Введите число m : ");// 5 - 10
    int numberN = SetNumberInt("Введите число n: ");

    ShowArray2DDouble(GetMatrixDouble(numberM, numberN, 10, -10, "y")); // 56-58(ShowArray) 227-247(GetMatrix)
}

// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

void Task50()
{
    TaskNum(50);

    int numberRows = SetNumberInt("Введите количество строк ");
    int numberCol = SetNumberInt("Введите количество колонн");
    int[,] Array50 = GetMatrixInt(10, 10, 9, 1);
    ShowArray2DInt(Array50);
    CheckNumInArray(Array50, numberRows, numberCol);

    void CheckNumInArray(int[,] array, int numberRows, int numberCol)
    {
        if (numberRows >= 0 && numberRows < array.GetLength(0)
        && numberCol >= 0 && numberCol < array.GetLength(1))
        { Console.WriteLine($"Такого число есть {array[numberRows, numberCol]}"); }
        else System.Console.WriteLine("Такого числа нет в массиве");
    }
}

// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3. // статик l(columns) и проверяем i(rows) 

void Task52()
{
    TaskNum(52);

    int[,] Array52 = GetMatrixInt(8, 2, 10, -10);// 214-226
    ShowArray2DInt(Array52);
    System.Console.WriteLine();
    AverageColumnsInArray(Array52);
    void AverageColumnsInArray(int[,] array)
    {
        int count = 0;
        double result = 0;
        double Res = 0;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            count++;
            for (int l = 0; l < array.GetLength(0); l++)
            {
                result = result + array[l, i];
            }
            Res = result / array.GetLength(0);
            Res = Math.Round(Res, 3);
            System.Console.WriteLine($"average столбца {count} : {Res}");
            result = 0;
        }
    }
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void Task62()
{
    TaskNum(62);

    int n = 4;
    int[,] matrix = new int[n, n];

    int count = 1;
    int row = 0; int col = 0;

    spiralMatrix(matrix, ref count);

    ShowArray2DInt(matrix);

    int[,] spiralMatrix(int[,] matrix, ref int count)
    {
        if (count <= matrix.GetLength(0) * matrix.GetLength(1))
        {
            matrix[row, col] = count;
            count++;
            if (row <= col + 1 && row + col < matrix.GetLength(1) - 1) col++;
            else if (row < col && row + col >= matrix.GetLength(0) - 1) row++;
            else if (row >= col && row + col > matrix.GetLength(1) - 1) col--;
            else row--;
            spiralMatrix(matrix, ref count);
        }
        return matrix;
    }
}

// побочные Методы 

void ShowArray2DInt(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int l = 0; l < matrix.GetLength(1); l++)
        {
            System.Console.Write(matrix[i, l] + " ");
        }

        System.Console.WriteLine();
    }
}

int[,] GetMatrixInt(int rows, int columns, int max, int min)//создание двумерного массив Int с мин и макс значениями
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int l = 0; l < columns; l++)
        {
            matrix[i, l] = new Random().Next(min, max + 1);
        }
    }
    return matrix;
}

int SetNumberInt(string text)
{
    Console.WriteLine(text);
    int number = int.Parse(Console.ReadLine());
    return number;
}

int RandomSign(string sign)//если "Yes" то числа могут иметь рандомный знак если любое другое то только +
{
    int randomSign = 0;
    int signMinus = 1;
    if (sign == "Yes" || sign == "yes" || sign == "y")
    {
        randomSign = new Random().Next(0, 2);
        if (randomSign == 1)
        {
            signMinus = -1;
        }
    }
    return signMinus;
}

double[,] GetMatrixDouble(int rows, int columns, int max, int min, string sign) // двумерный массив double мин макс и случ знаком
{
    double signMinus = 1;

    double[,] matrix = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int l = 0; l < columns; l++)
        {
            signMinus = Convert.ToDouble(RandomSign(sign));

            double fraction = new Random().Next(1, 10);
            double fraction100 = fraction / 100;
            double whole = new Random().Next(min, max + 1);
            double Resulte = whole + fraction100;
            matrix[i, l] = Resulte * signMinus;
        }
    }
    return matrix;
}

void ShowArray2DDouble(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int l = 0; l < matrix.GetLength(1); l++)
        {
            System.Console.Write(matrix[i, l] + " ");
        }

        System.Console.WriteLine();
    }
}

void TaskNum(int number)// Вывод какой номер задания 
{
    System.Console.WriteLine($"__Задание {number}___");
}
