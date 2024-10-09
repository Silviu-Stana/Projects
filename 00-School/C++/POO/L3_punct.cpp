#include <iostream>
#include <math.h>

using namespace std;

class Punct
{
private:
    int x;//axa OX
    int y;//axa OY

public:

    //Constructor cu parametri
    Punct(int x, int y)
    {
        this->x = x;
        this->y = y;

        //cout: pentru testare output
        cout << "x:" << x << endl << "y:" << y << endl;
    }

    //Implicit
    Punct()
    {
        x = 0;
        y = 0;
        cout << "x:" << x << endl << "y:" << y << endl;
    }

    //De copiere (care da voie inclusiv la obiecte const)
    Punct(const Punct& p)
    {
        x = p.x;
        y = p.y;
        cout << "x:" << x << endl << "y:" << y << endl;
    }

    ~Punct()
    {
        //Destructorul implicit: functioneaza automat corect
    }

    void afiseaza()
    {
        cout << "Coordonatele punctului sunt:";
        cout << "x:" << x << endl << "y:" << y << endl;
    }

    int getX() { return x; }
    int getY() { return y; }

    void setX(int x)
    {
        this->x = x;
    }

    void setY(int y)
    {
        this->y = y;
    }

    static int dist2(Punct& A, Punct& B)
    {
        return sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
    }

    int dist(Punct& A, Punct& B)
    {
        return sqrt((A.x - B.x) * (A.x - B.x) + (A.y - B.y) * (A.y - B.y));
    }

    bool peDreapta(int a, int b)
    {
        if (a * x + b == 0) return true;
        else return false;
    }

};

int main()
{
    //Implicit
    Punct p1;

    //Copiere
    Punct p2(p1);

    //Cu argumente
    Punct p3(2, 3);


    //Apel static: pentru functia dist
    Punct::dist2(p1, p3);

    //Apel ne-static
    p3.dist(p1, p3);

    if (p3.peDreapta(3, 2) == 1)cout << "Punctul 'p3' este pe dreapta." << endl;
    else cout << "Punctul 'p3' NU este pe dreapta." << endl;

    if (p1.peDreapta(0, 0) == 1)cout << "Punctul 'p1' este pe dreapta." << endl;
    else cout << "Punctul 'p1' NU este pe dreapta." << endl;


}
