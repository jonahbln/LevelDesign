//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ShootProjectile : MonoBehaviour
//{
//    public GameObject projectilePrefab;
//    public float speed = 100f;
//    public AudioClip shootSFX;

//    public Image reticleImage;

//    public Color reticleDementorColor;

//    public Color reductoColor;
//    public GameObject destroyPrefab;

//    GameObject currentProjectile;

//    bool canFire;

//    Color originalReticleColor;

//    void Start()
//    {
//        currentProjectile = projectilePrefab;
//        originalReticleColor = reticleImage.color;
//        canFire = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetButtonDown("Fire1") && canFire && !LevelManager.gameOver)
//        {
//            GetComponent<Animator>().SetBool("fireBool", true);
//            canFire = false;
            
//            GameObject projectile = 
//            Instantiate(currentProjectile, transform.GetChild(3).transform.position, transform.rotation) as GameObject;

//            Rigidbody rb = projectile.GetComponent<Rigidbody>();

//            rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);

//            projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);

//            AudioSource.PlayClipAtPoint(shootSFX, transform.position, .15f);

//            Invoke("Reset", .575f);

//        }
//    }

//    private void FixedUpdate()
//    {
//        ReticleEffect();
//    }

//    void ReticleEffect()
//    {
//        RaycastHit hit;
//        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
//        {
//            if (hit.collider.CompareTag("Enemy"))
//            {
//                currentProjectile = projectilePrefab;
//                reticleImage.color = Color.Lerp(reticleImage.color, reticleDementorColor, Time.deltaTime * 2.5f);
//                reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, new Vector3(.6f, .6f, 1f), Time.deltaTime * 2.5f); ;
//            }
//            else if(hit.collider.CompareTag("Destructable"))
//            {
//                currentProjectile = destroyPrefab;
//                reticleImage.color = Color.Lerp(reticleImage.color, reductoColor, Time.deltaTime * 2.5f);
//                reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, new Vector3(.6f, .6f, 1f), Time.deltaTime * 2.5f); ;
//            }
//            else
//            {
//                currentProjectile = projectilePrefab;
//                reticleImage.color = Color.Lerp(reticleImage.color, originalReticleColor, Time.deltaTime * 2);
//                reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 1.5f); ;
//            }
//        }

//    }

//    private void Reset()
//    {
//        GetComponent<Animator>().SetBool("fireBool", false);
//        canFire = true;
//    }
//}
