import { Package } from "../rest-service";
import { Component, Input } from "@angular/core";

@Component({
    selector: 'package-row',
    templateUrl: './package-row.component.html'
  })
  export class PackageRowComponent {
    @Input()
    package: Package
  }