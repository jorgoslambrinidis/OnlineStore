import { Routes, RouterModule } from '@angular/router';
import { CreateItemComponent } from './createItem/createItem.component';
import { ItemComponent } from './item/item.component';
import { ReservedItemsComponent } from './reservedItems/reservedItems.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: 'Home', component: ItemComponent },
  { path: 'CreateItem', component: CreateItemComponent, canActivate: [AuthGuard]},
  { path: 'ReservedItems', component: ReservedItemsComponent, canActivate: [AuthGuard]}
];

export const AppRoutes = RouterModule.forRoot(routes);
