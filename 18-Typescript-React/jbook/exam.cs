class Produs: IComparable<Produs>{
        public int Cod {get;set;}
        public string Nume {get;set;}
        public DateTime DataFabricatiei {get;set;}
        public DateTime DataExpirarii {get;set;}
        public double Pret {get;set;}
        
        public override string ToString(){
                return $"[{Cod} | {Nume} | {DataFabricatiei} | {DataExpirarii} | {Pret}]";
        }
        
        public override bool Equals(object obj){
                if(obj==null) return false;
                
                Produs other = obj as Produs; //daca e null atunci a esuat conversia
                if(other==null)return false;
                
                return Cod==other.Cod&&Nume==other.Name;//....
        }
        
        public int CompareTo(Produs other){
                return Pret.CompareTo(other.Pret);
        }
}


class CosCumparaturi{
        public List<Produs> Produse {get; private set;}
        public Action<string,string> {get; private set;}
        
        public CosCumparaturi(){
                Produse = new List<Produs>();
        }
        
        public void AdaugaProdus(Produs p){
                if(!Produse.Contains(p)){
                        Produse.Add(p);
                }
                else{
                        Logger("Eroare","produsul exista in cos");
                }
        }
        
        public void EliminaProdus(Produs p){
                Produse.Remove(p);
        }
        
        public void GolireCos(){
                Produse.Clear();
        }
        
        public double CalculCostTotal(){
                double total=0;
                Produse.ForEach(p=>total+=p.Pret);
                return total;
        }
        
        public void OrdoneazaDupaPret(){
                Produse.Sort();
            //     Produse = Produse.OrderBy(p=>p.Pret).ToList(); Varianta a 2-a cu LINQ
        }
}


public delegate void Logger(string eventType, string message);

internal class Program{
        static void Main(string[] args){
                CosCumparaturi cos = new CosCumparaturi();
                
                cos.Logger += (eventType, message) => Console.WriteLine($"{DateTime.Now} | {eventType} | {message}");
                cos.Logger += (eventType, message) => System.IO.File.AppendAllText("Log.txt", $"{DateTime.Now} | {eventType} | {message}");
        }
}



private System.Windows.Forms.Button AdaugaProdus;
private System.Windows.Forms.Button CostTotal;

AdaugaProdus.Click += new System.EventHandler(this.AdaugaProdus_Click);
CostTotal.Click += new System.EventHandler(this.CostTotal_Click);

private System.Windows.Forms.Label cod;
private System.Windows.Forms.Label nume;
private System.Windows.Forms.Label pret;
private System.Windows.Forms.DateTimePicker dataExpirarii;
private System.Windows.Forms.DateTimePicker dataFabricatiei;

private void AdaugaProdus_Click(object sender, EventArgs e){
        Produs produsNou = new Produs{
                Cod=int.Parse(cod.Text),
                Pret=double.Parse(pret.Text),
                Nume=nume.Text,
                DataExpirarii=dataExpirarii.Value,
                DataFabricatiei=dataFabricatiei.Value
        }
        
        CosCumparaturi cos = new CosCumparaturi();
        
        cos.AdaugaProdus(produsNou);
}


private void CostTotal_Click(object sender, EventArgs e){
        MessageBox.Show("Total pret: " + cos.CalculCostTotal().ToString());
}