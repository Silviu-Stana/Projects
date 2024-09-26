#include <iostream>
#include <vector>
#include <stack>
#include <algorithm>
using namespace std;

int n, m, a[100][100] = { 0 };
int x, y, TATA[100], TATA2[100], AFostVizitat2[100] = { 0 }, VIZ2[100] = { 0 };
int nrc = 0, CTC[100], CTC2[100];
vector<vector<int>> componente;

void CreareMatriceAdiacenta(int n, int m) {
    for (int i = 1; i <= m; i++) {
        cin >> x >> y;
        a[x][y]++;
    }
}

void DF(int x, bool transpus) {
    if (transpus) {
        VIZ2[x] = 1;
        CTC2[x] = nrc;
    }
    else {
        AFostVizitat2[x] = 1;
        CTC[x] = nrc;
    }

    for (int y = 1; y <= n; y++) {
        if (transpus ? a[y][x] : a[x][y]) {
            if ((transpus && !VIZ2[y]) || (!transpus && !AFostVizitat2[y])) {
                if (transpus) {
                    TATA2[y] = x;
                    DF(y, transpus);
                }
                else {
                    TATA[y] = x;
                    DF(y, transpus);
                }
            }
        }
    }
}

void COMPONENTE_TARE_CONEXE() {
    for (int i = 1; i <= n; i++) {
        CTC[i] = 0;
        CTC2[i] = 0;
        AFostVizitat2[i] = 0;
        VIZ2[i] = 0;
    }

    for (int i = 1; i <= n; i++) {
        if (!AFostVizitat2[i]) {
            nrc++;
            DF(i, false);
        }
    }

    for (int i = n; i >= 1; i--) {
        if (!VIZ2[i]) {
            nrc++;
            DF(i, true);
        }
    }
}

void AfisareListeConexe() {
    cout << "Numarul de componente TARE conexe: " << nrc << endl;

    for (int j = 1; j <= nrc; j++) {
        cout << "Component " << j << " contains: ";
        for (int i = 1; i <= n; i++) {
            if (CTC[i] == j || CTC2[i] == j)
                cout << i << " ";
        }
        cout << endl;
    }
}

int main() {
    cin >> n; // noduri
    cin >> m; // muchii

    CreareMatriceAdiacenta(n, m);

    COMPONENTE_TARE_CONEXE();

    AfisareListeConexe();
}
