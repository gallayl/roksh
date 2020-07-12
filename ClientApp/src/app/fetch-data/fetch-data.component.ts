import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get(baseUrl + 'odata/DeliveryStates').subscribe(result => console.log(result))
    http.get(baseUrl + 'odata/Items').subscribe(result => console.log(result))
    http.get(baseUrl + 'odata/Packages').subscribe(result => console.log(result))

    http.post(baseUrl + 'odata/Packages', {StateId: 1, Identifier: "qwer1666"}).subscribe(result => console.log(result));

  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
