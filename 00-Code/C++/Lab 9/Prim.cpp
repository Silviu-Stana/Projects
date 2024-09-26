#include <iostream>
#include <fstream>
#include <iomanip>
#include <limits>

using namespace std;
int i, m, n, c[100][100] = { 0 };
int x, y, t[200], TATA[100], CC[100] = { 0 }, S[200];

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

void CreareMatriceCosturi()
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (i == j) c[i][j] = 0;
            else c[i][j] = numeric_limits<int>::max();
        }
    }

    int cost;
    for (int i = 1; i <= m; i++)
    {
        //"x" si "y" ia capetele fiecarei muchii, din fisier. "c" ia costul.
        MyFile >> x;
        MyFile >> y;
        MyFile >> cost;
        c[x][y] = cost;
        c[y][x] = cost;
    }
}

void AfisareMatrice(int a[100][100])
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (a[i][j] > 29999) cout << setw(4) << "oo" << " ";
            else cout << setw(4) << a[i][j] << " ";
        }
        cout << endl;
    }
}

void PRIM()
{
    S[1] = 1;
    int cost = 0;

    for (int i = 2; i <= n; i++)
    {
        S[i] = 0;
        t[i] = c[i][1];
        TATA[i] = 1;
    }

    for (int l = 1; l <= n - 1; l++)
    {
        int min = numeric_limits<int>::max();

        for (int i = 2; i <= n; i++)
        {
            if (S[i] == 0 && t[i] < min)
            {
                min = t[i]; y = i;
            }
        }

        S[y] = 1;
        x = TATA[y];
        cost = cost + c[x][y];
        cout << "Muchia Selectata: " << "[" << x << "," << y << "]" << endl;
        cout << "Cost Total: " << cost << endl;
        for (int i = 2; i <= n; i++)
        {
            if (S[i] == 0 && t[i] > c[i][y])
            {
                t[i] = c[i][y]; TATA[i] = y;
            }
        }
    }


    cout << "- - - - - - - - - - " << endl;
    cout << "Cost minim total: " << cost;
}

int main()
{
    ///Figura 5.2.1, date de intrare pentru matricea P[][]:
    Write << "10 17 1 2 30 1 5 70 1 7 110 2 3 50 2 5 60 3 4 100 3 6 20 4 6 90 4 9 150 4 10 120 5 6 70 5 9 40 5 8 10 6 9 80 7 8 100 8 9 30 9 10 130";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceCosturi();

    AfisareMatrice(c);

    PRIM();

}