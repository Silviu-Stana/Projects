#include <iostream>
#include <math.h>
#include <string.h>
using namespace std;

class Matrice
{
private:
    int m, n;
    int** data;

public:
    Matrice(int linii, int coloane) {
        m = linii;
        n = coloane;

        //Aloca memorie pt vectorul de pointeri
        data = new int* [m];

        //Aloca memorie pentru fiecare linie
        for (int i = 0; i < m; ++i)
        {
            data[i] = new int[n];
        }

        //Citire de la tastatura
        cout << "Elementele matricii sunt: " << endl;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                cin >> data[i][j];
            }
        }
    }

    //Implicit
    Matrice() : m(0), n(0), data(nullptr) {}

    ~Matrice() {
        for (int i = 0; i < m; ++i)
        {
            delete[] data[i];
        }

        delete[] data;
    }



    Matrice ADUNARE(const Matrice& other) const
    {
        if (m != other.m || n != other.n)
        {
            cout << "Dimensiunile matricilor nu se potrivesc" << endl;
            return Matrice();
        }

        Matrice rezultat(m, n);
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                rezultat.data[i][j] = data[i][j] + other.data[i][j];
            }
        }
        return rezultat;
    }



    void AFISARE()
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; ++j)
            {
                cout << data[i][j] << " ";
            }
            cout << endl;
        }
    }

};

int main()
{
    //Matrici cu 2 linii si coloane
    Matrice m1(2, 2);
    Matrice m2(2, 2);

    Matrice m3;

    m3 = m1.ADUNARE(m2);
    m3.AFISARE();
}
