using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public FloatReference CurrentHealth;

    public FloatReference MaxHealth;

    private float internalHPValue;

    private float lerpSpeed = 10f;

    private Image img;

    // Start is called before the first frame update
    void Start()
    {
        internalHPValue = MaxHealth.Value;
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth.Value != internalHPValue)
            internalHPValue = Mathf.Lerp(internalHPValue, CurrentHealth.Value, lerpSpeed * Time.deltaTime);

        if(CurrentHealth.Value <= 0)
        {
            internalHPValue = 0;
        }else if(CurrentHealth.Value == MaxHealth.Value)
        {
            internalHPValue = MaxHealth.Value;
        }

        img.fillAmount = Mathf.Lerp(img.fillAmount, internalHPValue / MaxHealth.Value, lerpSpeed * Time.deltaTime);
    }
}
