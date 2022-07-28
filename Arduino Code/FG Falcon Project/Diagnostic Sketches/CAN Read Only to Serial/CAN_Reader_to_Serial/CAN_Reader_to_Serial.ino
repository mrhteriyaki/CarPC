// demo: CAN-BUS Shield, send data
#include <mcp_can.h>
#include <SPI.h>
#include <SimpleTimer.h>
#include <math.h>
unsigned char len = 0;
unsigned char buf[8];
MCP_CAN CAN(9);   

void setup() {
  // put your setup code here, to run once:
Serial.begin(115200);
START_INIT:

    if(CAN_OK == CAN.begin(CAN_500KBPS))                   // init can bus : baudrate = 500k
    {
        Serial.println("CAN BUS Shield init ok!");
    }
    else
    {
        Serial.println("CAN BUS Shield init fail");
        Serial.println("Init CAN BUS Shield again");
        delay(100);
        goto START_INIT;
    }
    
}

void loop() {
  // put your main code here, to run repeatedly:
 if(CAN_MSGAVAIL == CAN.checkReceive())            // check if data coming
    {
        CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf
        Serial.print(CAN.getCanId());Serial.print(",");

        for(int i = 0; i<len; i++)    // print the data
        {
            Serial.print(buf[i]);Serial.print(" ");
        }
        Serial.println();
        
    }
}
