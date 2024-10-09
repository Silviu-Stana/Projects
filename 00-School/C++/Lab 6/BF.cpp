///Exemplu curs  Figura 3.1.3:  n=5 noduri  m=7  muchii, care sunt: 2 3 2 4 2 5 3 1  */
///Date intrare:  5 7 1 2 2 3 2 4 2 5 3 1 3 2 5 4
///Rezultat parcurgere BF din nodul (3):   3 1 2 4 5

#include <iostream>
using namespace std;
int i, j, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int varf, coada, S[100] = { 0 }, URM[100] = { 0 };

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


void BF(int x)
{
    cout << x << " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;
    TATA[x] = 0;
    coada = 1;
    varf = 1;
    S[coada] = x;

    while (varf <= coada)
    {
        i = S[varf];
        i = URM[i] + 1; //j va fii succesor direct nevizitat al lui i, daca exista

        while (a[i][j] == 0 && j <= n)j++;

        if (j > n) varf++; //daca nodul i nu mai are succesori nevizitati, elimina din stiva
        else {
            URM[i] = j; //j este urm succesor

            if (AFostVizitat2[j] == 0) //j nu a fost vizitat
            {
                cout << j << " ";
                AFostVizitat2[j] = 1;
                TATA[j] = i;
                coada++;
                S[coada] = j;
            }
        }
    }

    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] >= 1 && AFostVizitat2[y] == 0)
        {
            TATA[y] = x;
            BF(y);
        }
    }
}

int main()
{
    cin >> n;//cout<<"Nr noduri: ";
    cin >> m;//cout<<"Nr muchii: ";

    CreareMatriceAdiacenta(n, m);
    AfisareMatrice(a);

    cout << "Parcurgere BF din nodul 3:  ";
    BF(3);
}
