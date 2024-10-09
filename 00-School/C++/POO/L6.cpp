#include <iostream>
#include <math.h>

using namespace std;

class Punct
{
private:
    int x, y;

public:
    Punct() { x = 0; y = 0; }

    Punct(int a, int b) : x(a), y(b) {}


    Punct& operator=(Punct& pct)
    {
        if (this != &pct)
        {
            this->x = pct.x;
            this->y = pct.y;
        }
        return *this;
    }

    //Prefixata
    Punct& operator++()
    {
        x++;
        y++;
        return *this;
    }

    //Postfix
    Punct& operator++(int)
    {
        Punct temp(x, y);

        this->x++;
        this->y++;

        return temp;
    }

    Punct& operator+(int a)
    {
        x += a;
        y += a;

        return *this;
    }

    Punct& operator+(Punct& pct)
    {
        x += pct.x;
        y += pct.y;
        return *this;
    }

    Punct& operator*(Punct& pct)
    {
        Punct temp;
        int distantaX = (pct.x - x) * (pct.x - x);
        int distantaY = (pct.y - y) * (pct.y - y);

        temp.x = distantaX;
        temp.y = distantaY;

        return temp;
    }

    ostream& operator<<(ostream& out)
    {
        out << "Coordonatele punctului sunt:" << endl;
        out << "X: " << this->x << endl;
        out << "Y: " << this->y << endl;
        return out;
    }

    istream& operator>>(istream& in)
    {
        cout << "Decide Coordonatele Punctului:" << endl;
        cout << "X:";  in >> this->x;
        cout << "Y:";  in >> this->y;
        return in;
    }

    void VerificareCadran
    {
        if (x > 0 && y > 0) cout << "Cadranul 1";
        else if (x < 0 && y>0) << "Cadranul 2";
        else if (x > 0 && y < 0) << "Cadranul 4";
        else if (x < 0 && y < 0) << "Cadranul 3";
        else cout << "Nu se afla in niciun cadran, deoarece este direct: pe axa  OX  sau  OY";
    }

};

int main()
{

}
