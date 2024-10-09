#include <iostream>
using namespace std;

class Database
{
private:
    string nume;
    string prenume;
    int varsta;

public:
    string GetName(){return nume;}
    void SetName(string name)
    {
        nume = name;
        cout<<name<<" ";
    }

    void SetName(string name, string firstName)
    {
        nume=name;
        prenume=firstName;
        cout<<name << " " << firstName;
    }
    void SetName(string name, string firstName, int age)
    {
        nume=name;
        prenume=firstName;
        varsta=age;
    }
};

int main()
{
    Database d;

    d.SetName("Stana");
    d.SetName("Stana","Silviu");
    //d.SetName('Stana','Silviu',23);


    return 0;
}
