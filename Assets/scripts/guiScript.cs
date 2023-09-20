using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterScript : MonoBehaviour
{
    public Text bulletCounter;
    int numBullets = 5;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletCounter.text = "Bullets: " + numBullets.ToString();
    }

    public void AddBullets()
    {
        numBullets += 10;
        bulletCounter.text = "Bullets: " + numBullets.ToString();
    }
}
