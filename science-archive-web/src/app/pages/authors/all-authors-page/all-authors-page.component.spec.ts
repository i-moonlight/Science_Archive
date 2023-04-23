import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllAuthorsPageComponent } from './all-authors-page.component';

describe('AllAuthorsPageComponent', () => {
  let component: AllAuthorsPageComponent;
  let fixture: ComponentFixture<AllAuthorsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllAuthorsPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllAuthorsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
