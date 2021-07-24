# MarsRover
API that translates the commands sent from earth to instructions that are 
understood by the rover.
 
 
 ##Client Side
 
///////////////////////////////////////////////////////////////////////////////////////////////////

##Initialize script
import requests
data = "key4"
r= requests.get('http://localhost:29220/api/Rover/Initialize',json=data,verify=False)
print(r.status_code)
print(r.text)//This Script will Return Rover ID

##Set rover position script
import requests
data = {}
data["Id"]="19d5f8f6-1876-49b5-8997-9a824c92e636"  //Write here the Returned Rover ID you should Run Initialize Script First
data["RoverPosition"]={"Position_X":3,"Position_Y":4,"Direction": "North"}
r= requests.get('http://localhost:29220/api/Rover/SetRoverPosition',json=data,verify=False)
print(r.status_code)
print(r.text)

##ADD Obstacles script

import requests
data = {}
data["Id"]="19d5f8f6-1876-49b5-8997-9a824c92e636"
data["Obstacles"]=[{"Position_X":3,"Position_Y":8},{"Position_X":4,"Position_Y":2}]
r= requests.get('http://localhost:29220/api/Rover/AddRoverObstacles',json=data,verify=False)
print(r.status_code)
print(r.text)


##Run command script

import requests
data = {}
data["Id"]="19d5f8f6-1876-49b5-8997-9a824c92e636"
data["Command"]="FFL"
r= requests.get('http://localhost:29220/api/Rover/RunCommand',json=data,verify=False)
print(r.status_code)
print(r.text)
 
////////////////////////////////////////////////////////////
 
 ##Server Side
 
 First Client will Verify it's KEY to be able to access API and Get RoverID.
 If the Key is valid Client will recieve his Rover's ID.Then the Second Client Script will make tha client able to initialize Rover Positions
 server take this positions and obstacles and save them whenever Clind Sending Command it will move the rover according to these positions.
 
 Note: When the rover Face an obstacle it will return current position (Before the Obstacle position)
 
