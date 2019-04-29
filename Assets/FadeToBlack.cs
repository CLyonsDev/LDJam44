using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack Instance;

    private Image FadeToBlackImg;
    [SerializeField]
    float alpha = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Fade2Black()
    {
        StartCoroutine(Fade2BlackCor());
    }

    public void FadeFromBlack()
    {
        Debug.Log("FadeFromBlack");
        StartCoroutine(FadeFromBlackCor());
    }

    public void CrossfadeBlack()
    {
        StartCoroutine(CrossfadeBlackCor());
    }

    private IEnumerator Fade2BlackCor()
    {
        FadeToBlackImg = GetComponent<Image>();

        alpha = 0;
        while(alpha < 1)
        {
            FadeToBlackImg.color = new Color(FadeToBlackImg.color.r, FadeToBlackImg.color.g, FadeToBlackImg.color.b, alpha += 0.05f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        Application.Quit();
    }

    private IEnumerator FadeFromBlackCor()
    {
        FadeToBlackImg = GetComponent<Image>();

        alpha = 1;
        while (alpha > 0)
        {
            Debug.Log("Fade");
            FadeToBlackImg.color = new Color(FadeToBlackImg.color.r, FadeToBlackImg.color.g, FadeToBlackImg.color.b, alpha -= 0.3f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator CrossfadeBlackCor()
    {
        FadeToBlackImg = GetComponent<Image>();

        alpha = 0;
        while (alpha < 1)
        {
            FadeToBlackImg.color = new Color(FadeToBlackImg.color.r, FadeToBlackImg.color.g, FadeToBlackImg.color.b, alpha += .5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        while (alpha > 0)
        {
            FadeToBlackImg.color = new Color(FadeToBlackImg.color.r, FadeToBlackImg.color.g, FadeToBlackImg.color.b, alpha -= .5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
