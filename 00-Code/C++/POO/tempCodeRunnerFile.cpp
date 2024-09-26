#include <iostream>
class Element {
protected:
    int x, y; // pozitia elementului
    int w, h; // dimensiunea elementului
public:
    Element();
    Element(int, int, int, int, int);
    Element(const Element&);
    virtual ~Element();
    virtual void afis();
    virtual double arie();
};
class Buton : public Element {
private:
    char* text; // Textul butonului
public:
    Buton();
    Buton(int, int, int, int, const char*);
    Buton(const Buton&);
    virtual ~Buton();
    virtual void afis();
    virtual double arie();
    char* getText();
};
class Caseta : public Element {
private:
    int lungime; // textul din caseta de text
public:
    Caseta();
    Caseta(int, int, int, int, int);
    Caseta(const Caseta&);
    virtual ~Caseta();
    virtual void afis();
    virtual double arie();
    int getLungime();
};
class Fereastra {
private:
    int count;
    Element* elemente[100];
public:
    Fereastra();
    ~Fereastra();
    Fereastra& addElement(Element*);
    Element* getElement();
    void elements();
    void infoElemente();
};

int main()
{

}