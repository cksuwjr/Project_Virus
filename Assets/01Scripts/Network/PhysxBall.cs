using UnityEngine;
using Fusion;

public class PhysxBall : NetworkBehaviour
{
    //[Networked] private TickTimer life { get; set; }

    //public void Init(Vector3 forward)
    //{
    //    life = TickTimer.CreateFromSeconds(Runner, 5.0f);
    //    GetComponent<Rigidbody>().velocity = forward;
    //}

    //public override void FixedUpdateNetwork()
    //{
    //    if (life.Expired(Runner))
    //        Runner.Despawn(Object);
    //}

    //public override void Despawned(NetworkRunner runner, bool hasState)
    //{

    //    GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    //    gameObject.SetActive(false); // ← 가능하면


    //    base.Despawned(runner, hasState);
    //}
}