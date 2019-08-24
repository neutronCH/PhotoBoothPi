#!/bin/bash
set -x
mkdir -p /home/pi/photobooth

chmod +x takePicture.sh
chmod +x copytostick.sh

cp takePicture.sh /home/pi/photobooth/takePicture.sh
cp copytostick.sh /home/pi/photobooth/copytostick.sh