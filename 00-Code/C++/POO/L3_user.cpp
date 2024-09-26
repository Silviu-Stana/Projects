#include <iostream>
#include <math.h>
#include <string.h>
using namespace std;

class User
{
private:
char* nume;
char* parola;
int an_nastere;

public:
//Implicit
User()
{
        nume = new char[1];
        nume[0] = '\0';
        parola = new char[1];
        parola[0] = '\0';
        an_nastere = 2000;
}

//Cu argumente
User(const char* name, const char* password, int birth_year)
{
nume=new char[strlen(name)+1];
strcpy(nume, name);

parola = new char[strlen(password)+1];
strcpy(parola, password);

an_nastere=birth_year;
}

~User(){
///cout<<"Obiect dealocat cu succes!";
delete[] nume;
delete[] parola;
}

void afiseaza(){
cout<<"nume: " << nume << endl;
cout<<"parola: " << parola << endl;
}

void verifica_parola(){
bool contineCifra=false;
for(int i=0; i<=strlen(parola); i++) if(isdigit(parola[i])) contineCifra=true;


if(strlen(parola)>8  && contineCifra==true) cout << "SUCCES!  Parola are peste 8 cifre, si contine cel putin 1 cifra."<<endl;
else cout << "Parola nu indeplineste conditiile minime necesare."<<endl;
}


int getAn(){return an_nastere;}

void setAn(int an){
an_nastere=an;
}

int varsta()
{
    return 2024-an_nastere;
}

};


int main()
{
User u1("Vasile", "parola123", 1960);
u1.afiseaza();
u1.verifica_parola();

cout<<"Varsta:" << u1.varsta()<<endl;
cout<<"An nastere:" << u1.getAn()<<endl;

u1.setAn(1961);
}
