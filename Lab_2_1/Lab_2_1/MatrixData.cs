public partial class MyMatrix
{
    //масив із власне елементами матриці
    private double[,] data;
    //Конструктори:

    //копіюючий з іншого примірника цього самого класу MyMatrix;
    public MyMatrix(MyMatrix other)
    {
        int height = other.Height; // кільк. рядків з інш. об'єкта
        int width = other.Width;   // кільк. стовбців
        //ініціаілзаця нового масиву (розміри з other)
        data = new double[height, width];
        //в новий масив  копіює елементи з other
        Array.Copy(other.data, data, other.data.Length);
    }
    //з двовимірного масиву типу double[,];
    public MyMatrix(double[,] array)
    {
        data = new double[array.GetLength(0), array.GetLength(1)];
        Array.Copy(array, data, array.Length);
    }
    //з «зубчастого» масиву double-ів, якщо він фактично прямокутний;
    public MyMatrix(double[][] jaggedArray)
    {
        int height = jaggedArray.Length;   //по куількості рядків
        int width = jaggedArray[0].Length; //по кільк. ел. у нульовому рядку
        //перевірка прямокутності
        if (jaggedArray.Any(row => row.Length != width)) //any з LINQ
            throw new ArgumentException("Зубчастий масив не прямокутний")
        //ініц. двовимірного масиву з розмірами зубчатого
        data = new double[height, width];
        //копіювання
        for (int i = 0; i < height; i++)  //по кожному рядку
        {
            Array.Copy(jaggedArray[i], 0, data, i * width, width); //i * width --початок з першого елемента в рядку до +width ел рядку (останнього)
        }

    }
    //з масиву рядків, якщо фактично ці рядки містять записані через пробіли та/або
    //числа, а кількість цих чисел у різних рядках однакова.
    public MyMatrix(string[] lines)
    {
        //розділяємо нульовий рядок на числа і заміряємо довжину
        string[] firstLineNumbers = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        int width = firstLineNumbers.Length;
        //ініц. двовим. масив
        int height = lines.Length;
        data = new double[height, width];
        //цикл обробки рядків
        for (int i = 0; i < height; i++)
        {
            string[] numbers = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //розділяємо рядок
            if (numbers.Length != width)
                throw new ArgumentException("Масив не прямокутний"); //перевіряємо чи він такий як і нульовий
            for (int j = 0; j < width; j++) // поеелеметно переписуємо з рядка у відповідний рядок масиву
                data[i, j] = double.Parse(numbers[j]);
        }
    }
    //з рядка, що містить як пробіли та/або табуляції (їх трактувати як роздільники
    //чисел у одному рядку матриці), так і символи переведення рядка(їх трактувати
    //як роздільники рядків) — якщо фактичні дані того рядка утворюють прямокутну
    //числову матрицю; зокрема, щоб цим конструктором можна було створити
    //матрицю з рядка, раніше сформованого методом ToString(див.далі))
    public MyMatrix(string input)
    {
        string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); //ділимо на рядки 
        string[] firstLineNumbers = lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //розділяємо рядки на цичсла
        int width = firstLineNumbers.Length; //заміряємо довж. першого рядка для прям. масиву
        int height = lines.Length; //висота за кількістю рядків
        //прям. масив
        data = new double[height, width];

        for (int i = 0; i < height; i++)
        {
            string[] numbers = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); //розділ рядка і на числа

            if (numbers.Length != width)
                throw new ArgumentException("Масив не прямокутний"); //перевіряємо чи він такий як і нульовий

            for (int j = 0; j < width; j++) // поеелеметно переписуємо з рядка у відповідний рядок масиву
                data[i, j] = double.Parse(numbers[j]);
        }
    }
    //ТРЕБА БУДЕ НАПИСАТИ MAIN ДЛЯ ТЕСТУ І ЩОСЬ ЗРОБИТИ З ПОВТОРЕННЯМ В ОСТАННІХ ДВОХ КОНСТРУКТОРАХ
    //----------------------------

    //Властивості (Properties) Height та Width, що дозволяють взнати (але не дозволяють
    //змінити) «висоту» (кількість рядків) та «ширину» (кількість стовпчиків)
    public int Height => data.GetLength(0);
    public int Width => data.GetLength(1);
    //Java-style getter-и (без setter-ів) кількості рядків getHeight() та кількості
    //стовпчиків getWidth()
    public int getHeight() => Height;
    public int getWidth() => Width;
    //Індексатори, що дозволяють публічно доступатися до будь-якого окремого елемента
    //матриці(як взнавати його значення, так і змінювати)
    //public double this[]
    //{

    //}
    //Java-style getter та setter для окремого елемента (getter має два параметри — номер
    //рядка і номер стовпчика, setter має три параметра — номер рядка, номер стовпчика, і
    //значення, яке записати у той рядок і стовпчик)
    public double GetElement;
    public double SetElement;
    //override public String ToString(), який формуватиме (табуляціями та
    //переведеннями рядка) зручне для сприйняття людиною прямокутне подання числової
    //матриці; метод повинен мати саме вищенаведений заголовок, бо саме так вдається
    //забезпечити, щоб примірники цього класу можна було виводити просто через
    //Console.WriteLine(A) (де A – примірник цього самого класу MyMatrix)
    public override string ToString()
    {

    }

}
