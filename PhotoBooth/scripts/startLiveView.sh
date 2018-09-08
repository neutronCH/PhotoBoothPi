#!/bin/bash
set -x
pkill -f gvfsd-gphoto2
pkill -f gphoto2
cd /home/pi/photobooth
ffmpeg -i /home/pi/photobooth/camera.mjpg http://localhost:8090/camera.ffm &
gphoto2 --capture-movie --stdout> /home/pi/photobooth/camera.mjpg &
