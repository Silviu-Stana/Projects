//  Curs Figura 3.1.3:   n=5  m=7  muchii: 1 2 2 3 2 4 2 5 3 1 3 2 5 4
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

void DETERMINAREA_ARTICULATILOR(int nodEliminat)
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

    ///Eliminam toate muchiile Nodului care vrem sa il testam daca este Articulatie!
    for (int j = 1; j <= n; j++)
    {
        b[nodEliminat][j] = 0;
        b[j][nodEliminat] = 0;
    }

    COMPONENTE_CONEXE();

    ///Prin eliminarea tuturor muchiilor, daca este "Nod articulatie" vem avea 3+ componente conexe:
    ///Componenta 1: "nodul articulatie", si
    ///Componenta 2, 3,.... , celelalte parti care au fost separate de "Nodul Articulatie"!

    if (nrc > 2) cout << nodEliminat << "  ";
}

int main()
{
    Write << "5 7 1 2 2 3 2 4 2 5 3 1 3 2 5 4";
    Write.close();

    MyFile >> n;//noduri
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    cout << "Nodurile Punte sunt: " << endl;
    for (int i = 1; i <= n; i++) DETERMINAREA_ARTICULATILOR(i);
}
