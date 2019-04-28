using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public FloatReference HpCurrent;
    public FloatReference HpMax;

    public bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDead == false)
        {
            HpCurrent.Value -= 1 * Time.deltaTime;

            if(HpCurrent.Value <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        IsDead = true;
        HpCurrent.Value = 0;
    }

    public void Spawn()
    {
        HpCurrent.Value = HpMax.Value;

        if (IsDead)
        {
            SceneManager.LoadScene(0);
        }
    }
}
