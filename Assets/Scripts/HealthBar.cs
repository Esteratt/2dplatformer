using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthScript hs;
    public Image totalhpbar;
    public Image currenthpbar;
    private float hearts = 10;
    void Start()
    {
        totalhpbar.fillAmount = hs.currenthp / hearts;
    }

    void Update()
    {
        currenthpbar.fillAmount = hs.currenthp / hearts;
    }
}
