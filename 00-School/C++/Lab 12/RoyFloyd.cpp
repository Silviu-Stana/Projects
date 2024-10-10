//L12 Roy Floyd
#include <iostream>
#include <fstream>
#include <limits>
#include <iomanip>
using namespace std;
int i, j, m, n, c[100][100] = { 0 }, c2[100][100] = { 0 };
int x, y, distanta, S[100] = { 0 };
double TATA[100], t[100];
double INFINITE = 999;//std::numeric_limits<double>::infinity();
double minn;

int sumaGradeIntrare = 0, sumaGradeIesire = 0;

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        MyFile >> x >> y >> distanta;
        c[x][y] = distanta;
    }

    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++) if (i != j && c[i][j] == 0) c[i][j] = INFINITE;
    }
}

void AfisareMatrice(int a[100][100])
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
            if (a[i][j] == INFINITE) cout << setw(3) << "oo" << " ";
            else cout << setw(3) << a[i][j] << " ";
        cout << endl;
    }
}

void DIJKSTRA(int s)
{
    for (int i = 1; i <= n; i++)
    {
        S[i] = 0;  t[i] = INFINITE;  TATA[i] = INFINITE;
    }

    t[s] = 0; TATA[s] = 0;

    do
    {
        minn = INFINITE;
        for (int i = 1; i <= n; i++)
        {
            if (S[i] == 0 && t[i] < minn)
            {
                minn = t[i];
                x = i;
            }
        }

        if (minn < INFINITE)
        {
            S[x] = 1;
            for (int i = 1; i <= n; i++)
            {
                if (S[i] == 0 && c[x][i] < INFINITE)
                    if (t[i] > t[x] + c[x][i])
                    {
                        t[i] = t[x] + c[x][i];
                        TATA[i] = x;
                    }
            }
        }

    } while (minn < INFINITE);

    cout << "TATAL[] nodului:" << endl;
    for (int i = 1; i <= n; i++) cout << i << ": " << TATA[i] << endl;

    cout << "Distanta Minima t[i]" << endl;
    for (int i = 1; i <= n; i++) cout << i << ": " << t[i] << endl;
}

void ROYFLOYD()
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            c2[i][j] = c[i][j];
        }
    }

    for (int k = 1; k <= n; k++)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (c2[i][k] + c2[k][j] < c2[i][j])  c2[i][j] = c2[i][k] + c2[k][j];
            }
        }
    }
}

int main()
{
    ///Figura 12.1.1
    Write << "5 9 1 3 10 1 4 5 1 2 15 3 2 5 3 5 5 4 5 5 4 2 10 5 1 5 5 2 5";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii


    CreareMatriceAdiacenta(n, m);
    cout << "Matricea Adiacenta:" << endl;//c[i][j]
    AfisareMatrice(c);

    ROYFLOYD();

    cout << endl << "Matricea Drumuri Minime: (ROY_FLOYD)" << endl;//c[i][j]
    AfisareMatrice(c2);
}
