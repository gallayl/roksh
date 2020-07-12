import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { LoginMenuComponent } from "./login-menu.component";
import { ActivatedRoute, Router, RouterModule } from "@angular/router";
import { AuthorizeService } from "../authorize.service";
import { BehaviorSubject } from "rxjs";

describe("LoginMenuComponent", () => {
  let component: LoginMenuComponent;
  let fixture: ComponentFixture<LoginMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [LoginMenuComponent],
      imports: [RouterModule],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: { snapshot: { url: [{}, { path: "" }] } },
        },
        { provide: Router, useValue: {} },
        {
          provide: AuthorizeService,
          useValue: {
            isAuthenticated: new BehaviorSubject(true).asObservable,
            getUser: new BehaviorSubject({ name: "júzerke" }).asObservable,
          },
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
