#include <iostream>
using namespace std;

int main()
{
    int i,j,n,k,a[50][50]={0}, suma[50]={0};

    k=n=7; //Luam valoarea 7 pentru ca este data in tabel.

    a[0][0]=1;

    for(i=1;i<=n;i++)
    {
        for(j=1;j<=i;j++) //j merge doar pana la i
        {
            a[i][j]=a[i-1][j-1] + a[i-j][j];
            suma[i] += a[i][j]; //aici calculam suma: P(n)
        }
    }

    //Afisam matricea P(n,k);
    for(i=1;i<=n;i++)
    {
        cout<<"n=" << i << "  ";
        for(j=0;j<=k;j++)
        {
        cout << a[i][j] << " ";
        }
    cout<<endl;
    }


    //Afisam suma P(n)
    for(i=1;i<=n;i++)
    {
        cout<<"Suma P(n,k) unde n=" << i << " este: " << suma[i] << endl;
    }


}
