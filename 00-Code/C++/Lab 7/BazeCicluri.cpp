///Exemplu din curs: Figura 4.1.1 date de intrare:  7 10 1 4 1 2 2 4 2 5 4 5 2 3 5 6 3 6 3 7
#include <iostream>
#include <fstream>
using namespace std;
int i, m, n, a[100][100] = { 0 }, arboreT[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int nrc, CC[100];
int d[100][100];
int drum1[20], drum2[20];
int lungimeDrum, TATAcomun, ciclu = 1;
ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

/*
Pas1) CreareMatriceAdiacenta() pentru arbore partial T
Pas2) Compara Matricea initiala cu cea partiala
Pas3) Cand gasesti o valoare diferita asuma ca acea Muchie va fii folosita pentru construirea urmatorului ciclu.
*/

void CreareMatriceAdiacenta(int n, int m)
{
    for (i = 1; i <= m; i++)
    {
        //cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        MyFile >> x >> y;
        a[x][y] = 1;
        a[y][x] = 1;
    }
}

void DF(int x)
{
    //cout<<x<< " ";//afisare nod vizitat
    AFostVizitat2[x] = 1;
    CC[x] = nrc;

    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] && AFostVizitat2[y] == 0)
        {
            //Cream arborele partial T (care ne ajuta sa identificam muchiile lipsa)
            arboreT[x][y] = 1;
            arboreT[y][x] = 1;

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

    //cout<<"Numarul de componente conexe: " << nrc<<endl;
}

bool NuAmGasitNodParinteComun()
{
    for (int q = 0; q <= lungimeDrum; q++)
        for (int r = 0; r <= lungimeDrum; r++)
            //Am gasit un nod TATA comun.
            if (drum1[q] == drum2[r])
            {
                TATAcomun = q;
                return false;
            }

    //Daca iese din for, nu am gasit un nod PARINTE comun.
    return true;
}

void IDENTIFICA_CICLU(int i, int j)
{


    lungimeDrum = 1;
    //"i" este primul nod de pornire al drumului
    drum1[0] = i;
    //"j" este al doilea nod de pornire al drumului
    drum2[0] = j;

    //al 2-lea nod din drum sunt TATII sai.
    drum1[lungimeDrum] = TATA[i];
    drum2[lungimeDrum] = TATA[j];

    while (NuAmGasitNodParinteComun())
    {
        //DEBUG: folosim aceste linii ca sa identificam prin ce drum merg ambele noduri, pana gasesc un parinte comun
        //cout<<"Drum1:"; for(int i=1; i<=lungimeDrum; i++) cout<<drum1[i] << " ";
        //cout<<endl;
        //cout<<"Drum2:"; for(int i=1; i<=lungimeDrum; i++) cout<<drum2[i] << " ";

        lungimeDrum++;

        //Navigheaza parintii in sus, pana gasesc o RADACINA comuna nodurile i si j.
        if (TATA[i] != 0) drum1[lungimeDrum] = TATA[drum1[lungimeDrum]];
        if (TATA[i] != 0) drum2[lungimeDrum] = TATA[drum2[lungimeDrum]];
    }

    //cout<<"Nod TATA comun: " << TATAcomun << endl;

    //Dupa ce am gasit un nod PARINTE comun, incepem sa navigam IN SUS si sa scriem ciclul:
    cout << "Ciclu" << ciclu << ": " << "[" << i << "-" << j << "] ";

    int nodCurent = j;
    if (nodCurent != TATAcomun) cout << "[" << nodCurent << "-" << TATA[nodCurent] << "] ";


    nodCurent = TATA[nodCurent];

    while (nodCurent != TATAcomun)
    {
        cout << "[" << nodCurent << "-" << TATA[nodCurent] << "] ";
        nodCurent = TATA[nodCurent];
    }

    nodCurent = TATAcomun;

    //Trebuie sa gasim indexul (inauntrul vectorului drum2[]) unde se afla parintele mai intai, apoi vem putea naviga invers catre 0, ca sa afisam ce a ramas din ciclu.
    int parcurgeDrum;
    for (int p = 1; p <= lungimeDrum; p++)if (drum2[p] == TATAcomun) { parcurgeDrum = p; break; }

    //Se intoarce inapoi IN JOS la al 2-lea nod care a format ciclu. (pana aici am navigat pana la radacina comuna dintre cele 2 noduri)
    while (nodCurent != i)
    {
        parcurgeDrum--;
        cout << "[" << nodCurent << "-" << drum1[parcurgeDrum] << "] ";
        nodCurent = drum1[parcurgeDrum];
    }

    cout << endl;

    if (ciclu != m - n + nrc) ciclu++;
}



int BAZE_CICLURI()
{
    cout << "BAZA DE CICLURI" << endl;
    ciclu = 1;
    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= n; j++)
        {
            // Am gasit o muchie lipsa (eliminata in arborele partial DF(1), fiecare muchie lipsa formeaza un NOU ciclu din baza)
            if (a[i][j] != arboreT[i][j])
            {
                IDENTIFICA_CICLU(i, j);
                //Daca am gasit un ciclu, modifica arborele partial a[j][i]: ca sa nu identificam fiecare ciclu de 2 ori.
                a[j][i] = 1;
            }

            //Am gasit deja toate ciclurile? Iesi din functie.
            if (ciclu == m - n + nrc)return 0;
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
    Write << "7 10 1 4 1 2 2 4 2 5 4 5 2 3 5 6 3 6 3 7";
    Write.close();

    MyFile >> n;//nod
    MyFile >> m;//muchii

    CreareMatriceAdiacenta(n, m);
    COMPONENTE_CONEXE();
    //cout << "Nr ciclomatic este: " << m-n+nrc<<endl;

    DF(1);
    //AfisareMatrice(a);
    //AfisareMatrice(arboreT); //Afisam matricea initiala, si arborele partial format cu DF (ca sa testez programul)

    BAZE_CICLURI();
}
