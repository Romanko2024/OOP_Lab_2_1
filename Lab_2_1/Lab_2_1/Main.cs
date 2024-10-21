class MainClass
{
    public static void Main(string[] args)
    {
        //тест конструктора з двовимірного масиву
        double[,] array = {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 },
            { 7.0, 8.0, 9.0 }
        };
        MyMatrix matrix1 = new MyMatrix(array);
        Console.WriteLine("тест конструктора з двовимірного масиву");
        Console.WriteLine(matrix1);

        //тест конструктора копіювання
        MyMatrix matrix2 = new MyMatrix(matrix1);
        Console.WriteLine("тест конструктора копіювання");
        Console.WriteLine(matrix2);

        //тест конструктора із зубчастого масиву
        double[][] jaggedArray = {
            new double[] { 1.1, 2.2, 3.3 },
            new double[] { 4.4, 5.5, 6.6 },
            new double[] { 7.7, 8.8, 9.9 }
        };
        MyMatrix matrix3 = new MyMatrix(jaggedArray);
        Console.WriteLine("тест конструктора із зубчастого масиву");
        Console.WriteLine(matrix3);

        //тест конструктора з масиву рядків
        string[] lines = {
            "10 20 30",
            "40 50 60",
            "70 80 90"
        };
        MyMatrix matrix4 = new MyMatrix(lines);
        Console.WriteLine("тест конструктора з масиву рядків");
        Console.WriteLine(matrix4);

        //тест конструктора з рядка
        string input = "11 12 13\n14 15 16\n17 18 19";
        MyMatrix matrix5 = new MyMatrix(input);
        Console.WriteLine("тест конструктора з рядка");
        Console.WriteLine(matrix5);

        //тест індексаторів
        Console.WriteLine("тест індексаторів: [1,1] = " + matrix1[1, 1]);
        matrix1[1, 1] = 55.0;
        Console.WriteLine("тест індексаторів: [1,1] (сетнули значення 55.0) = " + matrix1[1, 1]);

        //тест для Java-style getter і setter
        Console.WriteLine("Тест Java-style getter:");
        double element = matrix1.GetElement(1, 1); 
        Console.WriteLine($"елемент(1, 1): {element}"); 

        Console.WriteLine("Тест Java-style setter:");
        matrix1.SetElement(1, 1, 99.0); 
        Console.WriteLine($"елемент(1, 1) після SetElement(1, 1, 99.0): {matrix1.GetElement(1, 1)}");

        //тест додавання матриць
        MyMatrix matrixSum = matrix1 + matrix2;
        Console.WriteLine("сума матриць:");
        Console.WriteLine(matrixSum);

        //тест множення матриць
        double[,] array2 = {
            { 1, 2 },
            { 3, 4 },
            { 5, 6 }
        };
        MyMatrix matrix6 = new MyMatrix(array2);
        MyMatrix matrixProduct = matrix1 * matrix6;
        Console.WriteLine("добуток матриць:");
        Console.WriteLine(matrixProduct);

        //тест транспонування
        MyMatrix transposedMatrix = matrix1.GetTransponedCopy();
        Console.WriteLine("транспонована матриця:");
        Console.WriteLine(transposedMatrix);

        //тест TransponeMe
        matrix1.TransponeMe();
        Console.WriteLine("транспонування TransponeMe:");
        Console.WriteLine(matrix1);
    }
}
