#!/bin/bash
set -x
cp /home/pi/net/photobooth/ClientApp/dist/assets/latest.jpg /media/pi/1CDE-F87F/Bilder/$(date -d "today" +"%Y-%m-%d-%H%M%S").jpg