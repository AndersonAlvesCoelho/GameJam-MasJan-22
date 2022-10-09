using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public TextMeshProUGUI textMesBlood;

    public TextMeshProUGUI textMesLevel;

    public float ammunition;

    public float blood;

    public float level;

    public float ammunitionMax = 10;

    public float bloodMax = 50;

    public float levelMax = 100;

    public Image bloodBar;

    public Image levelBar;

    public Image ammunitionBar;

    public float BloodProgress
    {
        get
        {
            return blood;
        }
        set
        {
            blood = Mathf.Clamp(value, 0, bloodMax);
        }
    }

    public float LevelProgress
    {
        get
        {
            return level;
        }
        set
        {
            level = Mathf.Clamp(value, 0, levelMax);
        }
    }

    public float AmmunitionProgress
    {
        get
        {
            return ammunition;
        }
        set
        {
            ammunition = Mathf.Clamp(value, 0, ammunitionMax);
        }
    }

    // ---------------- FUNCTION --------------
    void Start()
    {
        if (bloodBar != null)
        {
            BloodProgress = 100;
            bloodBar.fillAmount = BloodProgress / bloodMax;
            textMesBlood.text = "100%";

            LevelProgress = 0;
            levelBar.fillAmount = LevelProgress / levelMax;
            textMesLevel.text = "0%";

            AmmunitionProgress = 10;
            ammunitionBar.fillAmount = AmmunitionProgress / ammunitionMax;
        }
    }

    public void Update()
    {
    }

    // TOMANDO DANO
    public void BloodLoss(float value)
    {
        BloodProgress -= value;
        int auxInt = (int)((BloodProgress / bloodMax) * 100);
        bloodBar.fillAmount = BloodProgress / bloodMax;
        textMesBlood.text = auxInt.ToString() + "%";
    }

    // GANHANDO VIDA
    public void HealController(float value)
    {
        BloodProgress += value;
        int auxInt = (int)((BloodProgress / bloodMax) * 100);
        bloodBar.fillAmount = BloodProgress / bloodMax;
        textMesBlood.text = auxInt.ToString() + "%";
    }

    // VISUALIZANDO PROGRESSO DA FASE
    public void LevelController(float value)
    {
        int auxInt = (int)((LevelProgress / levelMax) * 100);
        LevelProgress += value;
        levelBar.fillAmount = LevelProgress / levelMax;
        textMesLevel.text = auxInt.ToString() + "%";
    }

    // PERDENDO AS BALAS
    public void ShootingBullet(float value)
    {
        AmmunitionProgress -= value;
        ammunitionBar.fillAmount = AmmunitionProgress / ammunitionMax;
    }

    // GANHANDO MAIS BALAS
    public void ReloadingBullets(float value)
    {
        AmmunitionProgress = value;
        ammunitionBar.fillAmount = AmmunitionProgress / ammunitionMax;
    }
}
