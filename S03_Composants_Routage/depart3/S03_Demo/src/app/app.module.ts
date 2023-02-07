import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RedComponent } from './red/red.component';
import { EnfantComponent } from './enfant/enfant.component';
import { BleuComponent } from './bleu/bleu.component';
import { JauneComponent } from './jaune/jaune.component';
import { RoseComponent } from './rose/rose.component';


@NgModule({
  declarations: [
    AppComponent,
    RedComponent,
    EnfantComponent,
    BleuComponent,
    JauneComponent,
    RoseComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    RouterModule.forRoot([
       {path:"bleu", component: BleuComponent}, //voir bleu.component.ts class
       {path:"red", component: RedComponent},   //path c'est le nom du chemin, on peut donner Banane
       {path:"jaune", component: JauneComponent},
       {path:"jaune/:legume", component: JauneComponent}, //si plusieurs param, tableau..
       {path:"rose", component: RoseComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
