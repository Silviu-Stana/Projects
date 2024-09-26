///(1) Determinarea unui lanț deschis elementar ce satisface Teorema Dirac
#include <iostream>
#include <fstream>
using namespace std;
int i, m, n, a[100][100] = { 0 };
int x, y, AFostVizitat2[100] = { 0 };
int nrc, CC[100];
ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");
bool totiVeciniiAuFostVizitati = 0;
int ultimulNodVizitat;

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        MyFile >> x >> y;//creaza muchiile
        a[x][y] = 1;
        a[y][x] = 1;
    }
}

bool TesteazaDirac(int a[100][100])
{
    if (n < 3)
    {
        cout << "Are mai putin de 3 noduri, si Teoria lui Dirac se aplica doar la cel putin 3 noduri. (sau mai multe)";
        return 0;
    }

    //Daca oricare nod din graf are gradul < n/2, atunci nu satisface Teorema lui Dirac
    for (int i = 1; i <= n; i++)
    {
        int grad = 0;
        for (int j = 1; j <= n; j++)if (a[i][j] != 0) grad++;

        if (grad < n / 2)
        {
            cout << "Graful NU satisface Teorema lui Dirac." << " Deoare nodul " << i << " are gradul mai mic decat " << n / 2 << endl;
            return 0;
        }
    }
    cout << "Graful satisface Teorema lui Dirac, si are cel putin un Lant elementar." << endl;
    return 1;
}

void GasesteUnLant(int nodStart, int inMatricea[100][100])
{
    cout << "Lantul urmator satisface teorema: ";

    AFostVizitat2[nodStart] = 1;

    int nodCurent = nodStart;
    cout << nodCurent << " ";

    do
    {
        totiVeciniiAuFostVizitati = 1;

        for (int j = 1; j <= n; j++)
        {
            if (a[nodCurent][j] == 1 && AFostVizitat2[j] == 0)
            {
                nodCurent = j;
                ultimulNodVizitat = j;

                AFostVizitat2[nodCurent] = 1;
                cout << nodCurent << " ";

                //Daca vizitam orice noua valoare, inseamna ca nu am vizitat inca toti vecinii!
                totiVeciniiAuFostVizitati = 0;
            }
        }


    } while (totiVeciniiAuFostVizitati == 0);
    cout << endl;

    //if last node is connected to starting node, we have a CYCLE
    if (a[ultimulNodVizitat][nodStart] == 1)
    {
        cout << "Acest lant este si un ciclu (care satisface teorema), deoare ultimul nod vizitat " << ultimulNodVizitat << " este conectat de Primul nod din lant: " << nodStart << endl;
    }
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
    Write << "4 4 1 2 2 3 3 4 4 1";
    Write.close();



    MyFile >> n;//nod
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);

    //Pornind din nodul "2", merge cat timp mai are vecini nevizitati. Astfel gasim un lant, ce satisface Teoria lui Dirac.
    if (TesteazaDirac(a)) GasesteUnLant(2, a);

    //AfisareMatrice(a);
}
