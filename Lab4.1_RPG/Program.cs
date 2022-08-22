List<GameCharacter> characters = new List<GameCharacter>
{
    new Warrior("Tnarg the Barbarian",16, 9, "Axe"),
    new Warrior("Kincaid the Fighter", 15, 16, "Longsword"),
    new Wizard("Lady Witherell the Wizard", 11, 18, 5, 10),
    new Wizard("Polgara the Hawk", 12, 17, 4, 9),
    new Wizard("Belgarath the Wolf", 500000, 5000000, 1000000000, 9000000)
};

foreach (GameCharacter character in characters)
{
    character.Play();
}
class GameCharacter
{
    public string Name;
    public int Strength;
    public int Intelligence;

    public GameCharacter(string name, int strength, int intelligence)
    {
        Name = name;
        Strength = strength;
        Intelligence = intelligence;
    }

    public virtual void Play()
    {
        Console.WriteLine($"{Name} (int {Intelligence}, strength {Strength})");
    }
}

class MagicUsingCharacter : GameCharacter
{
    public int magicalEnergy;

    public MagicUsingCharacter(string magicname, int magicstrength, int magicintelligence, int magicalenergy) : base(magicname, magicstrength, magicintelligence)
    {
        magicalEnergy = magicalenergy;
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} (int {Intelligence}, strength {Strength}, magic {magicalEnergy})");
    }
}

class Warrior : GameCharacter
{
    public string weaponType;

    public Warrior(string warriorname, int warriorstrength, int warriorintelligence, string warriorweapontype) : base(warriorname, warriorstrength, warriorintelligence)
    {
        weaponType = warriorweapontype;
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} (int {Intelligence}, strength {Strength}) {weaponType}");
    }
}

class Wizard : MagicUsingCharacter
{
    public int spellNumber;

    public Wizard(string wizname, int wizstrength, int wizintelligence, int wizspellnumber, int wizmagicalenergy) : base(wizname, wizstrength, wizintelligence, wizmagicalenergy)
    {
        spellNumber = wizspellnumber;
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} (int {Intelligence}, strength {Strength}, magic {magicalEnergy}) {spellNumber} spells");
    }
}