///VerificaDiracOreTrasabilPosa + MatriceaInchiderii:
#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int i, m, n, a[100][100] = { 0 }, b[100][100] = { 0 };
int x, y, TATA[100] = { 0 }, AFostVizitat2[100] = { 0 }, GRADE[100] = { 0 };
int nrc, CC[100] = { 0 };

ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
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

void VERIFICA_DIRAC()
{
    cout << "Verifica Dirac:" << endl;
    //Mai intai resetam toate gradele, ca sa putem recalcula cu o noua Teorema.
    for (int i = 1; i <= n; i++) GRADE[i] = 0;


    int ok = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (a[i][j] > 0)GRADE[i]++;
        }
    }

    for (int i = 1; i <= n; i++)
    {
        cout << "Grad" << i << ": " << GRADE[i] << "  ";
        if (GRADE[i] < n / 2)
        {
            cout << "Este < " << n / 2;
            ok = 0;
        }
        cout << endl;
    }

    if (ok == 0)cout << "Deoarece avem noduri cu grad < n/2, Graful NU verifica Teorema lui Dirac.";
    else cout << "Graful dat verifica Teorema lui Dirac!";
    cout << endl << endl;
}

void VERIFICA_POSA()
{
    cout << "Verifica Posa:" << endl;
    //Mai intai resetam toate gradele, ca sa putem recalcula cu o noua Teorema.
    for (int i = 1; i <= n; i++) GRADE[i] = 0;


    int ok = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (a[i][j] > 0)GRADE[i]++;
        }
    }

    for (int i = 2; i <= n; i++)
    {
        if (GRADE[i] < GRADE[i - 1])
        {
            cout << "Gradul nodului: " << i << "< gradul nodului" << i - 1 << endl;
            ok = 0;
        }
        cout << endl;
    }

    if (ok == 0)cout << "Deoarece gradele nodurilor NU sunt crescatoare, Graful NU verifica Teorema lui Posa.";
    else cout << "Graful dat verifica Teorema lui Posa!";
    cout << endl << endl;
}

void VERIFICA_ORE()
{
    cout << "Verificam Ore:" << endl;
    //Mai intai resetam toate gradele, ca sa putem recalcula cu o noua Teorema.
    for (int i = 1; i <= n; i++) GRADE[i] = 0;


    int ok = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            ///Creste gradul si pe linie si pe coloana.
            if (a[i][j] > 0)GRADE[i]++;
        }
    }

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (i != j) cout << "Grad" << i << "+" << j << ": " << GRADE[i] + GRADE[j] << "  ";
            if (i != j && GRADE[i] + GRADE[j] < n)
            {
                cout << "Este < " << n;
                ok = 0;
            }
            cout << endl;
        }
    }
    if (ok == 0)cout << "Graful Nu verifica Teorema lui Ore. (deoarece oricare 2 noduri, au suma gradelor > n)";
    else cout << "Graful Verifica Teorema lui Ore!";
    cout << endl << endl;

}

void VERIFICA_CHVATAL()
{
    cout << "Verifica Chvatal:" << endl;

    int ok = 1;
    int nod1, nod2;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            //Pentru fiecare pereche de noduri Neadiacente:  Daca suma gradelor lor < n, nu indeplineste conditia.
            if (i != j && a[i][j] == 0 && GRADE[i] + GRADE[j] < n)
            {
                ok = 0;
                nod1 = i;
                nod2 = j;
                break;
            }
        }
        if (ok == 0) break;
    }

    if (ok == 0)cout << "Deoarece nodurile Neadiacente: " << nod1 << " si " << nod2 << "  au suma gradelor < n, NU verifica Teorema lui Chvatal";
    else cout << "Graful dat verifica Teorema lui Chvatal!";
    cout << endl << endl;
}

void VERIFICA_TRASABIL()
{
    //Mai intai resetam toate gradele, ca sa putem recalcula cu o noua Teorema.
    for (int i = 1; i <= n; i++) GRADE[i] = 0;


    int ok = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++) if (a[i][j] > 0)GRADE[i]++;
    }

    for (int i = 1; i <= n; i++)
    {
        if (GRADE[i] < (n - 1) / 2) ok = 0;
        cout << endl;
    }

    if (ok == 0)cout << "Graful NU este Trasabil.";
    else cout << "Graful Este Trasabil!";
    cout << endl << endl;
}

void DETERMINAREA_INCHIDERII()
{
    cout << "Cream Matricea 'Inchiderii':" << endl;
    //Mai intai resetam toate gradele, ca sa putem recalcula cu o noua Teorema.
    for (int i = 1; i <= n; i++) GRADE[i] = 0;

    //copiem matricea a in b
    for (int i = 1; i <= n; i++) for (int j = 1; j <= n; j++)b[i][j] = a[i][j];

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (a[i][j] > 0)GRADE[i]++;
        }
    }

    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (i != j && GRADE[i] + GRADE[j] >= n && a[i][j] == 0)
            {
                cout << "La graf, adaugam 'inchiderea': " << i << "->" << j << endl;
                b[i][j] = 1;
            }
        }
    }

    //dupa ce construiesti Matricea Inchiderii, verifica daca este a[i][j] =1 peste tot (este graf complet).
    //Numai atunci este Graf Hamiltonian!

    cout << endl;
}

int main()
{
    ///Figura 7.2.7, date de intrare pentru matricea P[][]:
    Write << "6 12 1 2 1 6 2 3 2 4 2 5 2 6 3 6 3 5 3 4 4 5 4 6 5 6";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    AfisareMatrice(a);

    COMPONENTE_CONEXE();
    DF(1);

    VERIFICA_TRASABIL();

    VERIFICA_DIRAC();

    VERIFICA_CHVATAL();

    VERIFICA_ORE();

    VERIFICA_POSA();

    AfisareMatrice(a); cout << endl;

    DETERMINAREA_INCHIDERII();

    cout << "Matricea Adiacenta a 'Inchiderii': " << endl;
    AfisareMatrice(b);
}