using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    public bool ActiveSlowMotion;
    armory Myarmory;
    bool Vecolityx = true;
    // Start is called before the first frame update
    void Start()
    {
        Myarmory = FindObjectOfType<armory>();
        ActiveSlowMotion = true;
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetButtonDown("Fire2"))
        {
            ActiveSlowMotion = true;
        }
        
        if (Input.GetButtonDown("Fire3"))
        {
            ActiveSlowMotion = false;
        }

        SlowMotion();

       

    }

    void SlowMotion()
    {
      
          if (ActiveSlowMotion)
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale,0.25f,1f);
            Time.timeScale -= 0.5f * Time.unscaledDeltaTime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            
            if (Vecolityx)
            {
                Myarmory.BulletYvelocitx *= 4;
                Vecolityx = false;
            }
            
           Invoke("ok",5f);

        }

        else
        {
           Time.timeScale = Mathf.Clamp(Time.timeScale,0.25f,1f);
           Time.timeScale += 0.5f * Time.unscaledDeltaTime;
           Myarmory.BulletYvelocitx = 40f;
           Vecolityx = true; 
           if (Time.timeScale >= 1f)
{
    Destroy(gameObject);
}
        }


    }


    void ok()
    {

     ActiveSlowMotion = false;

    }
}
