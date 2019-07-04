#!/usr/bin/env python
# coding: utf-8

# In[ ]:


import serial
import socket


# In[ ]:


def parse(data):
    data = data[2:-2]
    arr = data.split(" ")
    
    sync0 = arr[0]
    sync1 = arr[1]
    prot_version = arr[2]
    packet_counter = arr[3]

    ch1_high = arr[4]
    ch1_low = arr[5]
    
    ch2_high = arr[6]
    ch2_low = arr[7]

    ch3_high = arr[8]
    ch3_low = arr[9]
    
    ch4_high = arr[10]
    ch4_low = arr[11]
    
    ch5_high = arr[12]
    ch5_low = arr[13]
    
    ch6_high = arr[14]
    ch6_low = arr[15]
    switches_state = arr[16]
#     print("ch1:", ch1_low)
    return ch1_low

UDP_IP = "192.168.1.37"
UDP_PORT = 5555
MESSAGE = b''


sock = socket.socket(socket.AF_INET, # Internet
                     socket.SOCK_DGRAM) # UDP
sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))
ser = serial.Serial('COM7', 57600, timeout = .1)
c = 0
while True:
    data = ser.readline()[:-2] #the last bit gets rid of the new-line chars
    if data:
        channel = parse(str(data))
#         print("chanel:==>",channel)
        if(int(channel) < 100):
             c+=1 
        else:
            c = 0
        if(c>=30):
            print("yes",c)
            MESSAGE = b'a7a'
            sock.sendto(MESSAGE, (UDP_IP, UDP_PORT))


# In[ ]:


ser.close()


# In[ ]:




