using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISHHYGDDT : MonoBehaviour
{
    private Transform trans;
    private Transform gibContainer;
    private Rigidbody[] gibletsRb;
    public Transform explosionCenter;
    private GameObject tardimesh;
    public float power;
    public float radius = 0F; //infinity and beyond
    private Collider c;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        gibContainer = trans.Find("gibs");
        tardimesh = trans.Find("tardimesh").gameObject;
        gibletsRb = gibContainer.GetComponentsInChildren<Rigidbody>();
        c = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getDeaded(float destroyAfterSec)
    {
        tardimesh.gameObject.SetActive(false);
        gibContainer.gameObject.SetActive(true);
        foreach (Rigidbody r in gibletsRb) {
            r.AddExplosionForce(power, explosionCenter.position, radius, 3.0F);
        }
        Destroy(this.gameObject, destroyAfterSec);
    }

    IEnumerator waitasec(float sec)
    {
        yield return new WaitForSeconds(sec);
        getDeaded(10.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 8 )getDeaded(10f);
    }
}
