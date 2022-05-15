using static System.Console;
/*foreach (var item in GetPart(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, 3))
{
    WriteLine(item);
}*//*
Console.Write("depth=");
int depth = int.Parse(Console.ReadLine());
Console.Write("max=");
int max = int.Parse(Console.ReadLine());*/
/*int[]max={10};
int depth = 1;
int[,] c = Numerator.PlusOneMode(depth, max);
WriteLine(print(c));
int[]max2={10,5};
int depth2 = 2;
int[,] c2 = Numerator.PlusOneMode(depth2, max2);
WriteLine(print(c2));*/

Shape root = new Shape("name");
root.BuildTree(14, 8, 2,3);
root.GlobalPrint(new List<Shape> {root});

void tree(params int[] levels)
{
    for (int j = 0; j < levels.Length; j++)
    {
        int[] max=new int [j+1]; 
        Array.Copy(levels,max,j+1);
        int depth = max.Length;
        int[,] c = Numerator.PlusOneMode(depth, max);
        WriteLine(print(c));
    }
}
/*var a = new Shape("name");
a.BuildTree(3, 3, 3);
WriteLine(a[0][1][2].name);*/
string print(int[,] c)
{
    System.Text.StringBuilder str = new("");
    int rows = c.GetUpperBound(0) + 1;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < c.Length / rows; j++)
        {
            str.Append(c[i, j] + " ");
        }
        str.Append("\n");
    }
    return str.ToString();
}
class Numerator
{
    public int max { get; }
    public int depth { get; }
    int arrSizeRow;
    public int[,] result { get; }

    public Numerator(int maxArg, int depthArg)
    {
        max = maxArg;
        depth = depthArg;
        arrSizeRow = (int)Math.Pow((double)maxArg, (double)depthArg);
        result = new int[arrSizeRow, depthArg];
    }

    int[,] PlusOne()//4,2
    {
        int column = 0, sum = 0;

        int[,] result = new int[arrSizeRow, depth];
        for (int i = 0; i < depth; i++)
            result[0, i] = 0;

        for (int row = 1; row < arrSizeRow; row++)
        {
            column = depth - 1;
            do
            {
                sum = result[row - 1, column] + 1;
                if (sum >= max)
                {
                    result[row, column] = 0;
                    column--;
                }
                else
                {
                    result[row, column] = sum;
                    for (int i = 0; i < column; i++)
                        result[row, i] = result[row - 1, i];
                    break;
                }
            }
            while (column > -1);
        }

        return result;
    }
    public static int[,] PlusOne(int depth, int max)//4,2
    {
        int column = 0, sum = 0, arrSizeRow = (int)Math.Pow((double)max, (double)depth);

        int[,] result = new int[arrSizeRow, depth];
        for (int i = 0; i < depth; i++)
            result[0, i] = 0;

        for (int row = 1; row < arrSizeRow; row++)
        {
            column = depth - 1;
            do
            {
                sum = result[row - 1, column] + 1;
                if (sum >= max)
                {
                    result[row, column] = 0;
                    column--;
                }
                else
                {
                    result[row, column] = sum;
                    for (int i = 0; i < column; i++)
                        result[row, i] = result[row - 1, i];
                    break;
                }
            }
            while (column > -1);
        }

        return result;
    }

    public static int[,] PlusOneMode(int depth, params int[] max)//4,2
    {
        int column = 0, sum = 0, arrSizeRow, mult = 1;
        for (int i = 0; i < max.Length; i++)
            mult *= max[i];
        arrSizeRow = mult;

        int[,] result = new int[arrSizeRow, depth];
        for (int i = 0; i < depth; i++)
            result[0, i] = 0;

        for (int row = 1; row < arrSizeRow; row++)
        {
            column = depth - 1;
            do
            {
                sum = result[row - 1, column] + 1;
                if (sum >= max[column])
                {
                    result[row, column] = 0;
                    column--;
                }
                else
                {
                    result[row, column] = sum;
                    for (int i = 0; i < column; i++)
                        result[row, i] = result[row - 1, i];
                    break;
                }
            }
            while (column > -1);
        }

        return result;
    }
    public override string ToString()
    {
        int[,] c = PlusOne();
        System.Text.StringBuilder a = new("");
        for (int i = 0; i < arrSizeRow; i++)
        {
            for (int j = 0; j < depth; j++)
                a.Append(c[i, j] + " ");
            a.Append("\n");
        }
        return a.ToString();
    }
}
