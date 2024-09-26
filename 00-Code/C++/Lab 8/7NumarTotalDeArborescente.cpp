#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int i, j, k, m, n, a[100][100] = { 0 }, Intrare[100][100] = { 0 }; double MatricePartiala[100][100] = { 0 };
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

void EliminareLinieColoana(int liniaEliminata)
{
    //In primul rand Copiem matricea Admitanta in Determinant.
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++) MatricePartiala[i][j] = Intrare[i][j];
    }

    //Apoi, eliminam Linia
    for (i = 1; i <= n; i++)
    {
        for (j = liniaEliminata; j <= n - 1; j++)MatricePartiala[i][j] = MatricePartiala[i][j + 1];
        MatricePartiala[i][n] = 0;
    }

    //Apoi eliminam si coloana
    for (j = 1; j <= n; j++)
    {
        for (i = liniaEliminata; i <= n - 1; i++)MatricePartiala[i][j] = MatricePartiala[i + 1][j];
        MatricePartiala[n][j] = 0;
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
    ///Exemplu din curs: Figura 3.1.3 din curs, date de intrare:
    Write << "5 7 3 1 3 2 2 3 1 2 2 4 5 4 2 5";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);
    CreareMatriceDeIntrare(n);

    cout << endl;
    cout << "Exemplul 3.1.3 din curs: " << endl << endl;
    cout << "Matricea Adiacenta: " << endl;
    AfisareMatrice(a, n);

    cout << "Matricea De Intrare: " << endl;
    AfisareMatrice(Intrare, n);

    int NumarTotalArborescente = 0;
    ///Calculam Numarul de Arborescente:
    //-calculand determinantul matricilor partiale
    //-cu fiecare linie/coloana eliminate:
    for (int i = 1; i <= n; i++)
    {
        EliminareLinieColoana(i);
        int nr = CalculDeterminant(MatricePartiala, n - 1);

        NumarTotalArborescente += nr;
        cout << "Eliminand linia " << i << " si coloana " << i << " am gasit  " << nr << "  arborescente partiale." << endl;
    }

    cout << "Numarul Total de Arborescente Partiale este de: " << NumarTotalArborescente << endl;

}
