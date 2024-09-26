interface Minus{  
    void minus(float value);
}

interface Plus{  
    void plus(float value);
}

interface Mult{  
    void multiply(float value);
}

interface Div{  
    void divide(float value);
}

interface Sqrt{
    void sqrt(float value);
}

abstract class Operation implements Minus, Plus, Mult, Div, Sqrt {
 
    float number;
    
    float getNumber(){return number;}
    
    Operation(float number)
    {
        this.number=number;
    }
    
    @Override
    public void minus(float number){
        this.number -= number;
    }
    
    @Override
    public void plus(float number){
        this.number += number;
    }
    
    @Override
    public void divide(float number){
        if(number != 0)this.number /= number;
        else System.out.println("Division by 0 is not possible");
    }
    
    @Override
    public void multiply(float number){
        this.number *= number;
    }
    
    
    @Override
    public void sqrt(float value){
        this.number = (float) Math.sqrt(value);
    }
    
}

//AVEM NEVOIE DE O CLASA NE-ABSTRACTA ca sa o putem instantia in main()
class Operatie2 extends Operation
{
    Operatie2(float number) {
        super(number);
    }
    
}

public class L12 {
    
    public static void main(String[] args) {
        
        Operatie2 o = new Operatie2(6);
        
        o.plus(1);
        System.out.println(o.getNumber());
        
        
        o.minus(1);
        System.out.println(o.getNumber());
        
        o.multiply(2);
        System.out.println(o.getNumber());
        
        o.divide(0);
    }
}
