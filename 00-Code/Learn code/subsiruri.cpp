/**
<-
    0  1  2  3  4  5  6  7  8  9  10
  a    5  7  6  8  5  9  7  8 10   7
 L 5  5  4  4  3  4  2  3  2  1   1
  x 1  2  4  4  6  7  9  8  9  0   0
  solutia: 5 7 8 9 10

L[0] = max substring length
x[0] = poz 1st number
*/

#include <iostream>
using namespace std;

void citire(int a[], int& n)
{
    cout << "dimensiune vector: ";
    cin >> n;
    cout << "tastati elementele : ";
    for (int i = 1;i <= n;i++) cin >> a[i];
}

void afisare(int a[], int n)
{
    for (int i = 1;i <= n;i++) cout << a[i] << ' ';
}

int subsir(int a[], int n, int x[])
{
    int* L = new int[n + 1];
    L[n] = 1;
    L[0] = 1;
    x[n] = 0;
    x[0] = n;

    for (int i = n - 1;i >= 1;i--)
    {
        L[i] = 1;
        x[i] = 0;
        for (int j = i + 1;j <= n;j++)
        {
            if (a[i] <= a[j] && L[i] < 1 + L[j])
            {
                L[i] = 1 + L[j];
                x[i] = j;//why does this line even exist??

            }

        }
        if (L[i] > L[0])
        {
            L[0] = L[i];
            x[0] = i;
        }
    }
    int aux = L[0];
    delete L;
    return aux;
}

void solutie(int a[], int n, int x[])
{
    int i = x[0];
    while (i != 0)
    {
        cout << a[i] << ' ';
        i = x[i];
    }
}

int main()
{
    int a[100], n, x[100];
    citire(a, n);
    int lg = subsir(a, n, x);
    for (int i = 0; i <= n; i++)cout << x[i] << " ";
    cout << "lungimea subsirului = " << lg << endl;
    solutie(a, n, x);
    return 0;
}
