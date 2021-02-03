using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSwitcher : MonoBehaviour
{
    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject GreenLight;
    public float sec = 14f;
    public bool infiniteBool = true;
    // Start is called before the first frame update
    void Start()
    {
        redLight.gameObject.SetActive(true);
        yellowLight.gameObject.SetActive(false);
        GreenLight.gameObject.SetActive(false);
        StartCoroutine(TrafficLightSystem());
    }
    IEnumerator TrafficLightSystem()
    {
        while (infiniteBool == true)
        {


            yield return new WaitForSecondsRealtime(20);

            redLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            yellowLight.gameObject.SetActive(false);
            GreenLight.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(15);
            GreenLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            yellowLight.gameObject.SetActive(false);
            redLight.gameObject.SetActive(true);

        }
    }
   
}
