import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
