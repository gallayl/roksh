import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PackageTrackingPaths } from "./package-tracking.constants";
import { map } from "rxjs/operators";

export interface ODataCollectionResponse<T> {
  value: T[];
}

export type ODataSingleResponse<T> = T & {
  "@odata.context": string;
};

export interface DeliveryState {
  Id: number;
  Code: string;
  Description_EN: string;
  Description_HU: string;
}

export interface Item {
  Id: number;
  Name: string;
  ImageUrl: string;
  ItemUrl: string;
  PackageId: number;
  Package: Package;
}

export interface Package {
  Id: number;
  Identifier: string;
  StateId: number;
  State: DeliveryState;
  Items: Item[];
}

@Injectable()
export class PackageTrackingRestService {
  public getDeliveryStates() {
    return this.http.get<ODataCollectionResponse<DeliveryState>>(
      this.baseUrl + "odata/DeliveryStates"
    );
  }

  public createMockPackage(data: { Identifier: string; StateId: number }) {
    return this.http.post<ODataSingleResponse<Package>>(
      this.baseUrl + "odata/Packages",
      data
    );
  }

  public getPackageDetails(identifier: String) {
    return this.http
      .get<ODataCollectionResponse<Package>>(
        this.baseUrl +
          `odata/Packages?$expand=Items,State&$filter=Identifier eq '${identifier}'`
      )
      .pipe(map((v) => v.value[0] || null));
  }

  public getPackageList(term: String) {
    return this.http
      .get<ODataCollectionResponse<Package>>(
        this.baseUrl +
          `odata/Packages?$expand=State&$top=25&$filter=contains(Identifier, '${term}')`
      )
      .pipe(map((v) => v.value || []));
  }

  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string
  ) {}
}
