import { DeliveryState } from "../rest-service";
import { Component, Input } from "@angular/core";

@Component({
  selector: "delivery-state",
  templateUrl: "./delivery-state.component.html",
})
export class DeliveryStateComponent {
  @Input()
  state: DeliveryState;
}
