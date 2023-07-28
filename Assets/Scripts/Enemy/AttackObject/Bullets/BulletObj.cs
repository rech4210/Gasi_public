using UnityEngine;

public class BulletObj : AtkObjStat
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(myPos.x ,myPos.y, transform.position.z);
        transform.Translate(Vector3.forward* Time.deltaTime * speed);
        //transform.Translate(Vector3.right * Mathf.Sin(Time.time) * Time.deltaTime * speed);
        //transform.Translate(transform.position + new Vector3(myPos.x + (MathF.Sin(Time.time)), myPos.y, myPos.z));
    }
}