
public class ClassInfo 
{
    public int lives;
    public int livesMax;
    public int damage;
    public int mp;
    public int armor;
    public float TimeDelayHP = 0.4f;
    public float TimeDelayMP = 0.01f;
    public float TimeDelayAttack = 0.1f;

    private static ClassInfo _instance;
    public static ClassInfo Instance
        => _instance ??= new ClassInfo();

    public ClassInfo()
    {
        _instance = this;
    }
}
