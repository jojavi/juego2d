using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healtdisplay : MonoBehaviour
{

    [SerializeField] Health health;

    [SerializeField] Image image;



    private void OnEnable()

    {

        health.onHealthUpdated += HandleImage;

    }



    private void OnDisable()

    {

        health.onHealthUpdated -= HandleImage;

    }



    private void HandleImage()

    {

        image.fillAmount = health.GetFraction();

    }

}
