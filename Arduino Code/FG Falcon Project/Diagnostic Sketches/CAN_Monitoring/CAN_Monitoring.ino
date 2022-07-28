#define SDA_PORT PORTD
#define SDA_PIN 4   //define the SDA pin         
#define SCL_PORT PORTD
#define SCL_PIN 3   //define the SCL pin

//can variables
#include <SPI.h>
#include <SimpleTimer.h>
#include "mcp_can.h"
#include "MLX90615.h"

MCP_CAN CAN(9);
MLX90615 mlx90615; // for infered temp sensor
unsigned char code787;
unsigned char code851x4;
unsigned char code851x5;

char incomingserial[50];
int incomingcount = 0;

unsigned char char775[8] = {0, 8, 0, 128, 0, 0, 0, 0};
int reset775 = 0;

SimpleTimer tmr100ms;
unsigned char len = 0;
unsigned char buf[8];

void setup() {

  Serial.begin(115200);
  
  // put your setup code here, to run once:
START_INIT:

    if(CAN_OK == CAN.begin(CAN_125KBPS))                   // init can bus : baudrate = 500k
    {
        Serial.println("Primary CAN Init OK");
    }
    else
    {
        Serial.println("Primary CAN BUS Shield init fail");
        Serial.println("Init CAN BUS Shield again");
        delay(100);
        goto START_INIT;
    }
    tmr100ms.setInterval(500, SetSend500ms);
    

}


void loop() {
  tmr100ms.run();
  // put your main code here, to run repeatedly:
if(CAN_MSGAVAIL == CAN.checkReceive())            // check if data coming
  {
        
       CAN.readMsgBuf(&len, buf);    // read data,  len: data length, buf: data buf
       int NodeID = CAN.getCanId();
        Serial.print("CAN:");
        Serial.print(NodeID);
            //Seperate ID and Data
            Serial.print(",");
            //Print CAN Data using Loop through Buffer.
            for(int i = 0; i<len; i++)    // print the data
            {
                Serial.print(buf[i]);
                Serial.print(" ");
            }
            Serial.println();
            if(NodeID == 787)
            {
              Serial.println("TEMP CODE");
              code787 = buf[0];
            }
            if(NodeID == 851)
            {
              code851x4 = buf[3];
              code851x5 = buf[4];
            }
  }


       if (Serial.available())
        {
          ProcessSerialDataIN();
        }
     

 
}

void ProcessSerialDataIN()
{
     int newdata = Serial.read();
    if (newdata < 32)
    {
     if (newdata == 13)
      {
         ActionSerialCommand();
        //Command line has been sent.
         
         //Clear Array
         for( int i = 0; i < incomingcount;  ++i )
         {
         incomingserial[i] = (char)0;
         }
         
         incomingcount = 0;
       
      }
    }else{
      incomingserial[incomingcount] = newdata; 
      incomingcount++;
    }
}
void ActionSerialCommand()
{
                if(strcmp(incomingserial,"fan") == 0)
                {
                 FanIncrease(); 
                }
}


void FanIncrease()
{
  CAN.sendMsgBuf(0x307, 0, 8, char775);
  Serial.println("FAN UP");
}




void SetSend500ms()
{
 float tmpcabintemp = mlx90615.getTemperature(MLX90615_AMBIENT_TEMPERATURE);
 Serial.print("TempSensors:");
 Serial.print(code787);
 Serial.print(",");
 Serial.print(tmpcabintemp);
 Serial.print(",");
 Serial.print(code851x4);
 Serial.print(",");
 Serial.println(code851x5);
 
}
