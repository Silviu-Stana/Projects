#include <iostream>
#include <string.h>
using namespace std;

class Produs
{
protected:
    char* nume;
    double pret;
    int stoc;
    char cod[10];

public:
    Produs();
    Produs(const char*, double, int, const char[]);
    Produs(const Produs&);
    virtual ~Produs();

    virtual void Print();
    virtual double Stoc();
    virtual void Eticheta();
    virtual int Garantie();

    //alimentar
    //electronic
};

Produs::Produs()//implicit
{
    nume = NULL;
    pret = 0;
    stoc = 0;
}

Produs::Produs(const char* n, double p, int s, const char c[10])
{
    nume = new char[strlen(n) + 1];
    strcpy(nume, n);

    pret = p;
    stoc = s;
    strcpy(cod, c);
}

Produs::Produs(const Produs& p)
{
    nume = new char[strlen(p.nume) + 1];
    strcpy(nume, p.nume);

    pret = p.pret;
    stoc = p.stoc;
    strcpy(cod, p.cod);
}

Produs::~Produs()
{
    delete[] nume;
}

void Produs::Print()
{
    cout << "Nume: " << nume << "\n";
    cout << "Pret: " << pret << "\n";
    cout << "Stoc: " << stoc << "\n";
    cout << "Cod: " << cod << "\n";
}

double Produs::Stoc()
{
    return pret * stoc;
}

void Produs::Eticheta()
{
    cout << "Ati selectat produsul cu numele " << nume << "'\n";
}

int Produs::Garantie()
{
    return 0;
}

class Aliment : public Produs
{
private:
    int expira;

public:
    Aliment();
    Aliment(const char*, double, int, const char[], int);
    Aliment(const Aliment&);
    virtual ~Aliment();

    virtual void Print();
    virtual double Stoc();
    virtual void Eticheta();
};

Aliment::Aliment(const char* n, double p, int s, const char c[10], int e) : Produs(n, p, s, c)
{
    expira = e;
}

Aliment::Aliment(const Aliment& a) : Produs(a)
{
    expira = a.expira;
}

void Aliment::Print()
{
    Produs::Print();
    cout << "Perioada de expirare: " << expira << endl;
}

double Aliment::Stoc()
{
    return pret * stoc;
}

void Aliment::Eticheta()
{
    cout << "Ati selectat alimentul cu numele: " << nume << endl;
}

Aliment::~Aliment() {}

class Electronic : public Produs
{
public:
    Electronic();
    Electronic(const char*, double, int, const char[], int);
    Electronic(const Electronic&);
    virtual ~Electronic();

    ///TEMA: Implementarea functiei
    virtual void Print();
    virtual void Eticheta();
    virtual int Garantie();
};

class Raft
{
private:
    int nrProd;
    Produs* produs[100];

public:
    Raft();

    ~Raft();

    Raft& Adauga(Produs*);
    Produs* Elimina();

    void InfoProdRaft();
    void Continut();
};

Raft::Raft() { nrProd = 0; }
Raft::~Raft() { for (int i = 0; i < nrProd; i++) delete produs[i]; }

Raft& Raft::Adauga(Produs* p)
{
    if (nrProd == 100) {
        Produs* u = produs[0];
        for (int i = 1; i < nrProd; i++)
        {
            produs[i - 1] = produs[i];
        }

        produs[nrProd++] = p;

        return *this;
    }
    return *this;
}

Produs* Raft::Elimina()
{
    if (nrProd == 0) return 0;

    Produs* p = produs[nrProd - 1];
    nrProd--;
    return p;
}

void Raft::InfoProdRaft()
{
    for (int i = 0; i < nrProd; i++)
    {
        produs[i]->Print();
    }
}

void Raft::Continut()
{
    for (int i = 0; i < nrProd; i++)
    {
        produs[i]->Eticheta();
    }
}

int main()
{
    Produs* p1 = new Produs("Sacou", 300, 10, "XCTR937");
    Produs* p2 = new Aliment("Paine", 2000, 3, "PAINE-826", 2);
    Produs* p3 = new Produs("Carte", 300, 100, "CARTE-162");

    Raft r;
    r.Adauga(p1).Adauga(p2).Adauga(p3);
    cout << "Raftul are: " << endl;
    r.Continut();

}