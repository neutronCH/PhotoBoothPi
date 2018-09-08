import {Component, OnInit} from '@angular/core';
import {NavigationService} from "../share/navigation.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-capture',
  templateUrl: './capture.component.html',
  styleUrls: ['./capture.component.css']
})
export class CaptureComponent implements OnInit {
  image: string;


  constructor(private navigation: NavigationService, private router: Router) {
  }

  ngOnInit() {
    this.image = this.navigation.getServerWithProtocolAndPort() + '/assets/latest.jpg' + '?' + (new Date()).getTime();
  }

  print() {
    this.abort();
  }

  abort() {
    this.router.navigate(['']).catch(err => console.log('Error while routing to "home". ' + err.toString()));
  }
}
