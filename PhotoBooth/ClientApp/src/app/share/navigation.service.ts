import {Injectable} from "@angular/core";

@Injectable()
export class NavigationService {

  constructor() {
  }

  getServerWithProtocol(): string {
    let protocol = window.location.protocol;
    let server = window.location.hostname;

    return protocol + '//' + server;
  }

  getServerWithProtocolAndPort(): string {
    let port = window.location.port;

    return this.getServerWithProtocol() + ':' + port;
  }
}
