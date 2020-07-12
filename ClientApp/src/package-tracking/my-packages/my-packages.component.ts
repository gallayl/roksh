import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PackageTrackingRestService, Package } from "../rest-service";
import { BehaviorSubject, interval } from "rxjs";
import { debounce } from "rxjs/operators";

@Component({
  selector: "my-packages",
  templateUrl: "./my-packages.component.html",
})
export class MyPackagesComponent {
  term = new BehaviorSubject("");
  packages = new BehaviorSubject<Package[]>([]);

  onTermChanged(ev: Event) {
    this.term.next((ev.target as HTMLInputElement).value);
  }

  constructor(private api: PackageTrackingRestService) {}

  ngOnInit() {
    this.term.pipe(debounce(() => interval(1000))).subscribe((term) => {
      this.api.getPackageList(term).subscribe((v) => {
        this.packages.next(v);
      });
    });
  }
}
