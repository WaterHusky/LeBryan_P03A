using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    public Gradient gradient;

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
        health.GetComponent<Image>().color = Color.green;
    }

    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform.localScale.x;
        float changeAmt = curHp - newHp;
        float speed = Mathf.Lerp(2.25f, 0.75f, changeAmt);

        while (curHp - newHp > Mathf.Epsilon)
        {
            curHp -= changeAmt * Time.deltaTime * speed;
            health.transform.localScale = new Vector3(curHp, 1f);
            health.GetComponent<Image>().color = gradient.Evaluate(curHp);
            yield return null;
        }
        health.transform.localScale = new Vector3(newHp, 1f);
    }
}
