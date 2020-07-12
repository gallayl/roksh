import { TestBed, inject } from "@angular/core/testing";

import { AuthorizeGuard } from "./authorize.guard";
import { Router } from "@angular/router";

describe("AuthorizeGuard", () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        { provide: Router, useValue: { navigate: () => ({}) } },
        AuthorizeGuard,
      ],
    });
  });

  it("should ...", inject([AuthorizeGuard], (guard: AuthorizeGuard) => {
    expect(guard).toBeTruthy();
  }));
});
