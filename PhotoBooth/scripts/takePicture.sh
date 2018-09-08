#!/bin/bash
set -x
cd /home/pi/net/photobooth/ClientApp/dist/assets
gphoto2 --capture-image-and-download --force-overwrite --filename latest.jpg