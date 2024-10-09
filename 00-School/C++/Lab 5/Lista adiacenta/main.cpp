#include <iostream>
using namespace std;
int i,m,n, a[100][100]={0};

void CreareMatriceAdiacenta(int n, int m)
{
    int x,y;
    for(i=1; i<=m; i++)
    {
        cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        cin>> x >> y;
        a[x][y]++;
        a[y][x]++;
    }
}

void AfisareLista(int a[100][100])
{
    for(int i=1; i<=n; i++)
    {
        cout<<"Nodul " << i <<"este adiacent cu nodul: ";
    for(int j=1; j<=n; j++) if(a[i][j]>0) cout << j << " ";
        cout << endl;
    }
}

int main()
{
    cout<<"Nr noduri: "; cin>>n;
    cout<<"Nr muchii: "; cin>>m;

    CreareMatriceAdiacenta(n,m);
    AfisareLista(a);
}
