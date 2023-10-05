import { HttpClientModule } from '@angular/common/http';
import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { IndexComponent } from './index/index.component';
import { DispositivosComponent } from './dispositivos/dispositivos.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DispositivosComponent
    
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot([
      { path: '', component: IndexComponent, pathMatch: 'full' },
      { path: 'Dispositivos', component: DispositivosComponent}
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
