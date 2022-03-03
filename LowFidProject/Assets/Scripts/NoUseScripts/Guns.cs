using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guns : MonoBehaviour
{
    // bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    // Guns statistics 

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    // bools 
    bool shooting, readyToShoot, reloading;

    // reference 
    public Camera MainCamera;
    public Transform attackPoint;

    // Graphics 
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammutionDisplay;

    // Bug Fixing
    public bool allowInvoke = true;

    private void Awake()
    {
        // is magazine full?
        bulletsLeft = magazineSize;
        readyToShoot = true;

    }

    private void Update()
    {
        MyInput();

        // ammo diplay ( to create )
        if (ammutionDisplay != null)
        {
            ammutionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        }
    }

    private void MyInput()
    {
        // check if llowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // Shooting 
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            // Set Bullets shot to 0
            bulletsShot = 0;

            // reload

            if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
            {
                Reload();
            }
            if(readyToShoot && shooting && !reloading && bulletsLeft <= 0)
            {
                Reload();
            }

            Shoot();
        }

    }

    void Shoot()
    {
        readyToShoot = false;

        // Hit Position using a raycast
        Ray ray = MainCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        // check if rat hits something

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
            targetPoint = ray.GetPoint(75); // 75 = a point far away from player

        // Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        // calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // calculate new direction with spread
        Vector3 directionWithSpread = directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); // add spread to last distance

        // Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        // instantiate muzzle flash
        if (muzzleFlash)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }


        // rotate vullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        // add force to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        // Invoke resetShot
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        // Do we want a shotgun? More than one bullet code
        if(bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }

    }



     void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
    }
}
