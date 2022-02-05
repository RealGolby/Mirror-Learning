using UnityEngine;
using Mirror;
using System;
using System.Collections;

public class Test : NetworkBehaviour
{
    [SerializeField]Gradient g;
    void Update()
    {


        if (!isLocalPlayer) return;
        transform.position += Vector3.left * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Vector3.right;
        }
    }


    IEnumerator Fade(float _duration, float currentValue, float targetValue)
    {
        float duration = _duration;
        float currentTime = 0f;
        while (currentTime<duration)
        {
            float hodnota = Mathf.Lerp(currentValue, targetValue, currentTime/duration);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}

