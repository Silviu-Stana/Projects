//n=5 noduri, m=7  muchii: 1 2 3 1 3 2 2 3 2 5 5 4 2 4
///Exemplu din curs: Figura 3.1.3:  5 7 1 2 3 1 3 2 2 3 2 5 5 4 2 4
///Rezultat: 3 Componente Tare-Conexe

#include <iostream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CTC[100];
int d[100][100];

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        cin >> x >> y;
        a[x][y]++; //graf orientat
        //a[y][x]++;
    }
}

void DF(int x)
{
    //cout<<x<< " ";//afisare nod vizitat
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

void COMPONENTE_TARE_CONEXE()
{
    nrc = 0;

    for (int i = 1; i <= n; i++)CTC[i] = 0; //CTC[i] = num˘arul componentei tare-conexe ^ın care se afl˘a nodul i

    for (int i = 1; i <= n; i++)
    {
        if (CTC[i] == 0)
        {
            nrc++;
            ROY_WARSHALL();
            for (int j = i + 1; j <= n; j++)
                if (CTC[j] == 0 && d[i][j] == 1 && d[j][i] == 1)CTC[j] = nrc;
        }
    }

    cout << "Numarul de componente tare conexe: " << nrc;
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
    cin >> n;//cout<<"Nr noduri: ";
    cin >> m;//cout<<"Nr muchii: ";

    CreareMatriceAdiacenta(n, m);

    ROY_WARSHALL();
    AfisareMatrice(d);
    COMPONENTE_TARE_CONEXE();
}
