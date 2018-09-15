#!/bin/bash
set -x
cd /home/pi/net/photobooth/ClientApp/dist/assets
gphoto2 --capture-image-and-download --force-overwrite --filename latest.jpg
cp /home/pi/net/photobooth/ClientApp/dist/assets/latest.jpg /media/pi/1CDE-F87F/Bilder/$(date -d "today" +"%Y-%m-%d-%H%M%S").jpg
## workaround to avoid that camera blocks
gphoto2 --capture-image &