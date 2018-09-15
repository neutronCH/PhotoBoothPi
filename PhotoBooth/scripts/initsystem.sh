#!/bin/bash
set -x
mkdir -p /home/pi/photobooth
rm -f /home/pi/photobooth/camera.mjpg  
mkfifo /home/pi/photobooth/camera.mjpg

chmod +x startffserver.sh
chmod +x startLiveView.sh
chmod +x stopLiveView.sh
chmod +x takePicture.sh
chmod +x copytostick.sh

cp startffserver.sh /home/pi/photobooth/startffserver.sh
cp startLiveView.sh /home/pi/photobooth/startLiveView.sh
cp stopLiveView.sh /home/pi/photobooth/stopLiveView.sh
cp takePicture.sh /home/pi/photobooth/takePicture.sh
cp copytostick.sh /home/pi/photobooth/copytostick.sh

pkill -f ffserver
sleep 1

./startffserver.sh