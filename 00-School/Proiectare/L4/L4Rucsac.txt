import java.util.Scanner;

class L4Rucsac {
    
    
public static void SORTARE(double g[], double c[], int n) {
    for (int i = 1; i <= n - 1; i++) { 
        for (int j = i + 1; j <= n; j++) {
            if (c[i] / g[i] < c[j] / g[j]) {
                double aux = g[i];
                g[i] = g[j];
                g[j] = aux;

                aux = c[i];
                c[i] = c[j];
                c[j] = aux;
            }
        }
    }
}
    
    public static void CITIRE(double g[], double c[], int n)
    {
        Scanner cin = new Scanner(System.in);
        System.out.println("Citire " + n + 
        " Greutati:");
        for(int i=1; i<=n; i++)g[i]=cin.nextDouble();
        
        System.out.println("Citire " + n + 
        " Costuri:");
        for(int i=1; i<=n; i++)c[i]=cin.nextDouble();
    }
    
    public static void AFISARE(double g[], double c[], int n)
    {
                System.out.println("c[]");
        for(int i=1; i<=n; i++)System.out.print(c[i] + " ");
        System.out.println("");
                   System.out.println("g[]");
        for(int i=1; i<=n; i++)System.out.print(g[i] + " "); 
    }
    
     public static void RUCSAC(double G, double g[], double C, double c[], 
     int n, double x[])
        {
            C=0;
            for(int i=1; i<=n; i++)x[i]=0;
            double R=G;
            int i=1;
            
            while(R>0)
            {
                if(g[i]<=R)
                {
                    x[i]=1;
                    C=C+c[i];
                    R=R-g[i];
                    i++;
                }
                else{
                    x[i]=R/g[i];
                    C=C+x[i]*c[i];
                    R=0;
                }
            }
            
            System.out.println("Ordine optima:");
            for(i=1; i<=n; i++) System.out.print(x[i] + " ");
        }
    
    
    public static void main(String[] args) {
                double g[], c[], x[], C=0, G=40; int n;
        
        Scanner cin = new Scanner(System.in);
        System.out.print("n=");
        n = cin.nextInt();
        
        System.out.print("G:");
        G = cin.nextDouble(); //40
        
        g= new double[n+1];
        c= new double[n+1];
        x= new double[n+1];
        
        CITIRE(g,c,n);
        SORTARE(g,c,n);
        //AFISARE(g, c, n);
        RUCSAC(G,g,C,c,n,x);
    }
}

/* REZULTAT:
n=10
G:40
Citire 10 Greutati:
10 7 10 5 6 10 8 15 3 12
Citire 10 Costuri:
27 9 40 20 11 20 50 22 4 33
Ordine optima:
1.0 1.0 1.0 1.0 0.5 0.0 0.0 0.0 0.0 0.0 
*/

