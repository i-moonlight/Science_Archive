import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorPageComponent } from './author-page.component';

describe('AuthorPageComponent', () => {
  let component: AuthorPageComponent;
  let fixture: ComponentFixture<AuthorPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthorPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthorPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
