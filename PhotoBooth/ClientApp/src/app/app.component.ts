import {Component, OnInit} from '@angular/core';
import {HubConnection, HubConnectionBuilder, LogLevel} from '@aspnet/signalr';
import {MessageService} from 'primeng/api';
import {Router} from "@angular/router";
import {NavigationService} from "./share/navigation.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private hubConnection: HubConnection;

  constructor(private router: Router, private navigation: NavigationService, private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.navigation.getServerWithProtocol() + ':4200/notify')
      .configureLogging(LogLevel.Trace)
      .build();

    this.hubConnection.on('notify', (timer) => {
      this.messageService.clear();
      this.messageService.add({severity: 'success', summary: 'Countdown', detail: timer, closable: false, life: 2000});
      // this.msgs.push({severity: 'success', summary: 'Countdown', detail: timer, closable: true});
    });

    this.hubConnection.on('navigate', (target) => {
      switch (target) {
        case 'live-view':
          this.router.navigate(['live-view']).catch(err => console.log('Error while routing to "live-view". ' + err.toString()));
          break;
        case 'capture':
          this.router.navigate(['capture']).catch(err => console.log('Error while routing to "capture". ' + err.toString()));
          break;
        case 'home':
          this.router.navigate(['']).catch(err => console.log('Error while routing to "home". ' + err.toString()));
          break;
      }
    });

    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));
  }
}
