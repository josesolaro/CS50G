using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PipesPlayState : PlayState, IState
{
    public void OnEnter(MonoBehaviour context)
    {
    }

    public void OnExit()
    {
    }

    public void OnTick(MonoBehaviour context)
    {
        context.transform.position = new Vector3(context.transform.position.x - ((Pipes)context).Speed * Time.deltaTime, context.transform.position.y, context.transform.position.z);
        if (context.transform.position.x < -14)
        {
            GameObject.Destroy(context.gameObject, 0.1f);
        }
    }
}
