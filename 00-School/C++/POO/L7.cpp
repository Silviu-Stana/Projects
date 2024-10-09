#include <iostream>

using namespace std;

class Multime
{
private:
    int m;
    int* data;
public:
    // constructori
    Multime();
    Multime(int);
    Multime(int, int*);
    // destructor
    ~Multime();
    // afisare
    friend ostream& operator<<(ostream&, const Multime&);
    // citire
    friend istream& operator>>(istream&, const Multime&);
    // atribuire
    Multime& operator=(const Multime&);

    // reuniune
    Multime operator+(const Multime&);
};

//VOI FACE IMPLEMENTAREA IN AFARA CLASEI

Multime::Multime() { m = 0; data = NULL; }

Multime::Multime(int x)
{
    m = x;
    data = new int[m];

    cout << "Da cele " << m << " numere: " << endl;
    for (int i = 0; i < m; i++)cin >> data[i];
}

Multime::Multime(int x, int* date)
{
    m = x;
    data = date;
}

Multime::~Multime()
{
    delete[] data;
}

ostream& operator<<(ostream& out, const Multime& mult)
{
    for (int i = 0; i < mult.m; i++) out << mult.data[i] << " ";
    out << endl;

    return out;
}

istream& operator>>(istream& in, const Multime& mult)
{
    cout << "Dati toate cele " << mult.m << " numere din multime:" << endl;
    for (int i = 0; i < mult.m; i++) in >> mult.data[i];

    return in;
}

Multime& Multime::operator=(const Multime& mult)
{
    this->m = mult.m;
    this->data = mult.data;

    return *this;
}

// reuniune
Multime Multime::operator+(const Multime& other)
{
    //temp va tine valoarea veche a lui m (nr elemente)
    int temp = m;
    m = m + other.m;

    int* tempData = data;//tinem datele temporar stocate ca sa alocam o noua dimensiune de vector, si apoi realocam elementele din multime inapoi in "data"

    data = new int[m + other.m];

    data = tempData;
    for (int i = temp; i < m; i++)
    {
        //i-temp inseamna ca o ia de la inceputul vectorului "temp" si umple multimea din "data" cu noile elemente
        data[i] = other.data[i - temp];
    }
}

int main()
{

}
