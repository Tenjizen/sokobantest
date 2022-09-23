using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTxt : MonoBehaviour
{
    public TextAsset textFile;     // drop your file here in inspector

    void Start()
    {
        string text = textFile.text;  //this is the content as string
        byte[] byteText = textFile.bytes;  //this is the content as byte array


        foreach (var item in text)
        {
            
        }
    }
}
