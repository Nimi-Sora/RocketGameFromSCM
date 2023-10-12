using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyImageFill : MonoBehaviour
{
    static EnergyImageFill instance;
    public static EnergyImageFill Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnergyImageFill>();
            }
            return instance;
        }
    }

    public Image energyImage1;
    public Image energyImage2;
    public Image energyImage3;
    public Image energyImage4;
    public Image energyImage5;
    public Image energyImage6;
    public Image electric;
    public Image electricTitle;



    private void Update()
    {
        energyImage1.fillAmount = (float)OreBase.instance.OreEnergy1 / 10f;
        energyImage2.fillAmount = (float)OreBase.instance.OreEnergy2 / 10f;
        energyImage3.fillAmount = (float)OreBase.instance.OreEnergy3 / 10f;
        energyImage4.fillAmount = (float)OreBase.instance.OreEnergy4 / 10f;
        energyImage5.fillAmount = (float)OreBase.instance.OreEnergy5 / 10f;
        energyImage6.fillAmount = (float)OreBase.instance.OreEnergy6 / 10f;


        electric.fillAmount = (float)RobotHP.instance.robotHp / 540000f;
        electricTitle.fillAmount = (float)RobotHP.instance.robotHp / 540000f;
    }


}
