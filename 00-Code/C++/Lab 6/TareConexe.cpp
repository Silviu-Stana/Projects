///Exemplu curs  Figura 3.1.3:  n=5 noduri  m=7  muchii, care sunt: 2 3 2 4 2 5 3 1  */
///Pentru Date de intrare:  5 7 1 2 2 3 2 4 2 5 3 1 3 2 5 4
///Rezultat:
/*
Componenta 1: 1 2 3
Componenta 2: 4
Componenta 3: 5
*/
///Daca am adauga si o muchie de la 5 la 2:  5 8 1 2 2 3 2 4 2 5 3 1 3 2 5 4 5 2
///Rezultat:
/*
Componenta 1: 1 2 3
Componenta 2: 4
Componenta 3: 5
*/


#include <iostream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100], TATA2[100], AFostVizitat2[100] = { 0 }, VIZ2[100] = { 0 };
int nrc = 0, CTC[100], adaugatLaLista[100] = { 0 };

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
    cout << x << " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;

    for (int y = 1; y <= n; y++)
    {
        if ((a[x][y] > 0) && AFostVizitat2[y] == 0)
        {
            TATA[y] = x;
            DF(y);
        }
    }
}

void DF_TRANSPUS(int x)
{
    cout << x << " ";//afisare nod vizitat
    VIZ2[x] = 1;

    for (int y = 1; y <= n; y++)
    {
        if ((a[y][x] > 0) && VIZ2[y] == 0)
        {
            TATA2[y] = x;
            DF_TRANSPUS(y);
        }
    }
}

void COMPONENTE_TARE_CONEXE()
{
    for (int i = 1; i <= n; i++) CTC[i] = 0;

    for (int i = 1; i <= n; i++)
    {
        nrc++;
        DF(i);
        DF_TRANSPUS(i);


        // Daca nodul este vizitat din ambele matrici, pentru prima oara, adauga-l la curenta componenta conexa:
        for (int j = i; j <= n; j++)
        {
            if (AFostVizitat2[j] == 1 && VIZ2[j] == 1 && adaugatLaLista[j] == 0)
            {
                CTC[j] = nrc;
                adaugatLaLista[j] = 1;

            }
        }

        //Dupa ce am adaugat la Lista toate nodurile din componenta curenta TARE CONEXA, sarim direct pasul "i" la primul nod care nu apartine listei
        for (int j = i; j <= n; j++) if (adaugatLaLista[j] == 0) { i = j - 1; break; }

        //Si resetam tot.
        for (int j = 1; j <= n; j++)
        {
            AFostVizitat2[j] = 0;
            VIZ2[j] = 0;
        }
    }
}

void AfisareListeConexe()
{
    cout << "Numarul de componente TARE conexe: " << nrc << endl;

    for (int j = 1; j <= nrc; j++)
    {
        cout << "Elementele componentei Tare-Conexe nr " << j << " sunt: ";
        for (i = 1; i <= n; i++)
        {
            if (CTC[i] == j)cout << i << " ";
        }
        cout << endl;
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

int main()
{
    cin >> n;//noduri
    cin >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    //AfisareMatrice(a);

    COMPONENTE_TARE_CONEXE();
    //  DF(4); cout<<endl;
  //DF_TRANSPUS(4);
    AfisareListeConexe();
}
