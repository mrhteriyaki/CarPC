
int buffer2count = 0;
char buffer2[500];
int buffer3count = 0;
char buffer3[500];

char serialinputbuffer[500];
int serialinputbuffercount = 0;

void setup() {
  Serial.begin(115200); //Serial to CARPC
  Serial2.begin(115200); //ICC LS CAN BUS Input
  Serial3.begin(115200); //Steering Wheel Control Monitor
  Serial.println("Startup OK - Mega Serial Gateway");

  memset(serialinputbuffer, 0, sizeof(serialinputbuffer));
  memset(buffer2, 0, sizeof(buffer2));
  memset(buffer3, 0, sizeof(buffer3));
}

void loop() {
  if (Serial.available())
  {
    //lower than 32 is a command char.
    int byteread = Serial.read();
    if (byteread < 32)
    {
      //13 = command finished, cr.
      if (byteread == 13)
      {

        //Action then clear input buffer.
        if (strcmp(serialinputbuffer, "GETVALUE") == 0)
        {
          Serial3.println("GETVALUE");
        }
        else
        {
          Serial2.write(serialinputbuffer);
          Serial2.write(13);
        }
        memset(&serialinputbuffer[0], 0, sizeof(serialinputbuffer)); //reset array.
        serialinputbuffercount = 0;
      }

    } 
    else if (byteread < 128)
    {
      //Valid characters.
      serialinputbuffer[serialinputbuffercount] = byteread;
      serialinputbuffercount++;
    }
  }



  if (Serial2.available())
  {
    int serial2data = Serial2.read();
    if (serial2data < 32)
    {
      if (serial2data == 13)
      {
        Serial.println(buffer2);
        memset(&buffer2[0], 0, sizeof(buffer2));
        buffer2count = 0;
      }

    }
    else if (serial2data < 128)
    {
      buffer2[buffer2count] = serial2data;
      buffer2count++;
    }
  }

  if (Serial3.available())
  {
    int serial3data = Serial3.read();
    if (serial3data < 32)
    {
      if (serial3data == 13)
      {
        Serial.print("swcc:");
        Serial.println(buffer3);
        memset(&buffer3[0], 0, sizeof(buffer3));
        buffer3count = 0;
      }

    } 
    else if (serial3data < 128)
    {
      buffer3[buffer3count] = serial3data;
      buffer3count++;
    }
  }
}


