import {Component, OnInit} from '@angular/core';
import {NavigationService} from "../share/navigation.service";

@Component({
  selector: 'app-liveview',
  templateUrl: './liveview.component.html',
  styleUrls: ['./liveview.component.css']
})
export class LiveviewComponent implements OnInit {

  image: string;

  constructor(private navigation: NavigationService) {
  }

  ngOnInit() {
    this.image = this.navigation.getServerWithProtocol() + ':8090/camera.mjpg' + '?' + (new Date()).getTime();
    // this.image = 'http://192.168.1.11:8090/camera.mjpg'  + '?' + (new Date()).getTime();
  }

}
