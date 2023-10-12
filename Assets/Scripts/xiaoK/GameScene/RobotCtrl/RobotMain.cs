using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMain : MonoBehaviour
{
    public void LoadGameRobot()
    {
        float x = PlayerPrefs.GetFloat("Robotx", -7.431156f);
        float y = PlayerPrefs.GetFloat("Robotx", 11);
        float z = PlayerPrefs.GetFloat("Robotx", 336.7078f);
        transform.position = new Vector3(x, y, z);
    }
    public void SaveRobotData()
    {
        PlayerPrefs.SetFloat("Robotx", this.transform.localPosition.x);
        PlayerPrefs.SetFloat("Roboty", this.transform.localPosition.y);
        PlayerPrefs.SetFloat("Robotz", this.transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰撞发生,碰撞触发物体名=" + other);

        if (other.tag == "Rocket1")
        {
            Rocket1.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket2")
        {
            Rocket2.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket3")
        {
            Rocket3.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket4")
        {
            Rocket4.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket5")
        {
            Rocket5.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket6")
        {
            Rocket6.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket7")
        {
            Rocket7.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket8")
        {
            Rocket8.instance.RocketDestroy(1);
        }
        else if (other.tag == "Rocket9")
        {
            Rocket9.instance.RocketDestroy(1);
        }
        else if (other.tag == "Finally")
        {
            GameSceneBase.instance.FinallyCtrl(1);
        }
        else if (other.tag == "Player"|| other.tag == "Untagged")
        {

        }
        else
        {
            Debug.Log("执行1");
            OreManager.instance.OreManagerCtrl(other.tag);
        }


    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("触发消失");

        if (other.tag == "Rocket1")
        {
            Rocket1.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket2")
        {
            Rocket2.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket3")
        {
            Rocket3.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket4")
        {
            Rocket4.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket5")
        {
            Rocket5.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket6")
        {
            Rocket6.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket7")
        {
            Rocket7.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket8")
        {
            Rocket8.instance.RocketDestroy(0);
        }
        else if (other.tag == "Rocket9")
        {
            Rocket9.instance.RocketDestroy(0);
        }
        else
        {
            string V = "666";
            OreManager.instance.OreManagerCtrl(V);
        }

        GameObject.FindGameObjectWithTag("FButton").GetComponent<Transform>().transform.localPosition = new Vector3(500, 0, 0);

    }
}
