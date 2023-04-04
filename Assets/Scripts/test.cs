using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class test : MonoBehaviour
{
    public ArrayList myArray = new ArrayList();
    int[] dasd = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        myArray.Add(0);
        myArray.Add(1);
        myArray.Add(2);
        myArray.Add(3);
        myArray.Add(4);

        dasd[0] = 5;
        dasd[1] = 6;
        dasd[2] = 7;

        LinQTest();
    }


    void LinQTest()
    {

        int[] intarray = new int[] { 3, 4, 5 };
        var query = from values in dasd
                    where dasd.Length >0
                    select values;

        foreach (var values in query)
        {
            Debug.Log(values);
            Debug.Log(query.Sum());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
