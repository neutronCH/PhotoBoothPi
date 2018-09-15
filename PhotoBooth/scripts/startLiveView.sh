#!/bin/bash
set -x
pkill -f gvfsd-gphoto2
pkill -f gphoto2
sleep 1
cd /home/pi/photobooth
gphoto2 --capture-movie --stdout> /home/pi/photobooth/camera.mjpg &
ffmpeg -i /home/pi/photobooth/camera.mjpg http://localhost:8090/camera.ffm &
