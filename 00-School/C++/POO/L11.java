import java.util.Scanner;

class Complex
{
private double r,i;

    public Complex()
    {
        r=0;
        i=0;
    }
    
    public Complex(double r,double i)
    {
        this.r = r;
        this.i = i;
    }
    
    public Complex(Complex c)
    {
        r= c.r;
        i = c.i;
    }
    
    void afis()
    {
        System.out.println("Partea reala: " + r);
        System.out.println("Partea imaginara: " + i);
    }
    
    void read()
    {
        //Obiect scanner
        Scanner myObj = new Scanner(System.in);
        
        
        System.out.println("Introdu partea reala:");
        r = myObj.nextDouble(); //Citeste

        
        System.out.println("Introdu partea imaginara:");
        i = myObj.nextDouble(); //Citeste

    }
    
    Complex adunare(Complex adunat)
    {
        Complex temp = new Complex();
        temp.r = r+adunat.r;
        temp.i = i+adunat.i;
        
        return temp;
    }
    
    void comparatie(Complex nrComparat)
    {
        if(r>nrComparat.r) System.out.println("Partea reala a obiectului CURENT este mai mare");
        else if (r<nrComparat.r) System.out.println("Partea reala a obiectului COMPARAT este mai mare");
        else System.out.println("Partea reala a numerelor este egala.");
        
        
        if(i>nrComparat.i) System.out.println("Partea imaginara a obiectului CURENT este mai mare");
        else if(i<nrComparat.i) System.out.println("Partea imaginara a obiectului COMPARAT este mai mare");
        else System.out.println("Partea imaginara a numerelor este egala.");
    }
    
    void adunaNumar(double numar)
    {
        Complex temp = new Complex();
        
        temp.r= this.r;
        temp.i = this.i;
        
        temp.r += numar;
    }
    
};

public class L11 {
public static void main(String[] args) {

    Complex c1 = new Complex();
    Complex c2 = new Complex();
    Complex cAdunat = new Complex();

    c1.read();
    c2.read();
   
    
    cAdunat = c1.adunare(c2);
    
    c1.adunare(c2);
    c1.comparatie(c2);
    
    c1.adunaNumar(1);
    c2.adunaNumar(2);
    
    cAdunat.afis();
    
    
}
}