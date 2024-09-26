#include <iostream>
#include <fstream>
using namespace std;

int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CC[100];
int d[100][100];

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");


void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        MyFile >> x >> y;
        a[x][y] = 1;
        a[y][x] = 1;
    }
}

void DF(int x)
{
    //cout<<x<< " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;
    CC[x] = nrc;

    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] && AFostVizitat2[y] == 0) //Conditia specifica grafului neorientat. Nu mai verificam a[y][x]>=1 (deoarece ordinea arcelor nu conteaza)
        {
            TATA[y] = x;
            DF(y);
        }
    }
}

void COMPONENTE_CONEXE()
{
    for (int i = 1; i <= n; i++)CC[i] = 0;

    for (int i = 1; i <= n; i++)
    {
        if (CC[i] == 0)
        {
            nrc++;
            DF(i);
        }
    }

    cout << "Numarul de componente conexe: " << nrc << endl;
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
    ///Exemplu din curs: Figura 4.1.2 date de intrare:
    Write << "7 6 1 2 2 3 2 4 2 5 3 6 3 7";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    COMPONENTE_CONEXE();


    ///Nr ciclomatic: m-n+nrc;   ciclomatic=1 and conexe=1, ESTE arbore.
    if (m - n + nrc == 0 && nrc == 1)cout << "Este Arbore";
    else "Graful NU este arbore.";
}
