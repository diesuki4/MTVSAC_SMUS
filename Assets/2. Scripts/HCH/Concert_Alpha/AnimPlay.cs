using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 시네머신 발동시 애니메이션을 틀고 싶다
public class AnimPlay : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.SetTrigger("Play");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
