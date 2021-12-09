using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BirdStopState : StopState, IState
{
    public void OnEnter(MonoBehaviour context)
    {
        context.gameObject.transform.position = new Vector3(context.gameObject.transform.position.x, 0, context.gameObject.transform.position.z);
        context.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        context.gameObject.GetComponent<Rigidbody2D>().Sleep();
    }

    public void OnExit()
    {
    }

    public void OnTick(MonoBehaviour context)
    {
    }
}
