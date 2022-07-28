int buffer1count = 0;
char buffer1[500];

int buffercount = 0;
char serialbuffer[250];

bool send_gps_data = true;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200); //Serial to CARPC
  Serial1.begin(57600); //GPS
  Serial1.print("$PMTK220,100*2F\r\n");
  memset(&buffer1[0], 0, 500); //Clear Buffer / Set to nothing.

  pinMode(A0, OUTPUT);
  digitalWrite(A0, LOW);

  memset(buffer1, 0, sizeof(buffer1)); //fill buffers with null to start.
  memset(serialbuffer, 0, sizeof(serialbuffer));
}

void loop() {
  if (send_gps_data)
  {
    if (Serial1.available())
    {
      int serial1data = Serial1.read();
      if (serial1data < 32)
      {
        if (serial1data == 13)
        {

          //VALIDATE GPS Data
          if (sizeof(buffer1) > 3)
          {
            if (buffer1[0] == 36 && buffer1[1] == 71 && buffer1[2] == 80)
            {
              //Send only complete GPS commands (to account for partial recieve from GPS unit)
              Serial.println(buffer1);
            }
          }
          memset(&buffer1[0], 0, sizeof(buffer1));
          buffer1count = 0;
        }
      }
      else if (serial1data < 128)
      {
        buffer1[buffer1count] = serial1data;
        buffer1count++;
      }
    }
  }


  if (Serial.available())
  {
    int serialdata = Serial.read();

    if (serialdata < 32)
    {
      if (serialdata == 13)
      {
        if (strcmp(serialbuffer, "RELAY:ON") == 0)
        {
          Serial.println("RELAY:ON");
          digitalWrite(A0, HIGH);
        }
        else if (strcmp(serialbuffer, "RELAY:OFF") == 0)
        {
          Serial.println("RELAY:OFF");
          digitalWrite(A0, LOW);
        }
        else if (strcmp(serialbuffer, "MONITOR:ON") == 0)
        {
          Serial.println("MONITOR:ON");
          digitalWrite(A2, HIGH);
        }
        else if (strcmp(serialbuffer, "MONITOR:OFF") == 0)
        {
          Serial.println("MONITOR:OFF");
          digitalWrite(A2, LOW);
        }
        else if (strcmp(serialbuffer, "GPS:OFF") == 0)
        {
          send_gps_data = false;
        }
        else if (strcmp(serialbuffer, "GPS:ON") == 0)
        {
          send_gps_data = true;
        }
        memset(serialbuffer, 0, sizeof(serialbuffer)); //clear buffer
        buffercount = 0;
      }


    }
    else if (serialdata < 128)
    {
      serialbuffer[buffercount] = serialdata;
      buffercount++;
    }
  }


}
