using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System;
public class scriptController : MonoBehaviour
{
    Animator anim;
    Thread clientReceiveThread;
    bool boo;
    UdpClient client;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        clientReceiveThread = new Thread(new ThreadStart(listen));
        clientReceiveThread.IsBackground = true;
        clientReceiveThread.Start();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (boo == true)
        {
            anim.Play("smile");
        }
        if (boo == false)
        {
            anim.Play("doNothing");
        }
    }
    private void listen()
    {
        try
        {

            client = new UdpClient(5555);
            IPEndPoint RemoteIP = new IPEndPoint(IPAddress.Any, 1024);

            while (true)
            {
                Byte[] receiveBytes = client.Receive(ref RemoteIP);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                Debug.Log(returnData);
                String check = "a7a";
                if (String.Equals(check, returnData))
                {
                    Debug.Log("Yes");
                    boo = true;

                }
                else
                {
                    boo = false;
                    Debug.Log("No000000000 ya ebn el a7ba mtgy4 hna tany");
                }
            }

        }
        catch (Exception e)
        {
            Debug.Log(e.Message.ToString());
        }
    }
}
