#include <iostream>

using namespace std;

class Fractie
{
private:
    int numarator;
    int numitor;

    friend int cmmdc(int a, int b);

public:
    Fractie(): numarator(0), numitor(1) {}//implicit
    Fractie(int m, int n): numarator(m), numitor(n) {}
    Fractie(const Fractie);

    friend void Simplificare(Fractie& f);


    friend ostream& operator<<(ostream& out, Fractie& f)
    {
        out << f.numarator << "/" << f.numitor<< endl;
        return out;
    }

    friend istream& operator>>(istream& in, Fractie& f)
    {
        in >> f.numarator >> f.numitor;
        return in;
    }


    void afisare()
    {
        cout<<numarator << "/"<<numitor<<"\n";
    }

    Fractie operator+(Fractie& f)
    {
        int m = f.numarator * numitor + numarator * f.numitor;
        int n = numitor * f.numitor;

        Fractie rezultat(m, n);

        Simplificare(rezultat);

        return rezultat;
    }


    Fractie& operator=(Fractie& f)
    {
        if(this != &f)
        {
            this->numarator = f.numarator;
            this->numitor = f.numitor;
        }

        return *this;
    }

    Fractie& operator++()
    {
        numarator+= numitor;
        return *this;
    }
    //supraincarcarea operator ++,forma postfixata
    Fractie operator++(int)
    {
        Fractie temp(*this);
        numarator+=numitor;
        return temp;
    }

   /* Fractie operator++(Fractie& f)
    {
        int m =  f.numarator+f.numitor;
        int n = f.numitor;

        Fractie rezultat(m, n);

        Simplificare(rezultat);

        return rezultat;
    }

*/


    Fractie operator-(Fractie& f)
    {
        int m = f.numitor * numarator- f.numarator * numitor;
        int n = numitor * f.numitor;

        Fractie rezultat(m, n);

        Simplificare(rezultat);

        return rezultat;
    }


    Fractie operator*(Fractie& f)
    {
        int m = f.numarator * numarator;
        int n = numitor * f.numitor;

        Fractie rezultat(m, n);

        Simplificare(rezultat);

        return rezultat;
    }


};
Fractie::Fractie(Fractie &f)
{
    numarator=f.numarator;
    numitor=f.numitor;
}
int cmmdc(int a, int b)
{
    if(b==0)return a;

    return(cmmdc(b, a%b));
}

void Simplificare(Fractie& f)
{
    int d = cmmdc(f.numarator, f.numitor);
    f.numarator /= d;
    f.numitor /= d;
}

int main()
{
    Fractie f1(1,4);
    Fractie f2(1,2);

    Fractie f_add;
    //f_add=f1-f2;
    f_add=f1*f2;

    Fractie fractie1(10,20);
    Fractie fractie2(13,27);
    fractie1=fractie2;

    cout<<f_add;
    return 0;
}
