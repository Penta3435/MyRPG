using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FuncionaPls();
        }
    }

    static void FuncionaPls()
    {
        Thread thread = new Thread(new ThreadStart(() =>
        {
            for(int i = 0; i < 5; i++)
            {
                print("a");
                Thread.Sleep(1000);
            }
        }));
        thread.Start();
    }

}
