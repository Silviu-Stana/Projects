//3. Generare partitii lui n cu k termeni
#include <iostream>
using namespace std;
int t[100],n,m,k,j,r;
void AFISARE(int t[100], int m)
{
    for(int i=1; i<=m; i++) cout<<t[i]<<" ";
    cout<<endl;
}

void GENERARE_PARTITII(int n, int k)
{
    for (int i=1; i<=k-1; i++)t[i]=1;
    t[k]=n-k+1;
    AFISARE(t,k);

    do
    {
        j=k-1;
        while(t[j]>t[k]-2 && j>0)j--;

        if(j>0)
        {
            t[j]++;
            for(int i=j+1; i<=k-1; i++)t[i]=t[j];
            r=0;
            for(int i=1; i<=k-1; i++)r=r+t[i];
            t[k]=n-r;
            AFISARE(t,k);
        }
    }
    while(j>0);
}

int main()
{
    cout<<"Genereaza partitii de n: "; cin>>n;
    cout<<"Cu k termeni: "; cin>>k;
    GENERARE_PARTITII(n,k);
    return 0;
}
