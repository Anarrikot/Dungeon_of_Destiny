using UnityEngine;

public class GameController
{
    private static GameController _instance;
    public static GameController Instance
        => _instance ??= new GameController();

    public GameController()
    {
        _instance = this;
    }
}
