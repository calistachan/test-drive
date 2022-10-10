using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightpole : MonoBehaviour
{
    public GameObject[] lights;

    private int index;
    public bool startsOn = false;

    private float[] times = {1f, 1f, 2f};

    private bool complete;
    
    // Start is called before the first frame update
    void Start()
    {
        complete = false;
        if(startsOn) index = 0;
        else index = 2;
        foreach(GameObject light in lights) {
            light.SetActive(false);
        }
        lights[index].SetActive(true);
        
        StartCoroutine(Wait(times[index]));
    }

    // Update is called once per frame
    void Update()
    {
        if(complete) {
            complete = false;
            lights[index].SetActive(false);
            index = (index + 1) % 3;
            lights[index].SetActive(true);
            StartCoroutine(Wait(times[index]));
        }
    }

    public IEnumerator Wait(float time) {
        yield return new WaitForSeconds(time);
        complete = true;
    }
}
