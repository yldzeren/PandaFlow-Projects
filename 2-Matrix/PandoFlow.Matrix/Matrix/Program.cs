string inputMatrixStr;

while (true)
{
    Console.WriteLine("Enter the matrix as a string:");
    inputMatrixStr = Console.ReadLine();
    if (ValidateMatix(inputMatrixStr))
        break;
}

int[][] matrix = ParseMatrix(inputMatrixStr);

int areasCount = CountAreasOfOnes(matrix);

Console.WriteLine("Number of areas formed of number 1: " + areasCount);

static bool ValidateMatix(string matrixStr)
{
    string[] rows = matrixStr.Split(';');

    if (matrixStr.ToCharArray().Any(x => x != '0' && x != '1' && x != ',' && x != ';'))
        Console.WriteLine("string must only consist of 1,0, comma and semicolon.");
    else if (!matrixStr.Any(x => x == ';'))
        Console.WriteLine("string must be contain ;");
    else if (matrixStr.Count(x => x == ';') != 1)
        Console.WriteLine("Count of semicolon must be 1");
    else if (rows[0].Count() != rows[1].Count())
        Console.WriteLine("String rows count must be same");
    else if (rows[0].Split(',').Length != rows[0].Split(',').Length)
        Console.WriteLine("String rows count must be same");
    else
        return true;
    return false;
}

static int[][] ParseMatrix(string matrixStr)
{
    string[] rows = matrixStr.Split(';');
    int[][] matrix = new int[rows.Length][];

    for (int i = 0; i < rows.Length; i++)
    {
        string[] cols = rows[i].Split(',');
        matrix[i] = new int[cols.Length];

        for (int j = 0; j < cols.Length; j++)
        {
            matrix[i][j] = int.Parse(cols[j]);
        }
    }

    return matrix;
}

static int CountAreasOfOnes(int[][] matrix)
{
    int areas = 0;
    int rows = matrix.Length;
    int cols = matrix[0].Length;
    bool[][] visited = new bool[rows][];

    for (int i = 0; i < rows; i++)
    {
        visited[i] = new bool[cols];
    }

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (matrix[i][j] == 1 && !visited[i][j])
            {
                areas++;
                MarkAreaAsVisited(matrix, visited, i, j);
            }
        }
    }

    return areas;
}

static void MarkAreaAsVisited(int[][] matrix, bool[][] visited, int row, int col)
{
    if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[0].Length || matrix[row][col] != 1 || visited[row][col])
    {
        return;
    }

    visited[row][col] = true;

    // Check the neighbors (up, down, left, right)
    MarkAreaAsVisited(matrix, visited, row - 1, col);
    MarkAreaAsVisited(matrix, visited, row + 1, col);
    MarkAreaAsVisited(matrix, visited, row, col - 1);
    MarkAreaAsVisited(matrix, visited, row, col + 1);
}