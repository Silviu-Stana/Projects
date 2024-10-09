#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int i, j, k, m, n, a[100][100] = { 0 }, Admitanta[100][100] = { 0 }; double Determinant[100][100] = { 0 };
int x, y;

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");


void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        MyFile >> x >> y;
        a[x][y]++; //chiar si daca avem graf orientat
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
                Admitanta[j][j] += a[i][j];
                Admitanta[i][j] = -a[i][j];
            }
        }
    }
}

void EliminareLinieColoana(int liniaEliminata)
{
    //In primul rand Copiem matricea Admitanta in Determinant.
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++) Determinant[i][j] = Admitanta[i][j];
    }

    //Apoi, eliminam Linia
    for (i = 1; i <= n; i++)
    {
        for (j = liniaEliminata; j <= n - 1; j++)Determinant[i][j] = Determinant[i][j + 1];
        Determinant[i][n] = 0;
    }

    //Apoi eliminam si coloana
    for (j = 1; j <= n; j++)
    {
        for (i = liniaEliminata; i <= n - 1; i++)Determinant[i][j] = Determinant[i + 1][j];
        Determinant[n][j] = 0;
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

void AfisareMatriceDouble(double d[100][100], int n)
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)cout << setw(2) << d[i][j] << " ";
        cout << endl;
    }
}

double CalculDeterminant(double A[100][100], int n)
{
    double d = 1, aux; // d=det(A)
    for (i = 1;i <= n - 1;i++) // A[i][i]=pivot
    {
        if (A[i][i] == 0) // cautam k>i: A[k][i]<>0
        {
            k = i + 1;
            while ((A[k][i] == 0) && (k <= n)) k++;
            if (k <= n) // exista k, interschimbam liniile i si k
            {
                d = -d;
                for (j = i;j <= n;j++)
                {
                    aux = A[i][j]; A[i][j] = A[k][j]; A[k][j] = aux;
                }
            }
            else // nu exista k, det=0
            {
                d = 0; return d;
            }
        }
        if (d != 0) // A[i][i]<>0, transformam in 0 elementele de sub
            // pivotul A[i][i]
        {
            for (k = i + 1;k <= n;k++) // din linia k scadem
                // (A[k][i]/A[i][i])X(linia i)
            {
                double x = A[k][i] / A[i][i];
                for (j = i;j <= n;j++) A[k][j] = A[k][j] - x * A[i][j];
            }
            d = d * A[i][i]; // inmultim elementul diagonal A[i][i] la det(A)
        }
    }
    d = d * A[n][n]; // inmultim si elementul diagonal A[n][n] la det(A)
    return d;
}

int main()
{
    ///Exemplu din curs: Figura 4.4.1 din curs, date de intrare:
    Write << "8 11 1 2 2 3 2 5 3 3 3 6 4 5 4 4 4 1 4 2 5 6 6 3";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);
    CreareMatriceAdmitanta(n);
    EliminareLinieColoana(1);

    cout << endl;
    cout << "Figura 2 din curs: " << endl << endl;
    cout << "Matricea Adiacenta: " << endl;
    AfisareMatrice(a, n);

    cout << "Matricea Admitanta: " << endl;
    AfisareMatrice(Admitanta, n);

    //   cout << "Matricea Pentru Calcul Determinant: (cu linia si coloana 2 eliminate)" << endl;
     //  AfisareMatriceDouble(Determinant, n - 1);

    int nrArboriPartiali = 0;
    //Eliminam linia si coloana 2. Pentru ca suma este para, inmultim cu 1.
    int liniaEliminata = 2, coloanaEliminata = 2;

    if ((liniaEliminata + coloanaEliminata) % 2 == 0) nrArboriPartiali = 1 * CalculDeterminant(Determinant, n - 1);
    else nrArboriPartiali = -1 * CalculDeterminant(Determinant, n - 1);

    cout << "Nr de Arbori Partiali este: " << nrArboriPartiali;
}
