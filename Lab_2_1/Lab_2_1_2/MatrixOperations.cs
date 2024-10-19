public partial class MyMatrix
{
    //operator + додавання двох матриць (лише якщо вони мають однаковий розмір)
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    { 

    }
    //operator * множення двох матриць (лише якщо кількість стовпчиків першої
    //дорівнює кількості рядків другої)
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    { 

    }
    //Метод(не статичний; private або protected) GetTransponedArray(), що
    //повертає новостворений масив double[,] (не MyMatrix, а просто масив), у якому
    //вміст елементів транспонований відносно тієї матриці, для якої він викликався
    private double[,] GetTransponedArray()
    { 

    }
    //Метод (не статичний) MyMatrix GetTransponedCopy(), який би створював
    //новий примірник MyMatrix, у якому вміст матриці транспонований відносно тієї,
    //для якої він викликався; технічну роботу зі власне транспонування не повторювати,
    //а використати результат GetTransponedArray()
    public MyMatrix GetTransponedCopy()
    {
        return new MyMatrix(GetTransponedArray());
    }
    //Метод (не статичний) void TransponeMe(), який би замінював матрицю, для якої
    //викликається, на транспоновану(теж використати GetTransponedArray(), але
    //щоб у результаті змінився сам this-примірник MyMatrix).
    public void TransponeMe()
    {
        data = GetTransponedArray();
    }
}
