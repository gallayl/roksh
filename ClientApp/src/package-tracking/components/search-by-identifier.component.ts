import { Package } from "../rest-service";
import { Component, Input } from "@angular/core";
import { Router } from "@angular/router";
import { PackageTrackingPaths } from "../package-tracking.constants";

@Component({
    selector: 'search-by-identifier',
    templateUrl: './search-by-identifier.component.html'
  })
  export class SearchByIdentifierComponent {
    
    term: string
    onTermChanged(ev: Event){
      this.term =(ev.target as HTMLInputElement).value
    }

    onSubmit(){
      this.router.navigate([PackageTrackingPaths.PackageList, this.term])
    }

    constructor(private readonly router: Router) {
      
    }
  }