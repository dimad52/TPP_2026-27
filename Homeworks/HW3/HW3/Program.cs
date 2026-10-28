class Character
{
    static int count;
    string name;
    int hp;
    int power;
    public Character(string name, int hp, int power) {this.name = name; this.hp = hp; this.power = power; count++;}
    virtual public void Attack(Character target){
        target.TakeDamage(this.Power);
        Console.WriteLine($"Был нанесен удар: {power}");
        target.GetStatus();
    }
    public void TakeDamage(int damage){
        this.hp -= damage;
    }
    public void GetStatus(){
        Console.WriteLine($"Имя персонажа: {Name}");
        Console.WriteLine($"Хп персонажа: {Hp}");
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
        Console.WriteLine("Hello, World!");
    }
}