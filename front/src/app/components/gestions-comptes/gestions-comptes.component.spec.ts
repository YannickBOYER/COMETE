import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionsComptesComponent } from './gestions-comptes.component';

describe('GestionsComptesComponent', () => {
  let component: GestionsComptesComponent;
  let fixture: ComponentFixture<GestionsComptesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GestionsComptesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GestionsComptesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
