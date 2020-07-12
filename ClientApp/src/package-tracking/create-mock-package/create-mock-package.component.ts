import { Component } from "@angular/core";
import {
  PackageTrackingRestService,
  DeliveryState,
  Package,
} from "../rest-service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { NgForm } from "@angular/forms";
import { PackageTrackingPaths } from "../package-tracking.constants";
import { Router } from "@angular/router";

@Component({
  selector: "create-mock-package",
  providers: [PackageTrackingRestService],
  templateUrl: "./create-mock-package.component.html",
})
export class CreateMockPackageComponent {
  public deliveryStates: Observable<DeliveryState[]>;

  public model: { StateId: string; Identifier: string } = {
    StateId: "1",
    Identifier: "",
  };

  public async onSubmit() {
    this.api
      .createMockPackage({
        StateId: parseInt(this.model.StateId, 10),
        Identifier: this.model.Identifier,
      })
      .subscribe((value) => {
        this.router.navigate([
          PackageTrackingPaths.PackageList,
          value.Identifier,
        ]);
      });
  }

  constructor(
    private readonly api: PackageTrackingRestService,
    private router: Router
  ) {
    this.deliveryStates = this.api
      .getDeliveryStates()
      .pipe(map((st) => st.value));
  }
}
