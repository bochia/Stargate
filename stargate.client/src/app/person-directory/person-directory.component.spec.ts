import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonDirectoryComponent } from './person-directory.component';

describe('PersonDirectoryComponent', () => {
  let component: PersonDirectoryComponent;
  let fixture: ComponentFixture<PersonDirectoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PersonDirectoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonDirectoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
