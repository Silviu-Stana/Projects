class Produs: IComparable<Produs> {
        public int Cod {get; set;}
        public string Name {get; set;}
        public DateTime FabricationDate {get; set;}
        public DateTime ExpireDate {get;set;}
        public double Price {get; set;}
        
        public override string ToString(){
                return $"[{Cod} | {Name} | {FabricationDate} | {ExpireDate} | {Price}]";
        }
        
        public override bool Equals(object obj){
                if(obj==null)return false;
                
                Produs other = obj as Produs; //attempt conversion, null if it fails
                if(other==null)return false;
                
                return Cod==other.Cod&&Name==other.name&&FabricationDate==other.FabricationDate&&ExpireDate==other.ExpireDate&&Price==other.Price;
        }
        
        public int CompareTo(Produs other){
                return Price.CompareTo(other.Price);
        }
}


class CosCumparaturi{
        public List<Produs> Produse {get; private set;}
        public Action<string,string> Logger {get; set;}
        
        public CosCumparaturi(){
                Produse = new List<Produs>();
        }
        
        public void AddProdus(Produs p){
                if(!Produse.Contains(p)){
                        Produse.Add(p);
                }
                else{
                       Logger("Eroare","produsul exista in cos");
                }
        }
        
        public void EliminareProdus(Produs p){
                Produse.Remove(p);
        }
        
        public void GolireCos(){
                Produse.Clear();
        }
        
        public void CalculCostTotal(){
                double total=0;
                Produse.ForEach(p=>total+=p.Price);
                return total;
        }
        
        public void OrderByPret(){
                Produse.Sort();
                //Produse = Produse.OrderBy(p=>p.Price).ToList();   //varianta LINQ
        }
}


public delegate void Logger(string eventType, string message);

internal class Program{
        static void Main(string[] args){
                public CosCumparaturi cos = new CosCumparaturi();
                
                cos.Logger += (eventType, message) => Console.WriteLine($"{DateTime.Now} | {eventType} | {message}");
                cos.Logger += (eventType, message) => System.IO.File.AppendAllText("Logs.txt",$"{DateTime.Now} | {eventType} | {message}");
                
                Produs p = new Produs{
                        Cod = 1,
                        Name = "Produs Random",
                        FabricationDate = DateTime.Now.AddMonths(-1),
                        ExpireDate = DateTime.Now.AddMonths(11),
                        Price = 99.99
                };
                
                cod.AddProdus(p);
                cod.AddProdus(p);//aici apare eroare la Logger, deoarece am adaugat deja acel produs in cos
                
                Console.ReadKey();
        }
}


private System.Windows.Forms.Button AdaugaProdus;
private System.Windows.Forms.Button CostTotal;

private System.Windows.Forms.Label cod;
private System.Windows.Forms.Label price;
private System.Windows.Forms.Label name;
private System.Windows.Forms.DateTimePicker dataFabricatiei;
private System.Windows.Forms.DateTimePicker dataExpirarii;

AdaugaProdus.Click += new System.EventHandler(AdaugaProdus_Click);
CostTotal.Click += new System.EventHandler(CostTotal_Click);


Produs produsNou;

private void AdaugaProdus_Click(object sender, EventArgs e){
        produsNou = new Produs{
                Cod=int.Parse(cod.Text),
                Name=name.Text,
                FabricationDate=dataFabricatiei, //dataFabricatiei is from a DateTimePicker component, deci este deja in formatul corespunzator de DateTime, nu mai are nevoie de conversie
                ExpireDate=dataExpirarii,
                Price=double.Parse(price.Text)
        }
        
        CosCumparaturi cos = new CosCumparaturi();
        cos.AddProdus(produsNou);
}

private void CostTotal_Click(object sender, EventArgs e){
        MessageBox.Show("Total comanda: " + cos.CalculCostTotal().ToString());
}