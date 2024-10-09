///Date intrare:  5 7 1 2 2 3 2 4 2 5 3 1 3 2 5 4
#include <iostream>
#include <climits> // For INT_MAX
using namespace std;

int n, m;
int a[100][100] = { 0 };
int TATA[100], AFostVizitat2[100] = { 0 };
int varf, coada, S[100] = { 0 }, URM[100] = { 0 }, D[100] = { INT_MAX };

void CreareMatriceAdiacenta(int n, int m) {
    for (int i = 1; i <= m; i++) {
        cin >> a[i][0] >> a[i][1];
        a[a[i][0]][a[i][1]]++;
    }
}

void BF(int x) {
    AFostVizitat2[x] = 1;
    TATA[x] = 0;
    D[x] = 0;
    varf = 1;
    S[coada] = x;

    while (varf <= coada) {
        int i = S[varf];
        int j = URM[i] + 1;
        while (a[i][j] == 0 && j <= n) j++;

        if (j > n)
            varf++;
        else {
            URM[i] = j;
            if (AFostVizitat2[j] == 0) {
                AFostVizitat2[j] = 1;
                TATA[j] = i;
                coada++;
                S[coada] = j;
                D[j] = D[i] + 1; // Update distance
            }
        }
    }

    for (int y = 1; y <= n; y++) {
        if (a[x][y] >= 1 && AFostVizitat2[y] == 0) {
            TATA[y] = x;
            BF(y);
        }
    }
}

int main() {
    cin >> n >> m;

    CreareMatriceAdiacenta(n, m);

    int nodStart, nodFinal;
    cout << "De la ce nod pornesti: ";
    cin >> nodStart;
    BF(nodStart);

    cout << "La ce nod vrei sa ajungi: ";
    cin >> nodFinal;

    if (D[nodFinal] == INT_MAX) {
        cout << "Nu exista drum de la nodul " << nodStart << " la nodul " << nodFinal << endl;
    }
    else {
        cout << "Distanta cea mai scurta de la nodul " << nodStart << " la nodul " << nodFinal << " este: " << D[nodFinal] << endl;
    }

    return 0;
}
