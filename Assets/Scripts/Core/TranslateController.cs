using UnityEngine;
public class TranslateController 
{

    private static TranslateController _instance;
    public static TranslateController Instance
        => _instance ??= new TranslateController();

    public TranslateController()
    {
        _instance = this;
    }
}
