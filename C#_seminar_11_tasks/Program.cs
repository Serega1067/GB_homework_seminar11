/*
Задача: 
Заданы 2 массива: info и data. В массиве info хранятся двоичные 
представления нескольких чисел (без разделителя). В массиве data 
хранится информация о количестве бит, которые занимают числа из 
массива info. Напишите программу, которая составит массив 
десятичных представлений чисел массива data с учётом информации 
из массива info.

Комментарий: первое число занимает 2 бита (01 -> 1); второе число 
занимает 3 бита (111 -> 7); третье число занимает 3 бита (000 -> 0; 
четвёртое число занимает 1 бит (1 -> 1).

Дополнить решение домашней задачи прошлого семинара, добавив 
возможность ввода массивов info и data пользователем. Проработать 
возможные частные случаи несоответствия данных в этих массивах.

Пример:

входные данные:
data = {0, 1, 1, 1, 1, 0, 0, 0, 1 }
info = {2, 3, 3, 1 }

выходные данные:
1, 7, 0, 1
*/

void PrintConvertNumber(int[] argData, int[] argInfo)
{
    int count = 0;
    int[] newData = argData.Concat(CheckingLengthOfArray(argData, argInfo)).ToArray();
    Console.WriteLine("Выходные данные:\nЧисла преобразованные " +
                      "из двоичных в десятичные");
    for (int i = 0; i < argInfo.Length; i++)
    {
        double[] numberBin = new double[argInfo[i]];
        for (int j = count; j < count + argInfo[i]; j++)
        {
            numberBin[j - count] = newData[j];
        }
        count += argInfo[i];

        Console.Write(ConvertBinToDec(numberBin));

        if (i == argInfo.Length - 1) Console.WriteLine();
        else Console.Write(", ");
    }
}

double ConvertBinToDec(double[] argBin)
{
    double numberDec = 0;
    for (int i = 0; i < argBin.Length; i++)
    {
        numberDec += argBin[i] * Math.Pow(2, argBin.Length - 1 - i);
    }
    return numberDec;
}

int[] CheckingLengthOfArray(int[] argData, int[] argInfo)
{
    int sumInfo = 0;
    for (int i = 0; i < argInfo.Length; i++)
    {
        sumInfo += argInfo[i];
    }
    if (argData.Length == sumInfo)
    {
        Console.WriteLine("data == info");
        int[] tempArray = new int[0];
        return tempArray;
    }
    if (argData.Length > sumInfo)
    {
        Console.WriteLine("data > info");
        Console.WriteLine("В массиве data " +
                          $"{argData.Length - sumInfo} " +
                          "элемента неучтённых в массиве info\n" +
                          "Вот эти элементы:");
        for (int i = sumInfo; i < argData.Length; i++)
        {
            Console.Write(argData[i] + " ");
        }
        Console.WriteLine();
        int[] tempArray = new int[0];
        return tempArray;
    }
    if ( argData.Length < sumInfo)
    {
        Console.WriteLine("data < info");
        Console.WriteLine("В массиве data не хватает данных, " +
                          "чтобы перевести все двоичные число в " +
                          " десятичные");
        Console.WriteLine("Предположим что недостоющие числа " +
                          "в массиве data равны 0");
        int[] tempArray = new int[sumInfo - argData.Length];
        return tempArray;
    }
    int[] array = new int[0];
    return array;
}

int[] ConvertStringInArray(string arg)
{
    int[] array = new int[arg.Length];
    for (int i = 0; i < arg.Length; i++)
    {
        array[i] = Convert.ToInt32($"{arg[i]}");
    }
    return array;
}

Console.WriteLine("Введите числа в двоичном виде размером " +
                  "не более 9 элементов каждое:");
var dataString = Console.ReadLine();
// Не разобралья как исправить незначительную ошибку со строками
// int[] data = ConvertStringInArray(dataString); и
// int[] info = ConvertStringInArray(infoString);
// Таже ошибка была в строках 
// var dataString = Console.ReadLine(); и
// var infoString = Console.ReadLine();
// исправил эту ошибку заменив int на var при объявлении переменной

int[] data = ConvertStringInArray(dataString);
data = ConvertStringInArray(dataString);

Console.WriteLine("Входные данные data:");
for (int i = 0; i < data.Length; i++)
{
    Console.Write(data[i]);
}
Console.WriteLine();

Console.WriteLine("Введите из скольки элементов, " +
                  "не равно 0 и не более 9 элементов каждое, " + 
                  "состоит каждое двоичное число:");
var infoString = Console.ReadLine();
int[] info = ConvertStringInArray(infoString);

Console.WriteLine("Входные данные info:");
for (int j = 0; j < info.Length; j++)
{
    Console.Write(info[j]);
}
Console.WriteLine();

Console.WriteLine("Перевести двоичные числа из массива data в " +
                  "десятичные");

PrintConvertNumber(data, info);
