//REPREZENTAREA DINAMICA A LISTEI
#include <iostream>
using namespace std;

struct celula
 {
  int info;
  celula *leg;
 } *L; //folosim reprezentarea cu header

void Initializare(); //doar header-ul functiilor
void InserareInceput(); //functile cu totul sunt dupa main
void InserareInterior();
void InserareSfarsit();
void StergereInceput();
void StergereInterior();
void StergereSfarsit();
void StergeLista();
void Listare();

int main()
 {int o;
  Initializare();
  do {
   cout<<endl<<endl; Listare();
   cout<<"------------------------------"<<endl;
   cout<<"1.Inserare la inceputul listei"<<endl;
   cout<<"2.Inserare in interiorul listei"<<endl;
   cout<<"3.Inserare la sfarsitul listei"<<endl;
   cout<<"4.Stergere la inceputul listei"<<endl;
   cout<<"5.Stergere in interiorul listei"<<endl;
   cout<<"6.Stergere la sfarsitul listei"<<endl;
   cout<<"7.Iesire"<<endl<<endl;
   cout<<"     Optiunea d-stra (1-7): "; cin>>o;
   switch (o)
   {
    case 1:InserareInceput(); break;
    case 2:InserareInterior(); break;
    case 3:InserareSfarsit(); break;
    case 4:StergereInceput(); break;
    case 5:StergereInterior(); break;
    case 6:StergereSfarsit(); break;
    case 7:StergeLista(); break;
    default: cout<<" Eroare !"; StergeLista();
   };
  } while ((o>=1)&&(o<=6)); //optiunea data anterior a fost valida
 return 0;
}

void Initializare()
 {
  L = new celula;
  L->leg = NULL;
 }
void InserareInceput()
 {
  int a;
  celula *temp = new celula;
  cout<<"Elementul de inserat: "; cin>>a;
  temp->info = a;
  temp->leg = L->leg;
  L->leg = temp;
 }
void InserareInterior()
 {int a,m;
  celula *temp = new celula, *p = L;
  cout<<"Dupa al catelea element inserez: "; cin>>m;
  cout<<"Elementul de inserat: "; cin>>a;
  temp->info=a;
  for (int i = 1; i <= m && p->leg != NULL; i++) p = p->leg;
  temp->leg = p->leg;
  p->leg = temp;
 }
void InserareSfarsit()
 {
  int a;
  celula *temp = new celula, *p = L;
  while (p->leg != NULL) p = p->leg; //p=ultima pozitie
  cout<<"Elementul de inserat : ";cin>>a;
  temp->info = a;
  temp->leg = NULL;
  p->leg = temp;
 }
void StergereInceput()
 {if (L->leg != NULL)
   {
    celula *temp = L->leg;
    cout<<"Se va sterge elementul "<<temp->info<<endl;
    L->leg = temp->leg;
    delete temp;
   }
  else cout<<"Nu sunt elemente de sters";
}
void StergereInterior()
 {
  if (L->leg != NULL)
   {
    celula *temp = L->leg, *p = L;
    int m;
    cout<<"Al catelea element din lista se sterge: "; cin>>m;
    for (int i=1; i<m && p->leg!=NULL; i++) p=p->leg;
    temp = p->leg;
    if (temp==NULL) cout<<"Nu exista elementul "<<m;
    else
     {
      p->leg = temp->leg;
      cout<<"Se va sterge elementul "<<temp->info<<endl;
      delete temp;
     }
   }
  else cout<<"Nu sunt elemente de sters";
 }
void StergereSfarsit()
 {
  celula * p=L, *temp;
  if (L->leg!=NULL)
   {
    while (p->leg->leg!=NULL) p=p->leg;
    temp = p->leg;
    cout<<"Se va sterge elementul "<<temp->info<<endl;
    p->leg=NULL;
    delete temp;
   }
  else cout<<"Nu sunt elemente de sters";
 }
void Listare()
 {
  if (L->leg==NULL) cout<<"Lista vida";
  else
   {
    celula *p=L->leg; //prima celula efectiva
    cout<<"Elementele listei : ";
    while (p!=NULL)
      {
       cout<<p->info<<"  ";
       p=p->leg;
      }
   }
 cout<<endl;
 }
void StergeLista()
 {
  celula *temp; //de la header spre ultimul element
  while (L!=NULL)
   {
    temp = L;
    L=L->leg;
    delete temp;
   }
 }
