using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiScript : MonoBehaviour
{
    public Text bulletCounter;
    public int numBullets = 5;
    public static GuiScript instance;

    public bool hasAmmo;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("numBullets"))
        {
            numBullets = PlayerPrefs.GetInt("numBullets");
        }
        bulletCounter.text = "Bullets: " + numBullets.ToString();
    }

    public void SaveBullets(){
        if(numBullets!=0){
            PlayerPrefs.SetInt("numBullets",numBullets);
            PlayerPrefs.Save();
        } else {
            PlayerPrefs.SetInt("numBullets",5);
            PlayerPrefs.Save();
        }
    }

    public void AddBullets()
    {
        numBullets += 10;
        bulletCounter.text = "Bullets: " + numBullets.ToString();
        SaveBullets();
    }

    public void TakeBullets()
    {
        // numBullets = Math.Max(numBullets - 10, 0);
        numBullets -= 10;
        if (numBullets < 0)
        {
            numBullets = 0;
        }
        bulletCounter.text = "Bullets: " + numBullets.ToString();
        SaveBullets();
    }

    public void UseBullets()
    {
        if (numBullets >= 1)
        {
            numBullets -= 1;
            bulletCounter.text = "Bullets: " + numBullets.ToString();
        }
        SaveBullets();
    }

    public void HasBullets()
    {
        if (numBullets == 0)
        {
            bulletCounter.text = "NO AMMO";
        }
    }
}
