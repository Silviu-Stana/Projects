#include <iostream>

using namespace std;

int v[]={0,1,2};

int j=0;

void fv(int i, int x){

// call by value

    i=i+1;

    cout<<v[i];

    cout<<x;

    cout<<v[j];

}

void fr(int &i, int &x){

// call by reference

    i=i+1;

    cout<<v[i];

    cout<<x;

    cout<<v[j];

}

int main()

{

    fv(j,v[j]);

    cout<<v[j];

    j=0;

    fr(j,v[j]);

    cout<<v[j];

    return 0;

}
