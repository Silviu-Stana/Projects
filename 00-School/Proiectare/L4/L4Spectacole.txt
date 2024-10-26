import java.util.Scanner;

class L4Spectacole {
    
    
public static void SORTARE(double a[], double b[], int n) {
    for (int i = 1; i <= n - 1; i++) {
        for (int j = i + 1; j <= n; j++) {
            if (b[i] > b[j]) {
                double aux = a[i];
                a[i] = a[j];
                a[j] = aux;

                aux = b[i];
                b[i] = b[j];
                b[j] = aux;
            }
        }
    }
}
    
    public static void CITIRE(double a[], double b[], int n)
    {
        Scanner cin = new Scanner(System.in);
        System.out.println(n + " Timpuri de Incepere:");
        for(int i=1; i<=n; i++)a[i]=cin.nextDouble();
        
        System.out.println(n + " Timpuri de Incheiere:");
        for(int i=1; i<=n; i++)b[i]=cin.nextDouble();
        cin.close();
    }
    
    public static void AFISARE(double a[], double b[], int n)
    {
                System.out.println("Lista Sortata: Timpuri Incepere:");
        for(int i=1; i<=n; i++)System.out.print(a[i] + " ");
        System.out.println("");
                   System.out.println("Lista Sortata: Timpuri Incheiere:");
        for(int i=1; i<=n; i++)System.out.print(b[i] + " "); 
    }
    
     public static void SPECTACOLE(double a[], double b[], double c[], int n, int m)
        {
                m=0;
                for(int i=1; i<=n; i++) c[i]=0;
                double t=a[1]-1;
                
                for(int i=1; i<=n; i++){
                        if(a[i]>t)
                        {
                                c[i]=1;
                                m++;
                                t=b[i];
                        }
                }
                
            System.out.println("Nr. spectacole vizionate: " + m);
            System.out.println("Lista vizionarii:");
            for(int i=1; i<=n; i++) if(c[i]==1) System.out.println("Incepe la: " + a[i] + " si se termina la: " + b[i]);
        }
    
    
    public static void main(String[] args) {
                double a[], b[], c[]; int n, m=0;
        
        Scanner cin = new Scanner(System.in);
        System.out.println("");
        System.out.print(" Nr spectacole=");
        n = cin.nextInt();
        
        a= new double[n+1];
        b= new double[n+1];
        c= new double[n+1];
        
        
        CITIRE(a,b,n);
        SORTARE(a,b,n);
        //AFISARE(a, b, n);
        SPECTACOLE(a,b,c,n,m);
        cin.close();
    }
}
/*
N=14
Timp Incepere:
8 8.1 8.15 8.50 9.10 9.20 9.20 10.45 11 12 12.1 12.3 13 13.4
Timp Incheiere:
9.1 9 9 10.2 10.4 10.3 11 12 12.3 13.3 14 13.5 14.3 15
*/

