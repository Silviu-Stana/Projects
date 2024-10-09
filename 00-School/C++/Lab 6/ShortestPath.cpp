///Figura din Curs 3.1.3
///Putem gasi cel mai scurt drum folosind BF, modificand distanta fiecarui nod, cu cat coboram fiecare nivel de adancime!
///Vom seta distantele la "-1" la nodurile care nu putem ajunge. (din alte componente conexe)

#include <iostream>
#include <fstream>
#include <climits> // For INT_MAX
using namespace std;
int i, j, m, n, a[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int varf, coada, S[100] = { 0 }, URM[100] = { 0 }, Distanta[100], distanta = 0;
int DrumMinim[100] = { 0 };
int nodStart, nodFinal;

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
    AFostVizitat2[x] = 1;
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

            if (AFostVizitat2[j] == 0) //j not visited
            {
                AFostVizitat2[j] = 1;
                TATA[j] = i;
                coada++;
                S[coada] = j;

                Distanta[j] = Distanta[i] + 1; // Distanta fiecarui nod este distanta TATA-lui sau + 1
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

int DistantaIntreNoduri(int nodPornire, int finalNODE)
{
    int dist = 0;
    int temp = finalNODE;
    int k = 1;

    while (temp != nodPornire && TATA[temp] != 0)
    {
        dist++;
        temp = TATA[temp];
    }

    return dist;
}

void DrumulDeDistantaMinima(int finalNODE)
{
    int nodCurent = finalNODE;
    int lungimeDrum;

    for (int i = 0; i < n; i++)
    {
        DrumMinim[i] = nodCurent;
        nodCurent = TATA[nodCurent];

        if (nodCurent == 0) { lungimeDrum = i; break; }
    }

    cout << "Lungimea drumului minim este de: " << lungimeDrum << endl;

    cout << "Drumul de distanta MINIMA de la nodul  " << nodStart << " la " << nodFinal << "este:" << endl;
    for (int i = lungimeDrum; i >= 0; i--)
    {
        cout << DrumMinim[i];
        if (i != 0)cout << "->";
    }


}

int main()
{
    Write << "5 7 1 2 2 3 2 4 2 5 3 1 3 2 5 4";
    Write.close();

    MyFile >> n;//cout<<"Nr nodes: ";
    MyFile >> m;//cout<<"Nr connections: ";

    CreareMatriceAdiacenta(n, m);

    cout << "De la ce nod pornesti: "; cin >> nodStart;

    Distanta[nodStart] = 0;
    BF(nodStart);
    for (int i = 1; i <= n; i++)if (AFostVizitat2[i] == 0) Distanta[i] = -1;



    cout << "La ce nod vrei sa ajungi: "; cin >> nodFinal;
    if (Distanta[nodFinal] == -1) cout << "Nu putem ajunge la nod. (Face parte din alta componenta conexa.)";
    else DrumulDeDistantaMinima(nodFinal);
    //cout << "Distanta cea mai scurta de la nodul [" << nodStart << "] la nodul [" << nodFinal << "] este:  " << Distanta[nodFinal];
}
