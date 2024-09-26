//1. PRODUS CARTEZIAN OARECARE
#include <iostream>
using namespace std;

int k, n,m[100], c[100];

void AFISARE(int c[100], int n)
{
    for(int i=1; i<=n; i++) cout << c[i] << " ";
    cout << endl;
}

void PRODUS_CARTEZIAN(int n, int m[100])
{
    for(int i=1; i<=n; i++)c[i]=1;
    AFISARE(c,n);

    do
    {
        k=n;
        while(c[k]==m[k] && k>0)k--;
        if(k>0)
        {
            c[k]++;
            for(int i=k+1; i<=n; i++)c[i]=1;
            AFISARE(c,n);
        }
    }
    while(k);
}

int main()
{
    cout<<"Nr elemente: "; cin>>n;
    for(int i=1; i<=n; i++)m[i]=i;

    PRODUS_CARTEZIAN(n,m);
    return 0;
}
