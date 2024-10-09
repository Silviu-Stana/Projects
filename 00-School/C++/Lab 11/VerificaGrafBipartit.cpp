#include <iostream>
#include <fstream>
using namespace std;
int i, j, m, n, a[100][100] = { 0 }, b[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat[100] = { 0 }, Distanta[100] = { 0 }, distantaMaxima, multimiBipartite[100] = { 0 };
int varf, coada, S[100] = { 0 }, URM[100] = { 0 };

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
}

void BF(int x)
{
    cout << x << " ";
    AFostVizitat[x] = 1;
    TATA[x] = 0;
    coada = 1;
    varf = 1;
    S[coada] = x;


    while (varf <= coada)
    {
        i = S[varf];
        j = URM[i] + 1;

        while (a[i][j] == 0 && j <= n)j++;

        if (j > n) {
            varf++;
        }
        else {
            URM[i] = j; //j next successor

            if (AFostVizitat[j] == 0) //j not visited
            {
                cout << j << " ";
                AFostVizitat[j] = 1;
                TATA[j] = i;
                coada++;
                S[coada] = j;

                Distanta[j] = Distanta[i] + 1; // Distanta fiecarui nod este distanta TATA-lui sau + 1
                distantaMaxima = Distanta[i] + 1;
            }
        }
    }

    for (int y = 1; y <= n; y++)
    {
        if (a[x][y] >= 1 && AFostVizitat[y] == 0)
        {
            TATA[y] = x;
            BF(y);
        }
    }
}


void AfisareMultimiBipartite()
{
    cout << "Nodurile din Multimea Bipartita 'X': ";
    for (int i = 1; i <= n; i++) if (multimiBipartite[i] == 1) cout << i << " ";
    cout << endl;

    cout << "Nodurile din Multimea Bipartita 'Y: ";
    for (int i = 1; i <= n; i++) if (multimiBipartite[i] == 2) cout << i << " ";
    cout << endl;
}

void VerificaBipartit() {
    cout << endl;
    //Alocam nodurile in 2 multimi
    for (int i = 1; i <= n; i++)
    {
        if (Distanta[i] % 2 == 0) multimiBipartite[i] = 1;
        else multimiBipartite[i] = 2;
    }


    int ok = 1;//Asumam initial ca graful este Bipartit

    //ia fiecare nod
    for (int i = 1; i <= n; i++)
    {

        for (int j = 1; j <= n; j++)
        {
            //Verifica daca are muchie catre un nod din Cealalta Multime
            if (a[i][j] == 1 && multimiBipartite[j] != multimiBipartite[i])
            {
                ok = 0;
                break;
            }
        }
        if (ok == 0) break;
    }

    if (ok == 1) cout << "Graful Este Bipartit!" << endl;
    else cout << "Graful NU Este Bipartit!" << endl;






    AfisareMultimiBipartite();
}



int main()
{
    ///Exemplu din "Laboratorul 11"  Figura 5:
    Write << "11 18 1 2 1 4 1 5 2 3 3 4 3 5 3 6 4 7 5 7 5 10 5 8 6 9 6 8 7 9 7 11 8 11 9 10 10 11";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii


    CreareMatriceAdiacenta(n, m);
    AfisareMatrice(a);

    cout << "BF(1): " << endl;
    BF(1);

    VerificaBipartit();
}

