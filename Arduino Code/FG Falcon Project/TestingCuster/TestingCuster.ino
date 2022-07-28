#include <SPI.h>
#include "mcp_can.h"
#include <SimpleTimer.h>

SimpleTimer tmr100ms;


MCP_CAN CAN(9);
unsigned char len = 0;
unsigned char buf[8];

char serialinputbuffer[500];
int serialinputbuffercount = 0;
byte sendcan = 0;

void setup() {
  // put your setup code here, to run once:
 Serial.begin(115200);

 
  
START_INIT:

    if(CAN_OK == CAN.begin(CAN_125KBPS))                   // init can bus : baudrate = 500k
    {
        Serial.println("HS CAN Shield Startup OK");
    }
    else
    {
        Serial.println("HS CAN Shield Failed Startup");
        Serial.println("HS CAN Shield Retry Startup");
        delay(100);
        goto START_INIT;
    }

     tmr100ms.setInterval(100, timerfunction);
}

void loop() {
    tmr100ms.run();
  // put your main code here, to run repeatedly:

  if(CAN_MSGAVAIL == CAN.checkReceive())            // check if data coming
  {
      if (sendcan == 1)
      {
        CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf
        int NodeID = CAN.getCanId();
        Serial.print("CAN:");
        Serial.print(NodeID);
        Serial.print(",");
        for(int i = 0; i<len; i++)    // print the data
        {
          Serial.print(buf[i]);
          Serial.print(" ");
        }
        Serial.println();
      }
       
  }


  if(Serial.available())
  {
    //lower than 32 is a command char.
    int byteread = Serial.read();
    if (byteread < 32)
    {
      //13 = command finished, cr.
       if (byteread == 13)
      {
         //string.substring(from, to)
         String inputstring = serialinputbuffer;
         if (inputstring.length() >= 35)
         {
               Serial.println(inputstring.substring(0,7));
               if(inputstring.substring(0,7).equals("SENDCAN"))
               {
                //Serial.print("CAN NODE:");
                //Serial.println(inputstring.substring(7,11));
                int cannode = inputstring.substring(7,11).toInt();
                //Serial.print("X1:");
                //Serial.print(inputstring.substring(11,14));
                int datax1 = inputstring.substring(11,14).toInt();
                //Serial.print(" X2:");
                //Serial.print(inputstring.substring(14,17));
                int datax2 = inputstring.substring(14,17).toInt();
                //Serial.print(" X3:");
                //Serial.print(inputstring.substring(17,20));
                int datax3 = inputstring.substring(17,20).toInt();
                //Serial.print(" X4:");
                //Serial.print(inputstring.substring(20,23));
                int datax4 = inputstring.substring(20,23).toInt();
                //Serial.print(" X5:");
                //Serial.print(inputstring.substring(23,26));
                int datax5 = inputstring.substring(23,26).toInt();
                //Serial.print(" X6:");
                //Serial.print(inputstring.substring(26,29));
                int datax6 = inputstring.substring(26,29).toInt();
                //Serial.print(" X7:");
                //Serial.print(inputstring.substring(29,32));
                int datax7 = inputstring.substring(29,32).toInt();
                //Serial.print(" X8:");
                //Serial.println(inputstring.substring(32,35));
                int datax8 = inputstring.substring(32,35).toInt();

                unsigned char senddataarray[8] = {datax1,datax2,datax3,datax4,datax5,datax6,datax7,datax8};
                CAN.sendMsgBuf(cannode, 0, 8, senddataarray);

                
               }
         }
         
        //Serial.print("Returned:");
        //Serial.println(serialinputbuffer);
        
        memset(&serialinputbuffer[0], 0, sizeof(serialinputbuffer));
        serialinputbuffercount = 0;
      }
    }else{
     //Valid characters. 
     serialinputbuffer[serialinputbuffercount] = byteread;
     serialinputbuffercount++;
    }
  }


}

unsigned char char519[8] = {11,99,254,137,30,30,0,0};
unsigned char char301[8] = {127,0,0,0,60,100,8,0};
void timerfunction()
{
    //speed

    //CAN.sendMsgBuf(519, 0, 8, char519);
    //0x207
    //RPM
    //301 x5/x6
   //CAN.sendMsgBuf(0x12D, 0, 8, char301);
    //char301[4] = char301[4] + 1;
    //if (char301[4] > 100)
    //{
    //  char301[4] = 0;
    //}
}




