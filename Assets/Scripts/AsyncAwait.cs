using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwait : MonoBehaviour
{
    public async Task RotateForSeconds(float duration)
    {
        var end = Time.time + duration;

        while(Time.time < end)
        {
            transform.Rotate(new Vector3 (1, 1)* Time.deltaTime * 150);
            await Task.Yield();
        }
    }
}
