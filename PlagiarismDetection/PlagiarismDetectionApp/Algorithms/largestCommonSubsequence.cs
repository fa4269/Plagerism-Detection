static int Lcs(string test, string solu, int x, int y)
{
    char[] testA = test.ToCharArray();
    char[] soluA = solu.ToCharArray();

    int[,] numA = new int[x + 1, y + 1];

    for (int i = 0; i <= x; i++)
    {
        for (int j = 0; j <= y; j++)
        {
            if (i == 0 || j == 0)
            {
                numA[i, j] = 0;
            }
            else if (testA[i - 1] == soluA[j - 1])
            {
                numA[i, j] = numA[i - 1, j - 1] + 1;
            }
            else
            {
                numA[i, j] = Math.Max(numA[i - 1, j], numA[i, j - 1]);
            }
        }
    }

    return numA[x, y];
}
