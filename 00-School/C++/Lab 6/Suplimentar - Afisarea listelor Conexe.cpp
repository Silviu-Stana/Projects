/*  Exemplu din curs 3.4.3: (matricea de adiacenta)
0 0 0 0 0 0
0 0 1 1 1 0
1 0 0 0 0 0
0 0 0 0 0 0
0 0 0 0 0 0
0 0 0 0 0 0
//n=6  m=4  muchii: 2 3 2 4 2 5 3 1  */
///Pentru introducerea datelor de la tastatura: 6 4 2 3 2 4 2 5 3 1 (Nodul 6 nu e conectat de nimic, deci 2 componente conexe) Va afisa:
///Numarul de componente conexe: 2
///Elementele componentei Conexe nr 2 sunt: 1 2 3 4 5
///Elementele componentei Conexe nr 2 sunt: 6

#include <iostream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CC[100], ListeConexe[100] = { 0 };

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        cin >> x >> y;
        a[x][y]++;
        //a[y][x]++;
    }
}

void AfisareMatrice(int a[100][100])
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++) cout << a[i][j] << " ";
        cout << endl;
    }
}

void DF(int x)
{
    //cout<<x<< " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;
    CC[x] = nrc;

    for (int y = 1; y <= n; y++)
    {
        if ((a[x][y] >= 1 || a[y][x] >= 1) && AFostVizitat2[y] == 0)
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
}

void AfisareListeConexe()
{
    cout << "Numarul de componente conexe: " << nrc << endl;

    for (int j = 1; j <= nrc; j++)
    {
        cout << "Elementele componentei Conexe nr " << nrc << " sunt: ";
        for (i = 1; i <= n; i++)
        {
            if (CC[i] == j)cout << i << " ";
        }
        cout << endl;
    }

    if (nrc == 1)cout << "Graful este conex";
    else cout << "Graful NU este conex!";

}

int main()
{
    cin >> n;//noduri
    cin >> m;//muchii

    CreareMatriceAdiacenta(n, m);
    COMPONENTE_CONEXE();

    AfisareListeConexe();
}
