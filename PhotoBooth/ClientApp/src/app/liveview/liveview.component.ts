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
    setTimeout(() => {
      // this.image = 'http://192.168.1.11:8090/camera.mjpg' + '?' + (new Date()).getTime();
      this.image = this.navigation.getServerWithProtocol() + ':8090/camera.mjpg' + '?' + (new Date()).getTime();
    }, 1000)
    //

  }

  ngOnDestroy() {
    this.image = null;
  }

}
