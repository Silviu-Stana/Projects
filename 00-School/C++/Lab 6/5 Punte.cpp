#include <iostream>
#include <fstream>
using namespace std;
int i, m, n, a[100][100] = { 0 }, b[100][100];
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CC[100];

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        MyFile >> x >> y;
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
        if ((b[x][y] >= 1 || b[y][x] >= 1) && AFostVizitat2[y] == 0)
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

void DETERMINAREA_PUNTILOR(int k, int k2)
{
    ///Copiem matricea (de fiecare data cand testam eliminarea unui nou nod)
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++) b[i][j] = a[i][j];

    //Resetam tot.
    for (int i = 1; i <= n; i++)
    {
        AFostVizitat2[i] = 0;
        nrc = 0;
        CC[i] = 0;
    }

    ///Eliminam muchia.
    b[k][k2] = 0;

    COMPONENTE_CONEXE();

    ///Asumam ca graful avea la inceput 1 componenta conexa.
    ///Pur si simplu testam daca avem acum 2+ componente conexe. Daca da, atunci este o "Muchie Punte"

    if (nrc > 1) cout << k << "--" << k2 << endl;
}

int main()
{
    ///Am introdus Graful din Figura 3.1.3 din curs, dar fara muchia 5->4, ca sa descoperim cele 2 punti: 2--4 si 2--5.
    ///Daca pastram acea muchie, atunci nu mai avem nici o Punte!
    ///Acelea cand sunt eliminate, avem mai mult de 1 componenta conexa!
    //Datele initiale din Figura 3.1.3:  5 7 1 2 2 3 2 4 2 5 3 1 3 2 5 4
    Write << "5 6 1 2 2 3 2 4 2 5 3 1 3 2";
    Write.close();

    MyFile >> n;//noduri
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    cout << "Muchiile Punte sunt intre nodurile: " << endl;
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++) DETERMINAREA_PUNTILOR(i, j);
}
