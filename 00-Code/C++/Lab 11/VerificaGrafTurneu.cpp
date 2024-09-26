#include <iostream>
#include <fstream>
using namespace std;
int i, j, m, n, a[100][100] = { 0 }, b[100][100] = { 0 };
int x, y, TATA[100], AFostVizitat2[100] = { 0 };
int varf, coada, S[100] = { 0 }, URM[100] = { 0 };
int GradIntrare[100] = { 0 };
int GradIesire[100] = { 0 };
int sumaGradeIntrare = 0, sumaGradeIesire = 0;


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
        b[x][y] = 1;
        b[y][x] = 1;
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

///Exemplu din curs  Figura 8.1.1:
bool VerificaTurneu()
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (i != j) if (a[i][j] == 0) if (a[j][i] == 0) return 0;
        }
    }
    return 1;
}

void GradNoduriOrientate(int a[100][100])
{
    //Suma Grad Intrare
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= n; j++) { GradIntrare[i] += a[i][j]; GradIesire[i] += a[j][i]; }
        //cout << "Gradul nodului " << i << " de intrare: " << GradIntrare[i] << endl;
        //cout << "Gradul nodului " << i << " de iesire: " << GradIesire[i] << endl;
        //cout << "Gradul Total al nodului " << i << " : " << GradIntrare[i]+GradIesire[i] << endl;
    }

    for (int i = 1; i <= n; i++)
    {
        sumaGradeIntrare += GradIntrare[i];
        sumaGradeIesire += GradIesire[i];
    }
}

int main()
{
    ///Figura 5.2.1, date de intrare pentru matricea P[][]:
    Write << "6 15 1 3 2 3 2 6 2 1 2 5 3 5 4 5 4 3 4 1 4 2 5 1 6 1 6 4 6 5 6 3";
    Write.close();

    MyFile >> n;//nodes
    MyFile >> m;//muchii


    CreareMatriceAdiacenta(n, m);
    AfisareMatrice(b);

    GradNoduriOrientate(a);

    bool esteTurneu = VerificaTurneu();

    if (esteTurneu) cout << "Este graf Turneu" << endl;
    else cout << "NU este graf  Turneu" << endl;

    if (m == n * (n - 1) / 2 && esteTurneu)
    {
        bool conditia2 = true, conditia3 = true;

        cout << "Verifica Conditia 1" << endl;
        for (int i = 1; i <= n; i++)
        {
            if (GradIntrare[i] + GradIesire[i] != n - 1)
            {
                conditia2 = false;
                break;
            }
        }

        if (conditia2) cout << "Verifica Conditia 2" << endl;
        else          cout << "NU Verifica Conditia 2" << endl;

        if (sumaGradeIesire != sumaGradeIesire) conditia3 = false;
        if (sumaGradeIntrare != n * (n - 1) / 2) conditia3 = false;

        if (conditia3) cout << "Verifica Conditia 3" << endl;
        else          cout << "NU Verifica Conditia 3" << endl;

    }
}

