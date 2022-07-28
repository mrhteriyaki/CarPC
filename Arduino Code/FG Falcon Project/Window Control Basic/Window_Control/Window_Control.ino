//Relay = PIN
//K1 = A8, front right up
//K2 = 6, front right down
//K3 = 10, front left up
//K4 = 5, front left down
//K5 = A9, rear right up
//K6 = 4, rear right down
//K7 = 9, rear left down
//K8 = 2, rear left up
//K9 = 8, rear window power
//K10 = 7 //Right mirror Power switching relay 
//K11 = 11 //Left mirror power switching relay
//K12 = 3 //Mirror Common Switch
//K13 = A14 //Right Mirror - X
//K14 = A12 //Right Mirror - Y
//K15 = A15 //Left Mirror - Y
//K16 = A13 //Left Mirror - X

//k1 moved to k10, k10 migrated with k11




//Window Relay Pins
  //Front Left
  int front_left_up_pin = 8;
  int front_left_down_pin = 5;
  //Front Right
  int front_right_up_pin = 6;
  int front_right_down_pin = 11;
  //Rear Left
  int rear_left_up_pin = 9;
  int rear_left_down_pin = 4;
  //Rear Right
  int rear_right_up_pin = 3;
  int rear_right_down_pin = A8;

  //Rear Window Power
  int rear_window_power_pin = 10;
  byte rear_window_power = 1;
  

//Button Input Pins
  //Front Left
  int front_left_up_button = A4;
  int front_left_down_button = A6;
  //Front Right
  int front_right_up_button = A7;
  int front_right_down_button = A2;
  //Rear Left
  int rear_left_up_button = A0;
  int rear_left_down_button = A5;
  //Rear Right
  int rear_right_up_button = A1;
  int rear_right_down_button = A3;

//Joystick Pins
  int joystick_x_pin = A10;
  int joystick_y_pin = A11;

  int clickrelease = 0;
  int mirror_action_release = 0;
  
  
//Mirror Relay Pins
  int mirror_right_x_pin = A14;
  int mirror_right_y_pin = A12;
  int mirror_left_x_pin = A13;
  int mirror_left_y_pin = A15;
  int mirror_common_power_pin = A9;
  int mirror_common_return_pin = 2;

  byte mirror_selected = 0; //0 = Right / Driver, 1 = Passenger / Left


//Lockout Variables
byte front_left_lockout = 0;
byte rear_lockout = 0;



float holdbuttoncount = 10; //100ms x 10 = 1 Second

//Serial Buffer
char serialbuffer[150];
int buffersize = 0;



void setup() {
  Serial.begin(115200);

  //Set mode for relay output pins.
  pinMode(front_left_up_pin,OUTPUT);
  pinMode(front_left_down_pin,OUTPUT);
  pinMode(front_right_up_pin,OUTPUT);
  pinMode(front_right_down_pin,OUTPUT);
  pinMode(rear_left_up_pin,OUTPUT);
  pinMode(rear_left_down_pin,OUTPUT);
  pinMode(rear_right_up_pin,OUTPUT);
  pinMode(rear_right_down_pin,OUTPUT);
  pinMode(rear_window_power_pin,OUTPUT);

  pinMode(mirror_right_x_pin,OUTPUT);
  pinMode(mirror_right_y_pin,OUTPUT);
  pinMode(mirror_left_x_pin,OUTPUT);
  pinMode(mirror_left_y_pin,OUTPUT);
  pinMode(mirror_common_power_pin,OUTPUT);
  pinMode(mirror_common_return_pin,OUTPUT);
  



 
  digitalWrite(front_left_up_pin,1);
  digitalWrite(front_left_down_pin,1);
  digitalWrite(front_right_up_pin,1);
  digitalWrite(front_right_down_pin,1);
  digitalWrite(rear_left_up_pin,1);
  digitalWrite(rear_left_down_pin,1);
  digitalWrite(rear_right_up_pin,1);
  digitalWrite(rear_right_down_pin,1);
  
  digitalWrite(rear_window_power_pin,1);//enable rear window control

  digitalWrite(mirror_right_x_pin,1);
  digitalWrite(mirror_right_y_pin,1);
  digitalWrite(mirror_left_x_pin,1);
  digitalWrite(mirror_left_y_pin,1);
  digitalWrite(mirror_common_return_pin,1);
  digitalWrite(mirror_common_power_pin,1);

  
  //Set mode for button input pins
  pinMode(front_left_up_button,INPUT);
  pinMode(front_left_down_button,INPUT);
  pinMode(front_right_up_button,INPUT);
  pinMode(front_right_down_button,INPUT);
  pinMode(rear_left_up_button,INPUT);
  pinMode(rear_left_down_button,INPUT);
  pinMode(rear_right_up_button,INPUT);
  pinMode(rear_right_down_button,INPUT);

  pinMode(joystick_x_pin,INPUT);
  pinMode(joystick_y_pin,INPUT);

}

void loop() {
 CheckButtons(); //Checks button state and sets _active variables.

 SerialCheck();
 CheckJoystick();


}


void CheckJoystick()
{
  int joyX = analogRead(joystick_x_pin);
  int joyY = analogRead(joystick_y_pin);

  int actiontype = 0; //0 nothing, 1 = up, 2 = down, 3 = left, 4 = right.
  
  
  //Click Event
  if (joyX > 1000)
  {
  //X Axis
    if (clickrelease == 0)
    {
        if (mirror_selected == 0)
        {
          //set to passenger / left
          mirror_selected = 1;
        }else{
          //set to driver / right
          mirror_selected = 0;
        }  
    }
  //lockout repeating click action, set to 0 once button released.
    clickrelease = 1;
  }else if(joyX > 700){
    //right
    actiontype = 4;
  }else if(joyX < 300){
    //left
    actiontype = 3;
  }else{
  //X centered.
  actiontype = 0;
  }

  //check for click release.
  if (joyX < 1000)
  {
    //click released
    clickrelease = 0;
  }
    
   //Y Axis
  if (joyY > 700)
  {
    //Up
    actiontype = 1;
  }else if (joyY < 300){
    // Down
    actiontype = 2;
  }
  
 

  if(mirror_action_release == 0){
    
    if(actiontype == 1){
      mirror_up();
    }else if(actiontype == 2){
      mirror_down();
    }else if(actiontype == 3){
      mirror_left();
    }else if(actiontype == 4){
      mirror_right();
    }
    //Lockout Repeating actions, until release.
    mirror_action_release = 1;
  }

   //Release action commands if joystick centered.
   //must run after above if statement.
   if(actiontype == 0)
  {
    mirror_action_release = 0;
    mirror_stop();
  }

    

  
  
  
}



void mirror_up()
{
Serial.println("Mirror up");
  if (mirror_selected == 0)
  {
    digitalWrite(mirror_right_y_pin,0);
  }else{
    digitalWrite(mirror_left_y_pin,0);
  }
  digitalWrite(mirror_common_power_pin,0);
  
}

void mirror_down()
{
   
   if (mirror_selected == 0)
   {
    digitalWrite(mirror_right_y_pin,0);
   }else{
    digitalWrite(mirror_left_y_pin,0);
   }
   digitalWrite(mirror_common_return_pin,0);
  
}

void mirror_right()
{
  digitalWrite(mirror_common_power_pin,0);
  if (mirror_selected == 0)
  {
   digitalWrite(mirror_right_x_pin,0);
  }else{
   
   digitalWrite(mirror_left_x_pin,0);
  }
}

void mirror_left()
{
   
   if (mirror_selected == 0)
  {
   digitalWrite(mirror_right_x_pin,0);
  }else{
   digitalWrite(mirror_left_x_pin,0);
  }
  digitalWrite(mirror_common_return_pin,0);
}

void mirror_stop()
{
  digitalWrite(mirror_right_x_pin,1);
  digitalWrite(mirror_right_y_pin,1);
  digitalWrite(mirror_left_x_pin,1);
  digitalWrite(mirror_left_y_pin,1);
  digitalWrite(mirror_common_return_pin,1);
  digitalWrite(mirror_common_power_pin,1);
}




void SerialCheck()
{
  if (Serial.available())
  {
      int newdata = Serial.read();
      if (newdata < 32)
      {
      if (newdata == 13)
      {
        if(strcmp(serialbuffer, "REARWINDOWDISABLE") == 0)
        {
          rear_window_power = 0;
        }else if(strcmp(serialbuffer, "REARWINDOWENABLE") == 0)
        {
          rear_window_power = 1;
        }
        
        
        for( int i = 0; i < buffersize;  ++i )
        {
         serialbuffer[i] = (char)0;
        }
         
        buffersize = 0;
         
      }
      }else{
        serialbuffer[buffersize] = newdata; 
        buffersize++;
      }
    
  }
  
}


void CheckButtons()
{
   //Check buttons
  //Front Left Window
  if (digitalRead(front_left_up_button))
  {
    digitalWrite(front_left_up_pin,LOW);
  }else{
    digitalWrite(front_left_up_pin,HIGH);
  }

  if (digitalRead(front_left_down_button))
  {
    digitalWrite(front_left_down_pin,LOW);
  }else{
    digitalWrite(front_left_down_pin,HIGH);
  }

  //Front Right Window
  if (digitalRead(front_right_up_button))
  {
    digitalWrite(front_right_up_pin,LOW);
    
  }else{
    digitalWrite(front_right_up_pin,HIGH);
  }

  if (digitalRead(front_right_down_button))
  {
    digitalWrite(front_right_down_pin,LOW);
	Serial.println("front right down");
  }else{
    digitalWrite(front_right_down_pin,HIGH);
  }
   //Front Left Window
  if (digitalRead(rear_left_up_button))
  {
   digitalWrite(rear_left_up_pin,LOW);
  }else{
  digitalWrite(rear_left_up_pin,HIGH);
  }

  if (digitalRead(rear_left_down_button))
  {
    digitalWrite(rear_left_down_pin,LOW);
  }else{
     digitalWrite(rear_left_down_pin,HIGH);
  }

  //Front Right Window
  if (digitalRead(rear_right_up_button))
  {
     digitalWrite(rear_right_up_pin,LOW);
  }else{
     digitalWrite(rear_right_up_pin,HIGH);
  }

  if (digitalRead(rear_right_down_button))
  {
    digitalWrite(rear_right_down_pin,LOW);
  }else{
    digitalWrite(rear_right_down_pin,HIGH);
  }

  digitalWrite(rear_window_power_pin,HIGH);
 
}






  
