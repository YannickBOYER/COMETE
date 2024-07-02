import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionComptesPageComponent } from './gestion-comptes-page.component';

describe('GestionComptesPageComponent', () => {
  let component: GestionComptesPageComponent;
  let fixture: ComponentFixture<GestionComptesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GestionComptesPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GestionComptesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
