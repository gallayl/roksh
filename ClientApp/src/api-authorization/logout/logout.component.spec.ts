import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { LogoutComponent } from "./logout.component";
import { ActivatedRoute, Router } from "@angular/router";
import { LogoutActions } from "../api-authorization.constants";

describe("LogoutComponent", () => {
  let component: LogoutComponent;
  let fixture: ComponentFixture<LogoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LogoutComponent],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: { snapshot: { url: [{}, { path: LogoutActions.Logout }] } },
        },
        { provide: Router, useValue: {} },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
