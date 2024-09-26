//  Exemplu din curs 3.4.3:
//n=5  m=4  muchii: 2 3 2 4 2 5 3 1
///Date intrare:  5 4 2 3 2 4 2 5 3 1

#include <iostream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CC[100];

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

    cout << "Numarul de componente conexe: " << nrc;
}

int main()
{
    cin >> n;//noduri
    cin >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    COMPONENTE_CONEXE();
}
