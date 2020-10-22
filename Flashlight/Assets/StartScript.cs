using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public Text ChargeText;
    public Slider ChargeSlider;
    public InputField ChargeSpeed;
    public Toggle YesToggle;
    public Toggle NoToggle;
    bool LampIsWork = false;

    public void Start()
    {
        ChargeText.text = "Заряд батарейки (" + (GlobalVars.Charge).ToString() + " %)";
        ChargeSpeed.text = (GlobalVars.ChargeSpeed).ToString();
        ChargeSlider.value = GlobalVars.Charge;
    }

    void Update()
    {
        if (LampIsWork)
        {
            YesToggle.isOn = true;
            NoToggle.isOn = false;
        }
        else
        {
            YesToggle.isOn = false;
            NoToggle.isOn = true;
        }
    }

    public void onSliderValueChanged()
    {
        ChargeText.text = "Заряд батарейки (" + (GlobalVars.Charge).ToString() + " %)";
        GlobalVars.Charge = (float)ChargeSlider.value;
    }

    public void onChargeSpeedChanged()
    {
        if (ChargeSpeed.text != "")
            GlobalVars.ChargeSpeed = (float)Convert.ToDouble(ChargeSpeed.text); 
    }

    public void onYesTogglValueChanged()
    {
        LampIsWork = true;
        NoToggle.isOn = false;
        GlobalVars.LampIsWork = true;
    }

    public void onNoTogglValueChanged()
    {
        LampIsWork = false;
        YesToggle.isOn = false;
        GlobalVars.LampIsWork = false;
    }

    public void Run()
    {
        SceneManager.LoadScene("SimulationScene");
    }
}
