import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllArticlesPageComponent } from './all-articles-page.component';

describe('AllArticlesPageComponent', () => {
  let component: AllArticlesPageComponent;
  let fixture: ComponentFixture<AllArticlesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllArticlesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllArticlesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
