using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    Camera cam;
    [SerializeField] public Color backgroundColor;
    [SerializeField] public Color hitColor;
    [SerializeField] public Color poisonColor;
    [SerializeField] public Color defaultColor;

    public static GameController instance;

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public PlayerMain player;

    public int money;
    public int experience;

    private void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += LoadState;

        cam = GameObject.Find("Camera").GetComponent<Camera>();

        cam.backgroundColor = backgroundColor;
    }

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += money.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        money = int.Parse(data[1]);
        experience = int.Parse(data[2]);
    }
}
