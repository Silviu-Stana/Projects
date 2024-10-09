#include "MyStringOper.h"
#include <iostream>
#include <string.h>

using namespace std;

void MyStringOper::Init(char* elem){
    _elem=new char [strlen(elem)+1];
    strcpy(_elem,elem);
};

MyStringOper::MyStringOper()
{
    //ctor
    _elem=NULL;
    _size=0;
}

MyStringOper::~MyStringOper()
{
    //dtor
    if(_elem)
    delete[]_elem;
}
MyStringOper::MyStringOper(char* elem){

};

MyStringOper::MyStringOper(const MyStringOper& a)
{
    //copy ctor
    Init(a._elem);
    _size
}

MyStringOper& MyStringOper::operator=(const MyStringOper& rhs)
{
    if (this == &rhs) return *this; // handle self assignment
    //assignment operator
    return *this;
}
