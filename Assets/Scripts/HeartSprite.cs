using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSprite : MonoBehaviour
{
    [SerializeField] Sprite[] healthSprites;
    PlayerHealth pH;
    player player;
    // Start is called before the first frame update
    void Start()
    {
        pH = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (pH.healthSlider.value == 50f)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[0];
        }

        if (pH.healthSlider.value == 40f)
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[1];

        if (pH.healthSlider.value == 30f)
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[2];

        if (pH.healthSlider.value == 20f)
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[3];

        if (pH.healthSlider.value == 10f)
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[4];

        if (pH.healthSlider.value <= 0f)
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = healthSprites[5];
    }

}
