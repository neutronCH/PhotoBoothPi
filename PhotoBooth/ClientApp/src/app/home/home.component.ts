import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {NavigationService} from "../share/navigation.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  image: string;

  constructor(private http: HttpClient, private navigation: NavigationService) {
    this.http = http;
  }

  ngOnInit() {
    this.image = this.navigation.getServerWithProtocolAndPort() + '/assets/logo.jpg';
  }

  public startPhotoBooth() {
    this.http.get(this.navigation.getServerWithProtocolAndPort() + '/api/PhotoBoothController/LiveAndCapture').subscribe(result => {
      console.info(result);
    }, error => console.error(error));
  }
}
