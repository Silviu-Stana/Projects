#include <iostream>
using namespace std;

class Pagina {
private:
    const char* content;
    int pg; //nr pagini
public:
    Pagina() : pg(0), content(NULL) {}
    Pagina(const char* content, int pg)
    {
        this->pg = pg;
        this->content = new char[pg];
    }

    const char* continut() const
    {
        for (int i = 0; i < pg; i++)cout << content[i];
    }

    int getPg() const
    {
        return pg;
    }
};

class Carte {
protected:
    Pagina* pagini;
    int npg; //nr pagini
    const char* author;
public:
    Carte() : pagini(NULL), npg(0), author(NULL) {};

    Carte(const char* author, int size)
    {
        this->author = author;
        this->npg = size;
    }

    ~Carte()
    {
        delete[] pagini;
        delete[] author;
    }

    int getNpg() const { return npg; }
    void print() const
    {
        cout << "Nr pagini: " << npg;

        //Printeaza continutul din fiecare pagina.
        for (int i = 0; i < npg; i++) pagini[i].continut();
    }
};

class CarteFictiune : public Carte {
private:
    const char* gen;
public:
    CarteFictiune(const char* author, const char* gen, int size)
    {
        this->author = author;
        this->gen = gen;
        this->npg = size;
    }
    void print() const
    {
        Carte::print();
    }
};

class CarteNonFictiune : public Carte {
private:
    const char* subiect;

public:
    CarteNonFictiune(const char* author, const char* subiect, int size)
    {
        this->author = author;
        this->subiect = subiect;
        this->npg = size;
    }
    void print() const
    {
        Carte::print();
    }
};

int main()
{

}
