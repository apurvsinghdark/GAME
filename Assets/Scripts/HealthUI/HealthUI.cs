﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
   public GameObject uiPrefeb;
   public Transform target;
   float visibleTime = 5;

   float lastMadeVisibleTime;

   Transform ui;
   Image healthSlider;
   Transform cam;

   private void Start() {
       cam = Camera.main.transform;

       foreach(Canvas c in FindObjectsOfType<Canvas>())
       {
           if (c.renderMode == RenderMode.WorldSpace)
           {
               ui = Instantiate(uiPrefeb,c.transform).transform;
               healthSlider = ui.GetChild(0).GetComponent<Image>();
               ui.gameObject.SetActive(false);
               break;
           }
       }

       GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
   }

   void OnHealthChanged(int maxHealth, int currentHealth)
   {
       if (ui != null)
       {
            ui.gameObject.SetActive(true);
            lastMadeVisibleTime = Time.time;

            float healthPercent = (float)currentHealth/maxHealth;
            healthSlider.fillAmount = healthPercent;

            if(currentHealth <= 0)
                Destroy(ui.gameObject);
       }
   }

   private void LateUpdate() {
       if (true)
       {
           ui.position = target.position;
           ui.forward = -cam.forward;

            if (Time.time - lastMadeVisibleTime > visibleTime)
                ui.gameObject.SetActive(false);
       }
   }
}
