#include <iostream>
#include <math.h>

using namespace std;

class Latura
{
private:
    int lungime;

public:
    Latura();
    Latura(int);

    Latura& operator=(const Latura&);
    friend istream& operator>>(istream&, Latura&);

    int getLength()const;

};

Latura::Latura() : lungime(0) {}
Latura::Latura(int l) : lungime(l) {}
Latura& Latura::operator=(const Latura& l)
{
    if (this == &l) return *this;

    lungime = l.lungime;

    return *this;
}


istream& operator>>(istream& in, Latura& l)
{
    cout << "Lungimea laturii este: ";
    in >> l.lungime;
    return in;
}

int Latura::getLength() const { return lungime; }


class Figura
{
protected:
    int nrLat;
    Latura* lat;

public:
    Figura();
    Figura(int);
    Figura(int, Latura*);
    ~Figura();

    friend ostream& operator<<(ostream& out, const Figura&);

    int perimetru();
};


Figura::Figura()
{
    nrLat = 0;
    lat = NULL;
}

Figura::Figura(int nr)
{
    nrLat = nr;
    lat = new Latura[nrLat];
}

Figura::Figura(int nrLat, Latura* lat)
{
    this->nrLat = nrLat;
    this->lat = new Latura[nrLat];

    for (int i = 0; i < nrLat; i++)
    {
        this->lat[i] = lat[i];
    }
}

ostream& operator<<(ostream& out, const Figura& f)
{
    out << "Aceasta este figura cu laturile: ";
    for (int i = 0; i < f.nrLat; i++) out << f.lat[i].getLength() << " ";

    out << endl;
    return out;
}

int Figura::perimetru()
{
    int suma = 0;
    for (int i = 0; i < nrLat; i++)
    {
        suma += lat[i].getLength();
    }
    return suma;
}

Figura::~Figura()
{
    delete[] lat;
}

//CONSTRUCTORII NU SE MOSTENESC
class Triunghi : public Figura
{
public:
    Triunghi(Latura*);
    Triunghi();

    double aria();
};

Triunghi::Triunghi() : Figura(3)
{
    for (int i = 0; i < 3; i++) cin >> lat[i];
}

Triunghi::Triunghi(Latura* l) : Figura(3)
{
    for (int i = 0; i < 3; i++)
    {
        lat[i] = l[i].getLength();
        cin >> lat[i];
    }
}

double Triunghi::aria()
{
    int p = perimetru() / 2;
    //Formula lui Herron
    return sqrt(p * (p - lat[0].getLength()) * (p - lat[1].getLength()) * (p - lat[2].getLength()));
}

/*
Triunghi::Triunghi(int nr, Latura* laturi)
{
    nrLat = nr;
    lat = new Latura[nrLat];

    for(int i=0; i<nrLat; i++)
    {
        lat[i] = laturi[i];
    }
}
*/


class Patrat : public Figura
{
public:
    //facem constructori
    Patrat(Latura*);


    //calculam aria
    Patrat();

    double aria();
};

Patrat::Patrat() : Figura(4)
{
    for (int i = 0; i < 4; i++) cin >> lat[i];
}

Patrat::Patrat(Latura* l) : Figura(4)
{
    for (int i = 0; i < 4; i++)
    {
        lat[i] = l[i].getLength();
        cin >> lat[i];
    }
}

double Patrat::aria()
{
    return lat[0].getLength() * lat[0].getLength();
}

int main()
{
    int numarLaturi;
    cout << "Nr laturi: "; cin >> numarLaturi;

    //Latura* laturi = new Latura[numarLaturi];

    //for(int i=0; i<numarLaturi; i++) cin>>laturi[i];
    //Figura fig(numarLaturi, laturi);

    //cout<<fig;

    Triunghi t;

    cout << t;


    //delete[] laturi;

}