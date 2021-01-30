using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viley : MonoBehaviour
{

    public float ExtendedTime;
    public float ShakeTime;
    public float ContractedTime;
    public float MaxRadiusShaking;
    public GameObject viley;

    private bool isShaking;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PhaseChange());
    }

    private IEnumerator PhaseChange()
    {
        while (true)
        {
            viley.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSecondsRealtime(ExtendedTime);
            isShaking = true;

            yield return new WaitForSecondsRealtime(ShakeTime);
            isShaking = false;
            transform.localPosition = Vector2.zero;

            viley.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSecondsRealtime(ContractedTime);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(isShaking)
        {
            transform.localPosition = Random.insideUnitSphere;
            transform.localPosition *= MaxRadiusShaking;
        }
    }
}
