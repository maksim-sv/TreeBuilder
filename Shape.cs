class Shape
{

    public string name { get; }
    public Shape(string a)
    {
        name = a;
    }
    public List<Shape>? list { get; private set; } = null;
    public Shape? this[int i]
    {
        get => list?[i];
    }
    Shape? GetShape(params int[] a)
    {
        Shape? temp = this;
        for (int i = 0; i < a.Length; i++)
        {
            temp = temp?[a[i]];
        }
        return temp;
    }
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
    int[] ToOneDem(int[,] c, int i)
    {
        int rows = c.GetUpperBound(0) + 1;
        int columns = c.Length / rows;
        int[] str = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            str[j] = c[i, j];
        }

        return str;
    }
    public void BuildTree(params int[] levels)//3,3,3
    {
        AddBranchLevel(this, levels[0]);
        for (int j = 0; j < levels.Length-1; j++)
        {
            int[] max = new int[j + 1];
            Array.Copy(levels, max, j + 1);
            int depth = max.Length;
            int[,] c = Numerator.PlusOneMode(depth, max);
            Console.Write(print(c));
            for (int i = 0; i < c.GetUpperBound(0) + 1; i++)
                AddBranchLevel(GetShape(ToOneDem(c, i)), levels[j+1]);

        }
        /*  AddBranchLevel(this, levels[0]);
          AddBranchLevel(this[0], levels[1]);
          AddBranchLevel(this[1], levels[1]);
          AddBranchLevel(this[2], levels[1]);
          AddBranchLevel(this[0][0], levels[2]);
          AddBranchLevel(this[0][1], levels[2]);
          AddBranchLevel(this[0][2], levels[2]);
          AddBranchLevel(this[1][0], levels[2]);
          AddBranchLevel(this[1][1], levels[2]);
          AddBranchLevel(this[1][2], levels[2]);
          AddBranchLevel(this[2][0], levels[2]);
          AddBranchLevel(this[2][1], levels[2]);
          AddBranchLevel(this[2][2], levels[2]);*/

    }
    public void GlobalPrint(List<Shape> a)
    {
        foreach (var item in a)
        {
            Console.WriteLine(item.name);
            if(item.list is not null) GlobalPrint(item.list);

        }
    }

    void AddBranchLevel(Shape a, int i)
    {
        a.list ??= new List<Shape>();
        for (int integer = 0; integer < i; integer++)
        {
            a.list.Add(new Shape(a.name + integer));
        }
    }
    public override string ToString()
    {
        return name;
    }
}
