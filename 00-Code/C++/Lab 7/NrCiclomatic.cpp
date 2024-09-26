//n=6 noduri,  m=9  muchii: 1 2 2 2 1 4 2 5 4 5 4 5 5 4 3 6 6 3
///Exemplu din curs: Figura 3.1.2 date de intrare:  6 9 1 2 2 2 1 4 2 5 4 5 4 5 5 4 3 6 6 3

#include <iostream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CC[100];
int d[100][100];

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        cin >> x >> y;
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

int main()
{
    cin >> n;//cout<<"Nr noduri: ";
    cin >> m;//cout<<"Nr muchii: ";

    CreareMatriceAdiacenta(n, m);

    ROY_WARSHALL();
    COMPONENTE_CONEXE();

    cout << "Numarul ciclomatic este: " << m - n + nrc;
}
