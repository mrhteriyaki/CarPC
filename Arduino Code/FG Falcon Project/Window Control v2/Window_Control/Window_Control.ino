//Relay = PIN
//K1 = A8
//K2 = 6
//K3 = 10
//K4 = 5
//K5 = A9
//K6 = 4
//K7 = 9
//K8 = 2
//K9 = 8
//K10 = 7 //Right mirror Power switching relay 
//K11 = 11 //Left mirror power switching relay
//K12 = 3 //Mirror Common Switch
//K13 = A14 //Right Mirror - X
//K14 = A12 //Right Mirror - Y
//K15 = A15 //Left Mirror - Y
//K16 = A13 //Left Mirror - X





//Window Relay Pins
  //Front Left
  int front_left_up_pin = 10;
  int front_left_down_pin = 5;
  //Front Right
  int front_right_up_pin = A8;
  int front_right_down_pin = 6;
  //Rear Left
  int rear_left_up_pin = 2;
  int rear_left_down_pin = 9;
  //Rear Right
  int rear_right_up_pin = A9;
  int rear_right_down_pin = 4;

  //Rear Window Power
  int rear_window_power_pin = 8;
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
  int mirror_right_switch_pin = 7;
  int mirror_left_x_pin = A13;
  int mirror_left_y_pin = A15;
  int mirror_left_switch_pin = 11;
  int mirror_common_pin = 3;

  byte mirror_selected = 0; //0 = Right / Driver, 1 = Passenger / Left

//Button Variable
byte front_left_up_button_active = 0;
float front_left_up_button_counter = 0;
float front_left_up_auto_release = 0;

byte front_left_down_button_active = 0;
float front_left_down_button_counter = 0;
float front_left_down_auto_release = 0;

byte front_right_up_button_active = 0;
float front_right_up_button_counter = 0;
float front_right_up_auto_release = 0;

byte front_right_down_button_active = 0;
float front_right_down_button_counter = 0;
float front_right_down_auto_release = 0;

byte rear_left_up_button_active = 0;
float rear_left_up_button_counter = 0;
float rear_left_up_auto_release = 0;

byte rear_left_down_button_active = 0;
float rear_left_down_button_counter = 0;
float rear_left_down_auto_release = 0;

byte rear_right_up_button_active = 0;
float rear_right_up_button_counter = 0;
float rear_right_up_auto_release = 0;

byte rear_right_down_button_active = 0;
float rear_right_down_button_counter = 0;
float rear_right_down_auto_release = 0;

//Lockout Variables
byte front_left_lockout = 0;
byte rear_lockout = 0;

//Timer Object
#include <SimpleTimer.h>
SimpleTimer timer;


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
  pinMode(mirror_common_pin,OUTPUT);
  pinMode(mirror_right_switch_pin,OUTPUT);
  pinMode(mirror_left_switch_pin,OUTPUT);
 
  digitalWrite(front_left_up_pin,1);
  digitalWrite(front_left_down_pin,1);
  digitalWrite(front_right_up_pin,1);
  digitalWrite(front_right_down_pin,1);
  digitalWrite(rear_left_up_pin,1);
  digitalWrite(rear_left_down_pin,1);
  digitalWrite(rear_right_up_pin,1);
  digitalWrite(rear_right_down_pin,1);
  digitalWrite(rear_window_power_pin,1);

  digitalWrite(mirror_right_x_pin,1);
  digitalWrite(mirror_right_y_pin,1);
  digitalWrite(mirror_left_x_pin,1);
  digitalWrite(mirror_left_y_pin,1);
  digitalWrite(mirror_common_pin,1);
  digitalWrite(mirror_right_switch_pin,1);
  digitalWrite(mirror_left_switch_pin,1);

  
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

  

  //Set timer interval and function
  timer.setInterval(100,timerfunction);
}

void loop() {
 CheckButtons(); //Checks button state and sets _active variables.
 timer.run();
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
    digitalWrite(mirror_right_switch_pin,0);
  }else{
    digitalWrite(mirror_left_y_pin,0);
    digitalWrite(mirror_left_switch_pin,0);
  }
  //digitalWrite(mirror_common_pin,1); (commented out as default is 1)
  
}

void mirror_down()
{
   
   if (mirror_selected == 0)
   {
    digitalWrite(mirror_right_y_pin,0);
   }else{
    digitalWrite(mirror_left_y_pin,0);
   }
   digitalWrite(mirror_common_pin,0);
  
}

void mirror_right()
{
  
  if (mirror_selected == 0)
  {
   digitalWrite(mirror_right_switch_pin,0);
   digitalWrite(mirror_right_x_pin,0);
  }else{
   digitalWrite(mirror_left_switch_pin,0);
   digitalWrite(mirror_left_x_pin,0);
  }
  //digitalWrite(mirror_common_pin,1);
}

void mirror_left()
{
   
   if (mirror_selected == 0)
  {
   digitalWrite(mirror_right_x_pin,0);
  }else{
   digitalWrite(mirror_left_x_pin,0);
  }
  digitalWrite(mirror_common_pin,0);
}

void mirror_stop()
{
  digitalWrite(mirror_right_x_pin,1);
  digitalWrite(mirror_right_y_pin,1);
  digitalWrite(mirror_left_x_pin,1);
  digitalWrite(mirror_left_y_pin,1);
  digitalWrite(mirror_common_pin,1);
  digitalWrite(mirror_right_switch_pin,1);
  digitalWrite(mirror_left_switch_pin,1);
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

void timerfunction()
{
  if(front_left_up_button_active == 1)
  {
    //Disable oposite auto action counter.
    front_left_down_auto_release = 0;
    
    //Front Left Window Up.
    front_left_up();
    //Increment counter for detection of auto window action.
    front_left_up_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(front_left_up_button_counter > holdbuttoncount)
    {
      front_left_up_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     front_left_up_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  front_left_up_button_counter = 0; 

  //If Button has been held for set time, go auto
    if(front_left_up_auto_release > 0)
    {
      front_left_up();
      front_left_up_auto_release--;
    }else{
      //Last cycle of auto-action.
      front_left_stop_up();
    }
   
  }
  
  if(front_left_down_button_active == 1)
  {
    //Disable oposite auto action counter.
    front_left_up_auto_release = 0;
    
    //Front Left Window Up.
    front_left_down();
    //Increment counter for detection of auto window action.
    front_left_down_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(front_left_down_button_counter > holdbuttoncount)
    {
      front_left_down_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     front_left_down_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  front_left_down_button_counter = 0; 

  //If Button has been held for set time, go auto
    if(front_left_down_auto_release > 0)
    {
      front_left_down();
      front_left_down_auto_release--;
    }else{
      //Last cycle of auto-action.
      front_left_stop_down();
    }
   
  }
  
    if(front_right_up_button_active == 1)
  {
    //Disable oposite auto action counter.
    front_right_down_auto_release = 0;
    
    //Front Left Window Up.
    front_right_up();
    //Increment counter for detection of auto window action.
    front_right_up_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(front_right_up_button_counter > holdbuttoncount)
    {
      front_right_up_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     front_right_up_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  front_right_up_button_counter = 0;  

  //If Button has been held for set time, go auto
    if(front_right_up_auto_release > 0)
    {
      front_right_up();
      front_right_up_auto_release--;
    }else{
      //Last cycle of auto-action.
      front_right_stop_up();
    }
   
  }
  
  if(front_right_down_button_active == 1)
  {
    //Disable oposite auto action counter.
    front_right_up_auto_release = 0;
    
    //Front Left Window Up.
    front_right_down();
    //Increment counter for detection of auto window action.
    front_right_down_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(front_right_down_button_counter > holdbuttoncount)
    {
      front_right_down_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     front_right_down_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  front_right_down_button_counter = 0; 

  //If Button has been held for set time, go auto
    if(front_right_down_auto_release > 0)
    {
      front_right_down();
      front_right_down_auto_release--;
    }else{
      //Last cycle of auto-action.
      front_right_stop_down();
    }
   
  }
  
    if(rear_left_up_button_active == 1)
  {
    //Disable oposite auto action counter.
    rear_left_down_auto_release = 0;
    
    //Front Left Window Up.
    rear_left_up();
    //Increment counter for detection of auto window action.
    rear_left_up_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(rear_left_up_button_counter > holdbuttoncount)
    {
      rear_left_up_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     rear_left_up_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  rear_left_up_button_counter = 0;  

  //If Button has been held for set time, go auto
    if(rear_left_up_auto_release > 0)
    {
      rear_left_up();
      rear_left_up_auto_release--;
    }else{
      //Last cycle of auto-action.
      rear_left_stop_up();
    }
   
  }
  
  if(rear_left_down_button_active == 1)
  {
    //Disable oposite auto action counter.
    rear_left_up_auto_release = 0;
    
    //Front Left Window Up.
    rear_left_down();
    //Increment counter for detection of auto window action.
    rear_left_down_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(rear_left_down_button_counter > holdbuttoncount)
    {
      rear_left_down_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     rear_left_down_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  rear_left_down_button_counter = 0; 

  //If Button has been held for set time, go auto
    if(rear_left_down_auto_release > 0)
    {
      rear_left_down();
      rear_left_down_auto_release--;
    }else{
      //Last cycle of auto-action.
      rear_left_stop_down();
    }
   
  }
  
    if(rear_right_up_button_active == 1)
  {
    //Disable oposite auto action counter.
    rear_right_down_auto_release = 0;
    
    //Front Left Window Up.
    rear_right_up();
    //Increment counter for detection of auto window action.
    rear_right_up_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(rear_right_up_button_counter > holdbuttoncount)
    {
      rear_right_up_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     rear_right_up_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  rear_right_up_button_counter = 0; 

  //If Button has been held for set time, go auto
    if(rear_right_up_auto_release > 0)
    {
      rear_right_up();
      rear_right_up_auto_release--;
    }else{
      //Last cycle of auto-action.
      rear_right_stop_up();
    }
   
  }
  
  if(rear_right_down_button_active == 1)
  {
    //Disable oposite auto action counter.
    rear_right_up_auto_release = 0;
    
    //Front Left Window Up.
    rear_right_down();
    //Increment counter for detection of auto window action.
    rear_right_down_button_counter++;
    
    //Set auto-counter once button has been held for long enough.
    if(rear_right_down_button_counter > holdbuttoncount)
    {
      rear_right_down_auto_release = 100; //10 seconds of window move.
    }else{
     //reset and disable auto counter if button hasn't been held for long enough.
     rear_right_down_auto_release = 0;  
    }
    
    
  }else{
    //Button has been released.
    //Reset Button Hold Counter
  rear_right_down_button_counter = 0; 

  //If Button has been held for set time, go auto
    if(rear_right_down_auto_release > 0)
    {
      rear_right_down();
      rear_right_down_auto_release--;
    }else{
      //Last cycle of auto-action.
      rear_right_stop_down();
    }
   
  }


  //Rear Window Power for User Control
  if (rear_window_power == 1)
  {
    digitalWrite(rear_window_power_pin,1);
  }else{
    digitalWrite(rear_window_power_pin,0);
  }
  
  
}

void CheckButtons()
{
   //Check buttons
  //Front Left Window
  if (digitalRead(front_left_up_button))
  {
   front_left_up_button_active = 1;
  }else{
   front_left_up_button_active = 0;
  }

  if (digitalRead(front_left_down_button))
  {
    front_left_down_button_active = 1;
  }else{
    front_left_down_button_active = 0;
  }

  //Front Right Window
  if (digitalRead(front_right_up_button))
  {
   front_right_up_button_active = 1;
  }else{
   front_right_up_button_active = 0;
  }

  if (digitalRead(front_right_down_button))
  {
    front_right_down_button_active = 1;
  }else{
    front_right_down_button_active = 0;
  }
   //Front Left Window
  if (digitalRead(rear_left_up_button))
  {
   rear_left_up_button_active = 1;
  }else{
   rear_left_up_button_active = 0;
  }

  if (digitalRead(rear_left_down_button))
  {
    rear_left_down_button_active = 1;
  }else{
    rear_left_down_button_active = 0;
  }

  //Front Right Window
  if (digitalRead(rear_right_up_button))
  {
   rear_right_up_button_active = 1;
  }else{
   rear_right_up_button_active = 0;
  }

  if (digitalRead(rear_right_down_button))
  {
    rear_right_down_button_active = 1;
  }else{
    rear_right_down_button_active = 0;
  }
 
}


//Window Move Functions
  //Front Left Window
  void front_left_up()
  {
    digitalWrite(front_left_up_pin,0);
    digitalWrite(front_left_down_pin,1);
  }
  
  void front_left_down()
  {
    digitalWrite(front_left_down_pin,0);
    digitalWrite(front_left_up_pin,1);
  }
  
 
  //Front Right Window
  void front_right_up()
  {
    digitalWrite(front_right_up_pin,0);
    digitalWrite(front_right_down_pin,1);
  }
  
  void front_right_down()
  {
    digitalWrite(front_right_down_pin,0);
    digitalWrite(front_right_up_pin,1);
  }

  
  //Front Left Window
  void rear_left_up()
  {
    digitalWrite(rear_left_up_pin,0);
    digitalWrite(rear_left_down_pin,1);
  }
  
  void rear_left_down()
  {
    digitalWrite(rear_left_down_pin,0);
    digitalWrite(rear_left_up_pin,1);
  }

  

  //Rear Right Window
  void rear_right_up()
  {
    digitalWrite(rear_right_up_pin,0);
    digitalWrite(rear_right_down_pin,1);
  }
  
  void rear_right_down()
  {
    digitalWrite(rear_right_down_pin,0);
    digitalWrite(rear_right_up_pin,1);
  }

   void front_left_stop_down()
  {
    if (front_left_lockout == 1)
    {
      digitalWrite(front_left_down_pin,0);
    }else{
      digitalWrite(front_left_down_pin,1);
    }
  }
  
  
  void front_right_stop_down()
  {
    digitalWrite(front_right_down_pin,1);
  }

  void rear_left_stop_down()
  {
    digitalWrite(rear_left_down_pin,1);
  }
  
  
  void rear_right_stop_down()
  {
    digitalWrite(rear_right_down_pin,1);
  }

  
  
   void front_left_stop_up()
  {
    if (front_left_lockout == 1)
    {
      digitalWrite(front_left_up_pin,0);
    }else{
      digitalWrite(front_left_up_pin,1);
    }
  }
  
  
  void front_right_stop_up()
  {
    digitalWrite(front_right_up_pin,1);
  }

  void rear_left_stop_up()
  {
    digitalWrite(rear_left_up_pin,1);
  }
  
  
  void rear_right_stop_up()
  {
    digitalWrite(rear_right_up_pin,1);
  }




  
