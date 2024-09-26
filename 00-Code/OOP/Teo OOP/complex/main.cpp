#include <iostream>

using namespace std;
class Complex
{   public:
    Complex();
    Complex(double, double);
    Complex(const Complex&);
    friend ostream& operator<<(ostream&,const Complex&);
    friend istream& operator>>(istream&, Complex&);
    //supraincarcare operator +, cazul z1+z2
    Complex operator+(const Complex&) const;
    //supraincarcare operator +, cazul z+1
     Complex operator+(double) const;

    //supraincarcam operator =
    Complex& operator=(const Complex&);
    //supraincarcare operatorilor 1+z
    friend Complex operator+(double,const Complex&);
    Complex& operator++();
    //forma prefixata
    Complex& operator++(double);
    //supraincarcare operator ==
    bool operator==(const Complex&);
    //supraincarcam si alti operatori

    private:
        double r, i;


};
Complex::Complex()
{
    r=0;
    i=0;
}
Complex::Complex(double re, double im)
{   r=re;
    i=im;

}
Complex::Complex(const Complex& comp)
{   r=comp.r;
    i=comp.i;
}
ostream& operator<<(ostream& out, const Complex& nr)
{ if(nr.i<0)
    out<<nr.r<<'-'<<nr.i<<"i";
    else
    out<<nr.r<<'+'<<nr.i<<"i";

    return out;

}
istream& operator>>(istream& in,Complex& nr)
{
    in>>nr.r;
    in>>nr.i;

    return in;
}
Complex Complex::operator+(const Complex& z) const
{Complex sum;
sum.r=r+z.r;
sum.i=i+z.i;
 return sum;
}
Complex Complex::operator+(double a) const
{Complex sum;
    sum.r=r+a;
    return sum;
    //sau
    /**
    Complex rezultat (r+a ,i);
    return rezultat;
    */
}

//supraincarcarea operator + cazul 1+z
Complex operator+(double a,const Complex& z)
{double re=z.r+a;
Complex rezultat(re,z.i);
}
int main()
{
  Complex z1,z2;
  cin>>z1>>z2;
  cout<<z1<<z2;
  cout<<6+z1;
    return 0;
}
