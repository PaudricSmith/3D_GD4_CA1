using UnityEngine;


public class MorgueTimer : MonoBehaviour
{

    private float timer = 0.0f;


    public float Timer { get => timer; set => timer = value; }


    private void Awake()
    {
        Timer = 0.0f;
    }


    public string GetTimerText()
    {
        double roundedTime = System.Math.Round(Timer, 2);

        return roundedTime.ToString();
    }


    void Update()
    { 
        Timer += Time.deltaTime;

        print(GetTimerText());
    }
}