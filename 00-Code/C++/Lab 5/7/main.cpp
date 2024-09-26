#include <iostream>
using namespace std;

int k, m, n, p[100], a[100];

void AFISARE(int a[100], int p[100], int n)
{
    for(int i=1; i<=n; i++) cout << a[p[i]] << " ";
    cout << endl;
}

void PERMUTARI(int n)
{
    for(int i=1; i<=n; i++) p[i]=1;
    AFISARE(a,p,n);

    do
    {
        k=n;
        while(p[k]==n)k--;

        if(k>0)
        {
            p[k]++;
            // Restul cifrelor sunt setate la prima cifră
            for(int j = k + 1; j <= n; j++)p[j] = 1;
            AFISARE(a,p,n);
        }
    }
    while(k);
}

int main()
{
    cout<<"Permutari de cate cifre: "; cin>>n;
    cout<<"Care sunt numerele: "; for(int i=1;i<=n;i++)cin>>a[i];


    PERMUTARI(n);
    return 0;
}
