import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {MatMenuModule, MatToolbarModule} from "@angular/material";
import {FlexLayoutModule} from "@angular/flex-layout";

import {ToastModule} from 'primeng/toast';
import {MessageService} from 'primeng/api';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {LiveviewComponent} from './liveview/liveview.component';
import {CaptureComponent} from './capture/capture.component';
import {NavigationService} from "./share/navigation.service";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LiveviewComponent,
    CaptureComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ToastModule,
    NoopAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    FlexLayoutModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'live-view', component: LiveviewComponent},
      {path: 'capture', component: CaptureComponent},
    ])
  ],
  providers: [NavigationService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
