import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public startPhotoBooth() {
    this.http.get(this.baseUrl + 'api/PhotoBooth/LiveAndCapture').subscribe(result => {
      console.info(result);
    }, error => console.error(error));
  }
}
