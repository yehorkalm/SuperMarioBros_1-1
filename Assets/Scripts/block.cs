﻿using UnityEngine;
using System.Collections;

public class block : MonoBehaviour
{

    #region PUBLIC

    public AnimationCurve curve;
    public GameObject spawnPrefab;
    public GameObject nextPrefab;

    #endregion

    #region PRIVATE



    #endregion

    IEnumerator sample()
    {
        // start position
        Vector2 pos = transform.position;

        // go through curve time
        for (float t = 0; t < curve.keys[curve.length - 1].time; t += Time.deltaTime)
        {
            // move a bit
            transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t));

            // come back next Update
            yield return null;
        }
        // spawn an object if any
        if (spawnPrefab)
            Instantiate(spawnPrefab, transform.position + Vector3.up / 6, Quaternion.identity);

        // spawn next one if any, destroy box
        if (nextPrefab)
            Instantiate(nextPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // collision below?
        if (col.contacts[0].point.y < transform.position.y)
            StartCoroutine("sample");
    }

    void Start()
    {
		
    }

    void Update()
    {
		
    }
}
