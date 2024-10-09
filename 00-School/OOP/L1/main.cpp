#include <iostream>
#include <cstring>
using namespace std;

class Element {
protected:
    int x, y; // pozitia elementului
    int w, h; // dimensiunea elementului
public:
    Element(): x(0), y(0), w(0), h(0){};
    Element(int x, int y, int w, int h, int): x(x), y(y), w(w), h(h){};
    Element(const Element& ele)
    {
        x=ele.x; y=ele.y; h=ele.h; w=ele.w;
    };

    virtual ~Element(){};
    virtual void afis()
    {
        cout<<endl;
    cout<<"Pozitia Elementului este: (" <<  x << "," << y << ")"<<endl;
        cout<<"Inaltimea Elementului: " << h <<endl;
        cout<<"Grosimea Elementului: " << w <<endl;
    }

    virtual double arie(){}
};
class Buton : public Element {
private:
    char* text; // Textul butonului
public:
    Buton(){text=NULL;};
    Buton(int x, int y, int w, int h, const char* txt)
    {
        this->x=x;
        this->y=y;
        this->w=w;
        this->h=h;
        if(txt != NULL)
        {
            text = new char[strlen(txt) + 1];
            strcpy(text, txt);
        }
    };

    Buton(const Buton& b): Element(b)
    {
        if(b.text != NULL)
        {
            text = new char[strlen(b.text) + 1];
            strcpy(text, b.text);
        }
    }


    virtual ~Buton() {
        delete[] text;
    }

    virtual void afis(){
    cout<<endl<<endl<<text;
    Element::afis();
    }

    virtual double arie()
    {
    double arie = this->w * this->h;
    return arie;
    }

    char* getText(){return text;}
};
class Caseta : public Element {
private:
    int lungime; // textul din caseta de text
public:
    Caseta(): lungime(0) {};

    Caseta(int x, int y, int w, int h, int l) : Element(x, y, w, h, l)
    {
        lungime=l;
    };

    Caseta(const Caseta& h)
    {
        x= h.x;
        y=h.y;
        w=h.w;
        this->h=h.h;
        lungime=h.lungime;
    };

    virtual ~Caseta(){};

    virtual void afis() override
    {
    Element::afis();
    cout<<"Lungimea Casetei: " << lungime;
    }

    virtual double arie() override {return 2*(lungime*w + w*h + lungime*h);}
    int getLungime(){return lungime;}
};
class Fereastra {
private:
    int count;
    Element* elemente[100];
public:
    Fereastra(): count(0)
    {
        for(int i=0; i<100; i++)elemente[i]=NULL;
    };

    ~Fereastra()
    {
        delete[] elemente;
    }


    //Adauga element
    Fereastra& addElement(Element* e)
    {
        elemente[count] = e;
        count++;
        return *this;
    }

    //Elimina, dar doar de la final
    Fereastra& removeElement(Element* e)
    {
        elemente[count] = NULL;
        count--;
        return *this;
    }


    //Returneaza elementul la pozitia ceruta (din cele 100)
    Element* getElement(int elementIndex)
    {
        return elemente[elementIndex];
    }


    void infoElemente()
    {
        for(int i=0; i< count; i++) elemente[i]->afis();
    }
};

int main()
{
 Caseta c(0,0,20,20,200);
 c.afis();

Buton b(0,0,15,15,"Wow Button Text!");
b.afis();

}
