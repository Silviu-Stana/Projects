#include <iostream>
using namespace std;

struct celula
{
    int info;
    celula* next;
}*L;

void Creare(celula*& L)
{
    int n;
    cout << "Nr elemente in lista initiala: ";
    cin >> n;
    if (n > 0) {
        L = new celula;
        cout << "Adauga elementele: ";
        cin >> L->info;
        L->next = NULL;

        celula* ultim = L;
        for (int i = 2; i <= n; i++) {
            celula* temp = new celula;

            cin >> temp->info;
            temp->next = NULL;
            ultim->next = temp;
            ultim = temp;
        }
    }
    else {
        L = NULL;
    }
}


void InserareDinamica(celula*& L) {
    int a;
    cout << "Adauga un nr in lista: "; cin >> a;

    celula* nou = new celula;
    nou->info = a;
    nou->next = NULL; // Noua celula va fi ultima din lista

    if (L == NULL || a < L->info) { // Daca lista este goala sau "a" este mai mic decat primul element, atunci noul nod devine primul element al listei
        nou->next = L;
        L = nou;
        return;
    }

    celula* curent = L;
    // Avansam in lista pana cand gasim un nr mai mare decat "a"
    while (curent->next != NULL && curent->next->info < a) curent = curent->next;


    // Inseram noul nod intre "curent" si "curent->next"
    nou->next = curent->next;
    curent->next = nou;
}



void Afisare(celula* L)
{
    cout << "Elementele listei: ";
    celula* p = L;
    do {
        cout << p->info << " ";///afisam celula curenta
        p = p->next;//avansam
    } while (p != NULL); cout << endl;//cat timp nu am revenit la L
}


int main()
{
    Creare(L);
    while (1) {
        InserareDinamica(L);
        Afisare(L);
    }
    return 0;
}
