abstract class Character
{
    static int count;
    string name;
    int hp;
    int power;
    public Character(string name, int hp, int power) {this.name = name; this.hp = hp; this.power = power; count++;}
    abstract public void Attack(Character target);
    public void TakeDamage(int damage){
        this.hp -= damage;
    }
    public bool IsAlive() {
        if (Hp > 0) return true;
        else return false;
    }
    public static int HowMany() {return count;}
    public static bool IsvalidStats(int hp, int power){
        if (hp > 0 && power > 0) return true;
        else return false;
    }
    public string Name{
        get{return name;}
        set {name = value;}
    }
    public int Hp {
        get {return hp;}
        set {if (value > 0) {hp = value;}}
    }
    public int Power {
        get {return power;}
        set {if (value > 0) {power = value;}}
    }
    public override string ToString() {return $"{Name} (HP: {Hp})";}
    public override bool Equals(Character obj) {
        return this.Name == obj.Name;
    }

}
class Player : Character{
    public Player(string name, int hp, int power) : base(name, hp, power) {}
    public override void Attack(Character target)
    {
        target.TakeDamage(this.Power);
        Console.WriteLine($"Вы нанесли удар с силой {Power}");
    }
}
class Enemy : Character{
    public Enemy(string name, int hp, int power) : base(name, hp, power) {}
    public override void Attack(Character target)
    {
        target.TakeDamage(this.Power);
        Console.WriteLine($"Противник нанес удар с силой {Power}");
    }
}
class Program
{
    private static void Main()
    {
        Character me = new Player("Dima", 100, 5);
        Character enemy = new Enemy("Vrag", 100, 5);
        Console.WriteLine(me.ToString());
        Character[] charac = {me, enemy};
        for (int i = 0; i < 2; i++) {charac[i].TakeDamage(10);}
    }
}