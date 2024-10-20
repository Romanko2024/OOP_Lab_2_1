public partial class MyMatrix
{
    //operator + додавання двох матриць (лише якщо вони мають однаковий розмір)
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        var result = new MyMatrix(new double[a.Height, a.Width]); //матриця що утвор. від додавання

        for (int i = 0; i < a.Height; i++) 
            for (int j = 0; j < a.Width; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }
    //operator * множення двох матриць (лише якщо кількість стовпчиків першої
    //дорівнює кількості рядків другої)
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        var result = new MyMatrix(new double[a.Height, b.Width]);
        //проходить по всіх рядках першої матриці
        for (int i = 0; i < a.Height; i++) //по рядках матриці а
            //проходить по всіх стовпцях другої матриці
            for (int j = 0; j < b.Width; j++)  //по елем. матриці б.
                //проходить по всіх елементах рядка першої і стовпця другої
                for (int k = 0; k < a.Width; k++) //по елем. матриці а.
                    result[i, j] += a[i, k] * b[k, j];

        return result;
    }
    //Метод(не статичний; private або protected) GetTransponedArray(), що
    //повертає новостворений масив double[,] (не MyMatrix, а просто масив), у якому
    //вміст елементів транспонований відносно тієї матриці, для якої він викликався
    private double[,] GetTransponedArray()
    {
        var transposed = new double[Width, Height];

        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                transposed[j, i] = data[i, j];

        return transposed;
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
