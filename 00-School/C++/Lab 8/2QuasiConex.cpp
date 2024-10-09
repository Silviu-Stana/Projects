#include <iostream>
#include <fstream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CTC[100];
int d[100][100];
int VerificareDrum[100];

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");


void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        MyFile >> x >> y;
        a[x][y]++; //graf orientat
    }
}

void DF(int x)
{
    AFostVizitat2[x] = 1;
    CTC[x] = nrc;

    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] && AFostVizitat2[y] == 0) //Conditia specifica grafului neorientat. Nu mai verificam a[y][x]>=1 (deoarece ordinea arcelor nu conteaza)
        {
            TATA[y] = x;
            DF(y);
        }
    }
}

void ROY_WARSHALL()
{
    for (int i = 1;i <= n;i++)
        for (int j = 1;j <= n;j++)
            if (a[i][j] > 0)d[i][j] = 1;
            else d[i][j] = 0;

    for (int k = 1;k <= n;k++)
        for (int i = 1;i <= n;i++)
            for (int j = 1;j <= n;j++)
                d[i][j] = d[i][j] | d[i][k] & d[k][j];
}

void AfisareMatrice(int d[100][100])
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)cout << d[i][j] << " ";
        cout << endl;
    }
}

int main()
{
    ///Exemplu din curs: Figura 4.3.1 din curs, date de intrare:
    Write << "5 4 3 1 3 2 2 5 5 4";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    ROY_WARSHALL();
    AfisareMatrice(a);


    for (int i = 1; i <= n; i++)VerificareDrum[i] = 1;///Asumam la inceput ca exista drum din acel nod, catre toate.
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)if (i != j)if (d[i][j] == 0)VerificareDrum[i] = 0;


    for (int i = 1; i <= n; i++)
        if (VerificareDrum[i] == 1)cout << "Nodul " << i << " este radacina." << endl;
        else cout << "Nodul " << i << " NU este radacina" << endl;

    cout << endl;
    cout << "Graful este QUASI-conex." << endl;
    cout << "Urmatoarele noduri au drum catre orice alt nod: ";
    for (int i = 1; i <= n; i++)if (VerificareDrum[i] == 1)cout << i << " " << endl;

}
