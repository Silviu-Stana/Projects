#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int i, j, k, m, n, a[100][100] = { 0 }, Admitanta[100][100] = { 0 }, Intrare[100][100] = { 0 }; double Determinant[100][100] = { 0 };
int x, y;

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");


void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        MyFile >> x >> y;
        a[x][y]++; //orientat
    }
}

void CreareMatriceAdmitanta(int n)
{
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++)
        {
            if ((a[i][j] > 0 || a[j][i] > 0) && i != j)
            {
                Admitanta[i][i] += a[i][j];
                Admitanta[i][j] = Admitanta[i][j] - a[i][j]; //scadem toate muchiile din ambele directii (pentru graf orientat)
            }
        }
    }
}

void CreareMatriceDeIntrare(int n)
{
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++)
        {
            if (a[j][i] > 0)
            {
                Intrare[i][i] += 1;
                Intrare[j][i] = -1;
            }
        }
    }
}

void AfisareMatrice(int d[100][100], int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)cout << setw(2) << d[i][j] << " ";
        cout << endl;
    }
}

int main()
{
    ///Exemplu din curs: Figura 3.1.3 din curs, date de intrare:
    Write << "5 7 3 1 3 2 2 3 1 2 2 4 5 4 2 5";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);
    CreareMatriceAdmitanta(n);
    CreareMatriceDeIntrare(n);

    cout << endl;
    cout << "Exemplul 3.1.3 din curs: " << endl << endl;
    cout << "Matricea Adiacenta: " << endl;
    AfisareMatrice(a, n);

    cout << "Matricea Admitanta: " << endl;
    AfisareMatrice(Admitanta, n);

    cout << "Matricea De Intrare: " << endl;
    AfisareMatrice(Intrare, n);
}
