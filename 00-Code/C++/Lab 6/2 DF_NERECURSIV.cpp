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
int i, j, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int varf, S[100] = { 0 }, URM[100] = { 0 };

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

void DF_NERECURSIV(int x)
{
    cout << x << " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;
    TATA[x] = 0;
    varf = 1;
    S[varf] = x;

    while (varf > 0)
    {
        i = S[varf];
        i = URM[i] + 1; //j va fii succesor direct nevizitat al lui i, daca exista

        while (a[i][j] == 0 && j <= n)j++;

        if (j > n) varf--; //daca nodul i nu mai are succesori nevizitati, elimina din stiva
        else {
            URM[i] = j; //j este urm succesor

            if (AFostVizitat2[j] == 0) //j nu a fost vizitat
            {
                cout << j << " ";
                AFostVizitat2[j] = 1;
                TATA[j] = i;
                varf++;
                S[varf] = j;
            }
        }
    }

    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] >= 1 && AFostVizitat2[y] == 0)
        {
            TATA[y] = x;
            DF_NERECURSIV(y);
        }
    }
}

int main()
{
    cin >> n;//cout<<"Nr noduri: ";
    cin >> m;//cout<<"Nr muchii: ";

    CreareMatriceAdiacenta(n, m);
    //AfisareMatrice(a); // nu mai afisam matricea de adiacenta

    DF_NERECURSIV(2);
}
