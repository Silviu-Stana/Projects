#include <iostream>
#include <string.h>

using namespace std;

/*
Colectii eterogene: Sunt colectii care pot stoca tipuri diferite de obiecte/clase, toate derivate dintr-o clasa comuna.

Posibil prin functiile virtuale si polimorfism

De exemplu, sa implementam o clasa GraphicTool pentru colectie de obiecte de tip Shape
*/
class Point2D
{
private:
        int _x;
        int _y;

public:
        Point2D(int x = 0, int y = 0) :_x(x), _y(y)
        {
        }

        int X() { return _x; }
        int Y() { return _x; }

        friend ostream& operator<<(ostream& out, const Point2D p)
        {
                out << "(" << p._x << "," << p._y << ")";
                return out;
        }
};

class Shape
{
public:

        Shape(const char*, const Point2D&);
        Shape(const Shape&);

        virtual void Draw() = 0; //virtuala pura (clasa devine clasa abstracta, neinstantiabila
        virtual ~Shape();
protected:
        char* _name;
        Point2D _origin;
};

Shape::Shape(const char* name, const Point2D& p)
{
        _name = new char[strlen(name) + 1];
        strcpy(_name, name);

        _origin = p;
}

Shape::Shape(const Shape& s)
{
        _name = new char[strlen(s._name) + 1];
        strcpy(_name, s._name);

        _origin = s._origin;
}

Shape::~Shape()
{
        delete[] _name;
}

class Line : public Shape
{
private:
        Point2D _point;

public:
        Line(const char* name, const Point2D& p1, const Point2D& p2) : Shape(name, p1), _point(p2) {}

        Line(const Line& l) :Shape(l), _point(l._point) {}
        void Draw() { cout << "se deseneaza linia " << _name << " in punctele " << _origin << " si " << _point << endl; }
};

class Triangle : public Shape
{
private:
        Point2D _point1;
        Point2D _point2;

public:
        Triangle(const char* name, const Point2D& p1, const Point2D& p2, const Point2D& p3) : Shape(name, p1), _point1(p2), _point2(p3) {}
        Triangle(const Triangle& t) :Shape(t), _point1(t._point1), _point2(t._point2) {}

        void Draw() { cout << "se deseneaza triunghiul " << _name << " in punctele " << _origin << " si " << _point1 << " si " << _point2 << endl; }
};

//metoda cu caracter general
void ProcessShape(Shape* s)
{
        s->Draw();
        delete s;
}

//colectie de obiecte de tip Shape!!
//colectie eterogena (caracter general - clasa functionala pentru orice obiect derivat din Shape!!
class GraphicTool
{
public:
        GraphicTool() { _count = 0; }

        ~GraphicTool();

        void DrawAll();

        void Add(Shape*);
        Shape* Remove(); //scoatere de la final!!
private:
        Shape* _shapes[1000];
        int _count;
};

GraphicTool::~GraphicTool()
{
        for (int i = 0; i < _count; i++) delete _shapes[i];
}

void GraphicTool::DrawAll()
{
        for (int i = 0; i < _count; i++) _shapes[i]->Draw();
}

void GraphicTool::Add(Shape* newShape)
{
        if (_count == 1000)
        {
                delete _shapes[0];
                for (int i = 1; i < _count; i++) _shapes[i - 1] = _shapes[i];
        }

        _shapes[_count++] = newShape;
}

Shape* GraphicTool::Remove()
{
        if (_count == 0) return 0;

        return _shapes[--_count];
}


//tema: Circle, Rectangle, Square

int main()
{
        //ProcessShape(new Line("line1", Point2D(3,5), Point2D(7,10)));
        //ProcessShape(new Triangle("triangle1", Point2D(10,25), Point2D(20,75), Point2D(40,55)));

        GraphicTool g;

        g.Add(new Line("line1", Point2D(3, 5), Point2D(7, 10)));
        g.Add(new Triangle("triangle1", Point2D(10, 25), Point2D(20, 75), Point2D(40, 55)));
        g.Add(new Line("line2", Point2D(13, 15), Point2D(27, 20)));

        g.DrawAll();

        Shape* removedShape = g.Remove();
        cout << "s-a eliminat figura: " << endl;
        removedShape->Draw();
        delete removedShape;

        g.DrawAll();

        return 0;
}
