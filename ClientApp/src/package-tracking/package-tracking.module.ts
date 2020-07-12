import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CreateMockPackageComponent } from "./create-mock-package/create-mock-package.component";
import { MyPackagesComponent } from "./my-packages/my-packages.component";
import { PackageDetailsComponent } from "./package-details/package-details.component";
import { AuthorizeGuard } from "../api-authorization/authorize.guard";
import { PackageTrackingPaths } from "./package-tracking.constants";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { PackageTrackingRestService } from "./rest-service";
import { DeliveryStateComponent } from "./components/delivery-state.component";
import { ItemRowComponent } from "./components/item-row.component";
import { PackageRowComponent } from "./components/package-row.component";
import { SearchByIdentifierComponent } from "./components/search-by-identifier.component";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: PackageTrackingPaths.CreateMockPackage,
        component: CreateMockPackageComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: PackageTrackingPaths.Details,
        component: PackageDetailsComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: PackageTrackingPaths.PackageList,
        component: MyPackagesComponent,
        canActivate: [AuthorizeGuard],
      },
    ]),
  ],
  providers: [PackageTrackingRestService],
  declarations: [
    CreateMockPackageComponent,
    DeliveryStateComponent,
    ItemRowComponent,
    MyPackagesComponent,
    PackageDetailsComponent,
    PackageRowComponent,
    SearchByIdentifierComponent,
  ],
  exports: [
    CreateMockPackageComponent,
    DeliveryStateComponent,
    ItemRowComponent,
    MyPackagesComponent,
    PackageDetailsComponent,
    PackageRowComponent,
    SearchByIdentifierComponent,
  ],
})
export class PackageTrackingModule {}
