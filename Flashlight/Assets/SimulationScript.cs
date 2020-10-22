using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class SimulationScript : MonoBehaviour
{
    public Text ChargeText;
    public Button LampButton;
    public Button ButtonOn;
    public GameObject LampImage;
    public GameObject BrokenLampImage;
    public GameObject ButtonOnImage;
    public GameObject ButtonOffImage;

    public GameObject DarkBackgroundImage;
    public GameObject LightBackgroundImage;
    public GameObject LightImage;


    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVars.Charge < 10)
            ChargeText.text = "00" + (GlobalVars.Charge).ToString();
        else if (GlobalVars.Charge > 9 && GlobalVars.Charge < 100)
            ChargeText.text = "0" + (GlobalVars.Charge).ToString();
        else
            ChargeText.text = (GlobalVars.Charge).ToString();
        
        if (GlobalVars.LampIsWork)
        {
            LampImage.SetActive(true);
            BrokenLampImage.SetActive(false);
        }
        else
        {
            LampImage.SetActive(false);
            BrokenLampImage.SetActive(true);
        }

        if (GlobalVars.Button)
        {
            ButtonOnImage.SetActive(true);
            ButtonOffImage.SetActive(false);
        }
        else
        {
            ButtonOnImage.SetActive(false);
            ButtonOffImage.SetActive(true);
        }

        if (GlobalVars.LampIsWork && GlobalVars.Button && GlobalVars.Charge > 0)
        {
            DarkBackgroundImage.SetActive(false);
            LightBackgroundImage.SetActive(true);
            LightImage.SetActive(true);
        }
        else
        {
            DarkBackgroundImage.SetActive(true);
            LightBackgroundImage.SetActive(false);
            LightImage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVars.Charge <= 9f)
            ChargeText.text = "00" + (Math.Round(GlobalVars.Charge)).ToString();
        else if (10 <= GlobalVars.Charge && GlobalVars.Charge < 100)
            ChargeText.text = "0" + (Math.Round(GlobalVars.Charge)).ToString();
        else
            ChargeText.text = (Math.Round(GlobalVars.Charge)).ToString();

        if (GlobalVars.LampIsWork)
        {
            LampImage.SetActive(true);
            BrokenLampImage.SetActive(false);
        }
        else
        {
            LampImage.SetActive(false);
            BrokenLampImage.SetActive(true);
        }

        if (GlobalVars.Button)
        {
            ButtonOnImage.SetActive(true);
            ButtonOffImage.SetActive(false);
        }
        else
        {
            ButtonOnImage.SetActive(false);
            ButtonOffImage.SetActive(true);
        }

        if (GlobalVars.LampIsWork && GlobalVars.Button && GlobalVars.Charge > 0)
        {
            GlobalVars.Charge -= Time.deltaTime * GlobalVars.ChargeSpeed;
            DarkBackgroundImage.SetActive(false);
            LightBackgroundImage.SetActive(true);
            LightImage.SetActive(true);
        }
        else
        {
            DarkBackgroundImage.SetActive(true);
            LightBackgroundImage.SetActive(false);
            LightImage.SetActive(false);
        }

        if (GlobalVars.Charging)
        {
            if (GlobalVars.Charge < 99.95f)
                GlobalVars.Charge += Time.deltaTime * 150.0f;
            else
                GlobalVars.Charging = false;
        }

        if (GlobalVars.DisCharging)
        {
            if (GlobalVars.Charge > 0.05)
                GlobalVars.Charge -= Time.deltaTime * 150.0f;
            else
                GlobalVars.DisCharging = false;
        }
    }

    public void onButtonChargeClick()
    {
        GlobalVars.Charging = true;
        GlobalVars.DisCharging = false;
    }

    public void onButtonDisChargeClick()
    {
        GlobalVars.Charging = false;
        GlobalVars.DisCharging = true;
    }
    public void onLampButtonClick()
    {
        GlobalVars.LampIsWork = !GlobalVars.LampIsWork;
    }

    public void onButtonOnClick()
    {
        GlobalVars.Button = !GlobalVars.Button;
    }
}
