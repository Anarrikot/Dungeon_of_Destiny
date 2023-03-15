using System.Collections;
using UnityEngine;

public class ManadgerController : MonoBehaviour
{
    private string bundleURL = "";
    private int version = 0;

    [SerializeField] SpriteRenderer sRenderer;

    public void Start()
    {
        StartCoroutine(DownloadAndCache());
    }

    IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;

        var www = WWW.LoadFromCacheOrDownload(bundleURL, version);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        Debug.Log("Бандл загружен!");
        var assetBundle = www.assetBundle;
        string spriteName = "Head";

        var spriteRequest = assetBundle.LoadAssetAsync(spriteName, typeof(Sprite));
        yield return spriteName;
        Debug.Log("Изображение распаковано!");

        sRenderer.sprite = spriteRequest.asset as Sprite;
    }
}