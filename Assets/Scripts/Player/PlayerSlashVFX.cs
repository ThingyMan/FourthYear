using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashVFX : MonoBehaviour
{
    public List<Slash> slashes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SlashAttack()
    {
        for (int i = 0; i < slashes.Count; i++)
        {
            yield return new WaitForSeconds(slashes[i].delay);
            slashes[i].slashObj.SetActive(true);
            //slashes[i].slashObj.transform.position = slashes[i].position;
            //slashes[i].slashObj.transform.rotation = slashes[i].rotation;
        }

        yield return new WaitForSeconds(1);
        DisableSlashes();
    }

    void DisableSlashes()
    {
        for (int i = 0; i < slashes.Count; i++)
            slashes[i].slashObj.SetActive(false);
    }


}

[System.Serializable]
public class Slash
{
    public GameObject slashObj;
    public float delay;
    public Vector3 position;
    public Quaternion rotation;
}
