/*  Exemplu din curs 3.4.3: (matricea de adiacenta)
0 0 0 0 0
0 0 1 1 1
1 0 0 0 0
0 0 0 0 0
0 0 0 0 0
//n=5  m=4  muchii: 2 3 2 4 2 5 3 1  */
///Date intrare:  5 4 2 3 2 4 2 5 3 1
///Rezultat parcurgere:  2 3 1 4 5

#include <iostream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };

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

void DF_RECURSIV(int x)
{
    cout << x << " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;
    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] >= 1 && AFostVizitat2[y] == 0)
        {
            TATA[y] = x;
            DF_RECURSIV(y);
        }
    }
}

int main()
{
    cin >> n;//cout<<"Nr noduri: ";
    cin >> m;//cout<<"Nr muchii: ";

    CreareMatriceAdiacenta(n, m);
    //AfisareMatrice(a); // nu mai afisam matricea de adiacenta

    DF_RECURSIV(2);
}
