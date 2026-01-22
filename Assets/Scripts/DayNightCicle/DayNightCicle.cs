using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DayNightCicle : MonoBehaviour
{
  [SerializeField] private Volume sun;
  [SerializeField] private float cicleSpeed = 15f;
  enum dayStage
  {
    Sunrise = 0,
    Day = 1,
    Sunset = 2,
    Night = 3,
    Midnight = 4,
  }
  dayStage stage = dayStage.Sunrise;


  void Update()
  {
    cicleSpeed -= Time.deltaTime;


    if (cicleSpeed < 0.0f && stage == dayStage.Sunrise)
    {
      stage = dayStage.Day;
      cicleSpeed = 2f;
    }
    if (cicleSpeed < 0.0f && stage == dayStage.Day)
    {
      stage = dayStage.Sunset;
      cicleSpeed = 2f;
    }
    if (cicleSpeed < 0.0f && stage == dayStage.Sunset)
    {
      stage = dayStage.Night;
      cicleSpeed = 2f;
    }
    if (cicleSpeed < 0.0f && stage == dayStage.Night)
    {
      stage = dayStage.Midnight;
      cicleSpeed = 2f;
    }

    if (cicleSpeed < 0.0f && stage == dayStage.Midnight)
    {
      stage = dayStage.Sunrise;
      cicleSpeed = 2f;
    }

    float t = Mathf.Clamp01((2f - cicleSpeed) / 2f); // No se que fa això.

    switch (stage)
    {
      case dayStage.Sunrise:
        sun.weight = Mathf.Lerp(0.8f, 0.6f, t);
        break;
      case dayStage.Day:
        sun.weight = Mathf.Lerp(0.6f, 0f, t);
        break;
      case dayStage.Sunset:
        sun.weight = Mathf.Lerp(0f, 0.6f, t);
        break;
      case dayStage.Night:
        sun.weight = Mathf.Lerp(0.6f, 1f, t);
        break;
      case dayStage.Midnight:
        sun.weight = Mathf.Lerp(1.0f, 0.8f, t);
        break;
    }

  }
}
