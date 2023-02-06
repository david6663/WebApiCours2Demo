import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RedComponent } from './red/red.component';
import { EnfantComponent } from './enfant/enfant.component';
import { BleuComponent } from './bleu/bleu.component';
import { JauneComponent } from './jaune/jaune.component';
import { RoseComponent } from './rose/rose.component';
import { RouterModule } from '@angular/router';

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
      {path:"bleu", component: BleuComponent},
      {path:"red", component: RedComponent},
      {path:"jaune", component: JauneComponent},
      {path:"jaune/:legume", component: JauneComponent},
      {path:"rose", component: RoseComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
