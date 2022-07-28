int analogpin = 3;
int analogread = 0;
int analoglowpoint = 0;

void setup() {
  Serial.begin(115200);
  Serial.println("SWCC Start OK");

  //generate baseline for Analog read

  analoglowpoint = analogRead(analogpin);
  delay(100);
  analoglowpoint += analogRead(analogpin);
  delay(100);
  analoglowpoint += analogRead(analogpin);

  analoglowpoint = (analoglowpoint / 3 );
  analoglowpoint += 20;

  Serial.print("Analog Lowpoint:");
  Serial.println(analoglowpoint);
}


void loop() {
  analogread = analogRead(analogpin);


  if (analogread > analoglowpoint)
  {
    delayMicroseconds(300); //allow for voltage ramp up.
    int val = 0;
    for (int i=0;i < 10; i++)
    {
      int tmp_val = analogRead(analogpin);
      if (val < tmp_val)
      {
        val = tmp_val;
      }
    }
    Serial.println(val);



    while (analogread > analoglowpoint) //allow for voltage to return down before new read.
    {
      delay(1);
      analogread = analogRead(analogpin);

    }
    Serial.print("Return to low val:");
    Serial.println(analogRead(analogpin));
  }






}


