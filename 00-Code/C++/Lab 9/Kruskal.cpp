#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;
int i, m, n, P[100][100] = { 0 };
int x, y, c, CC[100] = { 0 }, S[200];


ofstream Write("matrice.txt");
ifstream MyFile("matrice.txt");

void CreareP(int m)
{
    for (int k = 1; k <= m; k++)
    {
        for (i = 1; i <= 3; i++)
        {
            MyFile >> P[i][k];
        }
    }
}

void AfisareMatrice(int a[100][100])
{
    for (int i = 1; i <= 3; i++)
    {
        for (int j = 1; j <= m; j++) cout << setw(4) << a[i][j] << " ";
        cout << endl;
    }
}

void SORTARE()
{
    for (int i = 1; i <= m; i++)
    {
        for (int j = 1; j <= m; j++)
        {
            if (i != j && P[3][i] < P[3][j])
            {
                int temp;
                //cout << "Swap " << i << " and " << j << endl;
                temp = P[1][i]; P[1][i] = P[1][j]; P[1][j] = temp;
                temp = P[2][i]; P[2][i] = P[2][j]; P[2][j] = temp;
                temp = P[3][i]; P[3][i] = P[3][j]; P[3][j] = temp;
            }
        }
    }
}

void bubbleSort(int m) {
    for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= m - i; j++) {
            if (P[3][j] > P[3][j + 1]) {
                for (int k = 1; k <= 3; k++) {
                    int temp = P[k][j];
                    P[k][j] = P[k][j + 1];
                    P[k][j + 1] = temp;
                }
            }
        }
    }
}

void KRUSKAL()
{
    for (int i = 1; i <= m; i++)S[i] = 0;
    for (int i = 1; i <= n; i++) CC[i] = i;
    int cost = 0, poz = 0;

    cout << "Muchie selectata:" << endl;
    for (int l = 1; l <= n - 1; l++)
    {
        int k = poz;
        do
        {
            k++;
            x = P[1][k];
            y = P[2][k];
            c = P[3][k];
        } while (CC[x] == CC[y]);

        S[k] = 1;
        cout << "[" << x << "," << y << "]" << " Cost: " << c << endl;

        cost = cost + c; poz = k;
        int aux = CC[y];

        for (int i = 1; i <= n; i++)if (CC[i] == aux)CC[i] = CC[x];
    }

    cout << "- - - - - - - - - - " << endl;
    cout << "Cost minim total: " << cost;
}

int main()
{
    ///Figura 5.2.1, date de intrare pentru matricea P[][]:
    Write << "10 17 1 2 30 1 5 70 1 7 110 2 3 50 2 5 60 3 4 100 3 6 20 4 6 90 4 9 150 4 10 120 5 6 70 5 9 40 5 8 10 6 9 80 7 8 100 8 9 30 9 10 130";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii

    CreareP(m);

    SORTARE();
    //bubbleSort(m);

    AfisareMatrice(P);

    KRUSKAL();

}