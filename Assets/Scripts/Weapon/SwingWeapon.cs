using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingWeapon : Weapon
{
    public float swingSpeed;
    public float swingDegrees;
    // Start is called before the first frame update
    public override void Attack()
    {
        transform.localEulerAngles = new Vector3(0, 0, -swingDegrees);
        EnableWeapon();
        Invoke(nameof(DisableWeapon), attackDuration);
        Invoke(nameof(AttackReset), 60f / attackRate);
        StartCoroutine(Swing());
    }
    IEnumerator Swing()
    {
        float degrees = 0;
        while(degrees < swingDegrees)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        DisableWeapon();
    }
}
