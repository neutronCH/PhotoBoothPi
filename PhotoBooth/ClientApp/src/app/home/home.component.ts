import {Component} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {NavigationService} from "../share/navigation.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private http: HttpClient, private navigation: NavigationService) {
    this.http = http;
  }

  public startPhotoBooth() {
    this.http.get(this.navigation.getServerWithProtocolAndPort() + '/api/PhotoBoothController/LiveAndCapture').subscribe(result => {
      console.info(result);
    }, error => console.error(error));
  }
}
