using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viley : MonoBehaviour
{

    public float ExtendedContractTime;
    public float ShakeTime;
    public float MaxRadiusShaking;
    public bool startExtended;
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
            viley.SetActive(startExtended);
            GetComponent<SpriteRenderer>().enabled = !startExtended;
            yield return new WaitForSecondsRealtime(ExtendedContractTime);
            isShaking = true;

            yield return new WaitForSecondsRealtime(ShakeTime);
            isShaking = false;
            transform.localPosition = Vector2.zero;
            startExtended = !startExtended;
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
