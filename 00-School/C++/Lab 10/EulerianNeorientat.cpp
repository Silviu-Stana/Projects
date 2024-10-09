//Verifica Graf Eulerian si Cauta Ciclu
#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, TATA[100] = { 0 }, VIZ[100] = { 0 }, GRADE[100] = { 0 };
int nrc, CC[100] = { 0 };

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        MyFile >> x >> y;
        a[x][y]++;
        a[y][x]++;
    }
}

void AfisareMatrice(int a[100][100])
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++) cout << a[i][j] << " ";
        cout << endl;
    }
    cout << endl;
}

void DF(int x)
{
    cout << x << " ";//afisare nod vizitat
    VIZ[x] = 1;
    CC[x] = nrc;

    for (int y = 1; y <= n; y++)
    {
        if ((a[x][y] >= 1 || a[y][x] >= 1) && VIZ[y] == 0)
        {
            TATA[y] = x;
            DF(y);
        }
    }
}

void ModificareDF()
{
    for (int i = 1; i <= n; i++)
        if (TATA[i] != 0)
        {
            cout << i << " Dad is: " << TATA[i] << endl;
            a[TATA[i]][i] = 2;
            a[i][TATA[i]] = 2;
        }
}

void COMPONENTE_CONEXE()
{
    nrc = 0;

    for (int i = 1; i <= n; i++)
    {
        if (CC[i] == 0)
        {
            nrc++;
            DF(i);
        }
    }

    //cout<<"Numarul de componente conexe: " << nrc;
}

int VERIFICA_GRADE()
{
    int estePar = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            ///Creste gradul si pe linie si pe coloana.
            if (a[i][j] > 0)GRADE[i]++;
            if (a[j][i] > 0)GRADE[i]++;
        }
    }

    for (int i = 1; i <= n; i++)
    {
        //cout<<"Grad"<<i<<": "<<GRADE[i] << endl;

        if (GRADE[i] % 2 == 1)
        {
            estePar = 0; break;
        }
    }

    return estePar;
}

void CICLU_EULERIAN(int x)
{
    int i, j;
    i = x;

    cout << "Avem Ciclul Eulerian: ";
    do
    {
        cout << i << "->";
        j = 1;
        while (a[i][j] != 1 && j <= n)j++;
        if (j <= n)
        {
            a[i][j] = 0;
            a[j][i] = 0;
            i = j;
        }
        else {
            j = 1;
            while (a[i][j] != 2 && j <= n)j++;
            if (j <= n)
            {
                a[i][j] = 0;
                a[j][i] = 0;
                i = j;
            }
        }
    } while (j <= n);

    //Stergem ultimele 2 caractere din consola "->"
    cout << "\b \b";
    cout << "\b \b";

    cout << endl;
}

int main()
{
    ///Figura 6.1.1
    Write << "10 13 1 2 1 5 2 3 2 5 2 6 3 6 3 4 3 9 4 10 5 8 5 7 7 8 9 10";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    AfisareMatrice(a);

    cout << "DF:";
    COMPONENTE_CONEXE();
    DF(1); cout << endl;
    ModificareDF();

    if (nrc == 1 && VERIFICA_GRADE()) cout << endl << "Graful este Eulerian" << endl;
    else cout << "Graful NU este eulerian";

    CICLU_EULERIAN(1);
}