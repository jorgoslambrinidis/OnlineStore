import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ItemComponent } from './item/item.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { CreateItemComponent } from './createItem/createItem.component';
import { AppRoutes } from './app.routing';
import { ReservedItemsComponent } from './reservedItems/reservedItems.component';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from './_guards/auth.guard';

@NgModule({
   declarations: [
      AppComponent,
      ItemComponent,
      NavComponent,
      FooterComponent,
      CreateItemComponent,
      ReservedItemsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      AppRoutes,
      FormsModule
   ],
   providers: [
    AuthGuard
   ],
   bootstrap: [
      AppComponent,
   ]
})
export class AppModule { }
