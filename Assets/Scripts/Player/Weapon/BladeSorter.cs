using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BladeSorter : MonoBehaviour
{
    public bool isSheath = false;
    public GameObject sheath;
    public GameObject blade;
    public bool isCurrentlySheathed = true;
    public Transform sheathedPos;
    public Transform unSheathedPos;

    public float elapsedTime = 0f;
    public float desiredDuration = 3f;

    private void Awake()
    {
        if(isSheath == false)
        {
            sheath.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float percentageComplete = elapsedTime / desiredDuration;
        if (isSheath)
        {
            if (blade.gameObject.activeSelf == false)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if(isCurrentlySheathed == true)
            {
                gameObject.transform.position = Vector3.Lerp(unSheathedPos.position, sheathedPos.position, elapsedTime);
                gameObject.transform.rotation = Quaternion.Lerp(unSheathedPos.rotation, sheathedPos.rotation, elapsedTime);
                elapsedTime += Time.deltaTime * desiredDuration;
                //gameObject.transform.position = sheathedPos.position;
                //gameObject.transform.rotation = sheathedPos.rotation;
            }
            else
            {
                gameObject.transform.position = Vector3.Lerp(sheathedPos.position, unSheathedPos.position, elapsedTime);
                gameObject.transform.rotation = Quaternion.Lerp(sheathedPos.rotation, unSheathedPos.rotation, elapsedTime);
                elapsedTime += Time.deltaTime * desiredDuration;
                //gameObject.transform.position = unSheathedPos.position;
                //gameObject.transform.rotation = unSheathedPos.rotation;
            }
        }
    }
}
