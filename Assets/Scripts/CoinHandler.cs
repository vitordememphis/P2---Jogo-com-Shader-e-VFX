using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CoinHandler : MonoBehaviour
{
    public Coin[] coinTypes;

    public MeshRenderer coinMeshRenderer;

    public VisualEffectAsset[] effectTypes;

    public VisualEffect coinEffect;

    public Collider coinCollider;


    int value;
    int timeLimit;

    float time = 0;


    // Start is called before the first frame update
    void Awake()
    {
        SelectType();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > timeLimit)
        {
            DestroyCoin();
        }

        if(GameManager.instance.timer <= 0)
        {
            DestroyCoin();
        }
    }


    void SelectType()
    {
        int coinType = Random.Range(0, 2);

        coinMeshRenderer.material = coinTypes[coinType].coinMaterial;
        coinMeshRenderer.material.SetFloat("_Dissolution_Time", 1);
        StartCoroutine(GenerateCoin());

        if (coinMeshRenderer.material.GetFloat("_Dissolution_Time") >= 0.05)
        {
            StopCoroutine(GenerateCoin());
        }

        coinEffect.visualEffectAsset = effectTypes[coinType];
        value = coinTypes[coinType].coinValue;
        timeLimit = coinTypes[coinType].coinTime;
    }


    void DestroyCoin()
    {
        coinCollider.enabled = false;
        StartCoroutine(DissolveCoin());
        
        if (coinMeshRenderer.material.GetFloat("_Dissolution_Time") >= 0.95)
        {
            StopCoroutine(DissolveCoin());
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Sphere" || other.tag == "Capsule") 
        {
            GameManager.instance.score = GameManager.instance.score + value;

            coinEffect.Play();

            coinMeshRenderer.enabled = false;
            coinCollider.enabled = false;
            Invoke("CoinCollected", 1);
        }
    }

    private IEnumerator GenerateCoin()
    {
        for (float i = 1; i >= 0; i -= 0.01f)
        {
            coinMeshRenderer.material.SetFloat("_Dissolution_Time", i);
            yield return new WaitForSeconds(0.005f);
        }
    }

    private IEnumerator DissolveCoin()
    {
        for (float i = 0; i <= 1; i += 0.01f)
        {
            coinMeshRenderer.material.SetFloat("_Dissolution_Time", i);
            yield return new WaitForSeconds(0.005f);
        }

        if(coinMeshRenderer.material.GetFloat("_Dissolution_Time") >= 0.95)
        {
            Destroy(gameObject);
        }
    }


    void CoinCollected()
    {
        Destroy(gameObject);
    }
}
