import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PackageTrackingRestService, Package } from "../rest-service";
import { Observable } from "rxjs";

@Component({
  selector: "package-details",
  templateUrl: "./package-details.component.html",
})
export class PackageDetailsComponent {
  public isLoading = true;

  public packageDetails: Observable<Package>;

  public packageId = this.route.snapshot.params.identifier;

  constructor(
    private api: PackageTrackingRestService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.params.subscribe((param) => {
      this.packageId = param.identifier;
      this.packageDetails = this.api.getPackageDetails(this.packageId);
      this.packageDetails.subscribe((v) => {
        this.isLoading = false;
      });
    });
  }
}
