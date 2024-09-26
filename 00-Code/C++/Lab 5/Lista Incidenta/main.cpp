#include <iostream>
using namespace std;
int i,m,n, a[100][100]={0};

void CreareMatriceIncidentaNeorientata(int n, int m)
{
    cout<<"Cream o Matrice de Incidenta Neorientata" << endl;
    int x,y;
    for(i=1; i<=m; i++)
    {
        cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        cin>> x >> y;

        a[x][y]=1;
        a[y][x]=1;

        //BUCLA
        if(x==y)a[x][y]=a[y][x]=2;
    }
}

void CreareMatriceIncidentaOrientata(int n, int m)
{
    cout<<"Cream o Matrice de Incidenta Orientata" << endl;
    int x,y;
    for(i=1; i<=m; i++)
    {
        cout<<"Dati muchia " << i << ": " << "Intre nodurile: ";
        cin>> x >> y;

        a[x][y]=1;
        a[y][x]=1;

        //BUCLA orientata: a[y][x] nu va mai fii setat la 2 ca in graful neorientat, bucla are o directie de la x->y
        if(x==y)a[x][y]=2;
    }
}

void AfisareMatrice(int a[100][100])
{
    for(int i=1; i<=n; i++)
    {
    for(int j=1; j<=n; j++) cout << a[i][j] << " ";
        cout << endl;
    }
}

int main()
{
    cout<<"Nr noduri: "; cin>>n;
    cout<<"Nr muchii: "; cin>>m;

    CreareMatriceIncidentaNeorientata(n,m);
    CreareMatriceIncidentaOrientata(n,m);
    AfisareMatrice(a);

}
